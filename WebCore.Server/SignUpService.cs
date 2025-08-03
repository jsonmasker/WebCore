using BusinessLogic.Helpers.FeatureHelpers;
using BusinessLogic.Helpers.SystemHelpers;
using BusinessLogic.IHelpers.ISystemHelpers;
using Common.Custom.ApiKey;
using Common.Services.ActionLoggingServices;
using Common.Services.ConvertWordToPdfServices;
using Common.Services.EMailServices;
using Common.Services.FileStorageServices;
using Common.Services.JwtServices;
using Common.Services.QRCodeServices;

namespace LulusiaAdmin.Server
{
    public static class SignUpService
    {
        public static IServiceCollection SignUp(this IServiceCollection services)
        {
            #region System Database
            services.AddScoped<DataAccess.IUnitOfWork, DataAccess.UnitOfWork>();
            //system
            services.AddScoped<IUserHelper, UserHelper>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IModuleHelper, ModuleHelper>();
            services.AddScoped<IRoleHelper, RoleHelper>();
            services.AddScoped<IMyAccountHelper, MyAccountHelper>();
            services.AddScoped<IActionHelper, ActionHelper>();
            services.AddScoped<ISettingHelper, SettingHelper>();
            #endregion
            #region Service
            //service
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IFileStorageService, FileStorageService>();
            services.AddScoped<IActionloggingService, ActionLoggingService>();
            services.AddTransient<IApiKeyValidation, ApiKeyValidation>();
            services.AddScoped<ApiKeyAuthFilter>();
            services.AddAutoMapper(typeof(Program));
            #endregion
            return services;
        }
    }
}
