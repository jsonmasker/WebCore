using Common;
using Common.Models;
using LulusiaAdmin.Server.Controllers.BaseApiControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LulusiaAdmin.Server.Controllers.SystemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProvinceController : BaseApiController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProvinceController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "LocalData", "Provinces.json");
            List<ProvinceModel> provinces = new List<ProvinceModel>();
            if (!System.IO.File.Exists(filePath))
            {
                return Failed(EStatusCodes.NotFound, "Provinces data file not found.");
            }
            try
            {
                string json = System.IO.File.ReadAllText(filePath);
                provinces = JsonConvert.DeserializeObject<List<ProvinceModel>>(json);
                return Succeeded<List<ProvinceModel>>(provinces, "Provinces retrieved successfully.");
            }
            catch (Exception ex)
            {
                return Failed(EStatusCodes.InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
