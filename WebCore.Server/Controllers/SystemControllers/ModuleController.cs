using BusinessLogic.IHelpers.ISystemHelpers;
using Common.ViewModels.SystemViewModels;
using LulusiaAdmin.Server.Controllers.BaseApiControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LulusiaAdmin.Server.Controllers.SystemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ModuleController : BaseApiController
    {
        private readonly IModuleHelper _moduleHelper;
        private readonly IStringLocalizer<SharedResource> _localizer;
        public ModuleController(IModuleHelper moduleHelper, IStringLocalizer<SharedResource> localizer)
        {
            _moduleHelper = moduleHelper;
            _localizer = localizer;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ModuleViewModel> data = await _moduleHelper.GetAllAsync();
            return Succeeded<IEnumerable<ModuleViewModel>>(data, _localizer["dataFetchedSuccessfully"]);
        }
        /// <summary>
        /// Get data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ModuleViewModel data = await _moduleHelper.GetByIdAsync(id);
            if (data == null)
                return Failed(Common.EStatusCodes.NotFound, _localizer["dataNotFound"]);
            return Succeeded<ModuleViewModel>(data, _localizer["dataFetchedSuccessfully"]);
        }
        /// <summary>
        /// Create data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ModuleViewModel model)
        {
            if (!ModelState.IsValid)
                return Failed(Common.EStatusCodes.BadRequest, _localizer["invalidData"]);
            bool result = await _moduleHelper.CreateAsync(model);
            if (!result)
                return Failed(Common.EStatusCodes.BadRequest, _localizer["dataCreationFailed"]);
            return Succeeded(_localizer["dataCreatedSuccessfully"]);
        }
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ModuleViewModel model)
        {
            if (!ModelState.IsValid)
                return Failed(Common.EStatusCodes.BadRequest, _localizer["invalidData"]);
            bool result = await _moduleHelper.UpdateAsync(model);
            if (!result)
                return Failed(Common.EStatusCodes.NotFound, _localizer["dataUpdateFailed"]);
            return Succeeded(_localizer["dataUpdatedSuccessfully"]);
        }

    }
}
