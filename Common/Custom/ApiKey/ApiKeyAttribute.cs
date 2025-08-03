using Microsoft.AspNetCore.Mvc;

namespace Common.Custom.ApiKey
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute() : base(typeof(ApiKeyAuthFilter))
        {
        }
    }
}
