//using Common.Custom.CustomObjectResults;
//using Common.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Localization;

//namespace Common.Custom.CustomActionFilters
//{
//    public class AuthorizeEnumPolicyAttribute : ActionFilterAttribute
//    {
//        private readonly ERoles _role;

//        public AuthorizeEnumPolicyAttribute(ERoles role)
//        {
//            _role = role;
//        }

//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            var user = context.HttpContext.User;
//            var localizer = context.HttpContext.RequestServices.GetService<IStringLocalizer<SharedResource>>();
//            string mess = localizer["aboutUs"];
//            if (user?.Identity?.IsAuthenticated != true)
//            {
//                context.Result = new StatusCodeObjectResult(
//                    EStatusCodes.Unauthorized,
//                    new ApiResponse(false, localizer?["unauthorized"] ?? "Unauthorized")
//                );
//                return;
//            }

//            if (!user.IsInRole(_role.ToString()))
//            {
//                context.Result = new StatusCodeObjectResult(
//                    EStatusCodes.Forbidden,
//                    new ApiResponse(false, localizer?["forbidden"] ?? "Forbidden")
//                );
//                return;
//            }

//            // If everything's okay, proceed
//            base.OnActionExecuting(context);
//        }
//    }
//}
