using Common;
using Common.Models;
using DataAccess.DTOs;
using LulusiaAdmin.Server;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var applicationconfig = builder.Configuration.GetSection("AppConfig");;
ServerAppConfig appConfig = applicationconfig.Get<ServerAppConfig>();
builder.Services.AddSingleton(appConfig);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
#region add database context
builder.Services.Configure<UserActionLoggingDatabaseSettings>(builder.Configuration.GetSection("UserActionLogging"));
//System DB
builder.Services.AddDbContext<DataAccess.ApplicationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddIdentity<UserDTO, RoleDTO>()
    .AddEntityFrameworkStores<DataAccess.ApplicationContext>()
    .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    //options.User.AllowedUserNameCharacters =
    //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    //options.User.RequireUniqueEmail = false;
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = appConfig.Issuer,
        ValidAudience = appConfig.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appConfig.Key))
    };
});
builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(8);

    //options.LoginPath = "/Admin/Login/Index";
    //options.AccessDeniedPath = "/Admin/Login/AccessDenied";
    options.SlidingExpiration = true;
});
#endregion
#region AddLocalization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
            return factory.Create("ErrorMessage", assemblyName.Name);
        };
    });
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
                        new CultureInfo("en-US"),
                        new CultureInfo("vi-VN")
                    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    var cookieProvider = options.RequestCultureProviders
            .OfType<CookieRequestCultureProvider>()
            .First();
    //cookieProvider.Options.DefaultRequestCulture = new RequestCulture("vi-VN");
    //options.RequestCultureProviders.Clear();
    options.RequestCultureProviders.Add(cookieProvider);
    //options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});
//builder.Services.AddSingleton<WebAppLanguageService>();
#endregion
#region Swagger
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthCore API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                                }
                            },
                            new string[]{}
                        }
                    });
});
#endregion
builder.Services.SignUp();
var app = builder.Build();
#region Add Localization
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
#endregion
app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
