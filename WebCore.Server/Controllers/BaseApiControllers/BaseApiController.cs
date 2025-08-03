using Common;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
namespace LulusiaAdmin.Server.Controllers.BaseApiControllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult Succeeded<T>(T data, string message)
        {
            return Ok(new ApiResponse<T>(true, message, data));
        }

        protected IActionResult Succeeded(string message)
        {
            return Ok(new ApiResponse(true, message));
        }

        protected IActionResult Failed(EStatusCodes statusCode, string message)
        {
            return StatusCode((int)statusCode, new ApiResponse(false, message));
        }
    
    
    }
}
