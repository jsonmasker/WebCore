using Common.ViewModels.SystemViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Common.Services.JwtServices
{
    public class JwtService : IJwtService
    {
        private readonly ServerAppConfig _appConfig;
        public JwtService(ServerAppConfig appConfig)
        {
            _appConfig = appConfig;
        }
        public string GenerateAccessToken(UserViewModel user)
        {

            var claims = new List<Claim> {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("UserName", user.UserName),
                    //new Claim("Role",user.RoleId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            return CreateToken(claims);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        /// <summary>
        /// new TokenValidationParameters
        /// new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")),
        /// new JwtSecurityTokenHandler();
        /// SecurityToken
        /// new SecurityTokenException("Invalid token");
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string RenewToken(string expiredToken)
        {

            // Decode the expired token to get its claims
            var handler = new JwtSecurityTokenHandler();
            var expiredTokenObj = handler.ReadToken(expiredToken) as JwtSecurityToken;

            if (expiredTokenObj == null)
            {
                // Invalid token format
                return null;
            }

            // Retrieve user claims from the expired token
            var claims = new List<Claim>(expiredTokenObj.Claims);

            return CreateToken(claims);

        }

        public string CreateToken(List<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_appConfig.Issuer,
               _appConfig.Audience,
               claims,
               expires: DateTime.Now.AddMinutes(_appConfig.ExpiredTime),
               signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false, // We want to get claims from expired tokens
                ValidateIssuerSigningKey = true,
                ValidIssuer = _appConfig.Issuer,
                ValidAudience = _appConfig.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.Key))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public List<Claim> GetClaimsFromToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException("Token is empty");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false, // We want to get claims from expired tokens
                ValidateIssuerSigningKey = true,
                ValidIssuer = _appConfig.Issuer,
                ValidAudience = _appConfig.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.Key))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal.Claims.ToList();
        }

        public int GetUserIdFromToken(string token)
        {
            var claims = GetClaimsFromToken(token);
            var temp = claims.FirstOrDefault(s => s.Type == "Id").Value;
            return int.Parse(temp);
        }

        public string GetUserNameFromToken(string token)
        {
            var claims = GetClaimsFromToken(token);
            return claims.FirstOrDefault(s => s.Type == ClaimTypes.Name).Value;

        }
    }
}
