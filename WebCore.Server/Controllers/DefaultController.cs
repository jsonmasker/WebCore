using Common;
using Common.Services.ConvertWordToPdfServices;
using LulusiaAdmin.Server.Controllers.BaseApiControllers;
using Microsoft.AspNetCore.Mvc;

namespace LulusiaAdmin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : BaseApiController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConvertWordToPdfService _convertWordToPdfService;
        public DefaultController(IWebHostEnvironment webHostEnvironment, IConvertWordToPdfService convertWordToPdfService)
        {
            _webHostEnvironment = webHostEnvironment;
            _convertWordToPdfService = convertWordToPdfService;
        }
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            // Example of using the IConvertWordToPdfService
            var filePath = @"D:\Document\CV_NguyenHoangTai.docx";
            var data = _convertWordToPdfService.ConvertWordToPdf(filePath);
            if (data == null)
            {
                return Failed(EStatusCodes.InternalServerError, "Failed to convert Word to PDF.");
            }

            // Ensure the directory exists before saving the file
            var directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "ConvertedFiles");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Save the file to the server
            var fileName = "ConvertedFile.pdf";
            var filePathToSave = Path.Combine(directoryPath, fileName);
            using (var fileStream = new FileStream(filePathToSave, FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(data.Result, 0, data.Result.Length);
            }

            // Return the file path
            return Succeeded("Ping successful");
        }
    }
}
