//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

//namespace LulusiaAdmin.Server.Controllers.SystemControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Authorize]
//    public class SettingController : Controller
//    {
//        private readonly ISettingHelper _settingHelper;
//        public SettingController(ISettingHelper settingHelper)
//        {
//            _settingHelper = settingHelper;
//        }

//        [HttpGet("GetAll")]
//        public IActionResult GetAll()
//        {
//            var data = _settingHelper.GetAll();
//            return Ok(data);
//        }

//        [HttpGet("GetByKey/{key}")]
//        public IActionResult GetByKey(string key)
//        {
//            if (string.IsNullOrEmpty(key) || !Enum.IsDefined(typeof(EWebConfig), key))
//            {
//                return BadRequest();
//            }

//            SettingViewModel data = _settingHelper.GetByKey(key);
//            return Ok(data);
//        }

//        [HttpPut("Update")]
//        public IActionResult Update(SettingViewModel model)
//        {
//            if (!ModelState.IsValid || !Enum.IsDefined(typeof(EWebConfig), model.Key))
//            {
//                return BadRequest();
//            }
//            _settingHelper.Update(model);
//            return Ok();
//        }

//    }
//}
