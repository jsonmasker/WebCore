using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Common
{
    public static class Global
    {
        /// <summary>
        /// get language code by httprequest
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetLanguageCode(HttpRequest request)
        {
            string? languageCookie = request.Cookies[".AspNetCore.Culture"];
            if (!string.IsNullOrEmpty(languageCookie) && languageCookie.Contains("en-US"))
            {
                return ELanguages.EN.ToString();
            }
            else
            {
                return ELanguages.VN.ToString();
            }
        }
        /// <summary>
        /// Generate random string
        /// </summary>
        /// <param name="length"></param>
        /// <param name="randomType"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int length, int randomType)
        {
            string chars = "0123456789";
            Random random = new Random(); chars = "0123456789";
            if (randomType == (int)EQRCodeTypes.CharacterAndNumber)
            {
                chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            }
            else if (randomType == (int)EQRCodeTypes.Character)
            {
                chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            }

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// reder the razor view to string
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string RenderRazorViewToString(Controller controller, string viewName, object model = null)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    sw,
                    new HtmlHelperOptions()
                );
                viewResult.View.RenderAsync(viewContext);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
