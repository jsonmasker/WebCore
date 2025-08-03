using BusinessLogic.IHelpers.ISystemHelpers;
using Common.Models;
using Common.ViewModels.SystemViewModels;
using LulusiaAdmin.Server.Controllers.BaseApiControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LulusiaAdmin.Server.Controllers.SystemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActionController : BaseApiController
    {
        private readonly IActionHelper _actionHelper;
        private readonly IStringLocalizer<SharedResource> _localizer;
        public ActionController(IActionHelper actionHelper, IStringLocalizer<SharedResource> localizer)
        {
            _actionHelper = actionHelper;
            _localizer = localizer;
        }
        /// <summary>
        /// Get all data
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet("GetAll/{pageIndex}/{pageSize}")]
        public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        {
            string mess = _localizer["dataFetchedSuccessfully"];
            if (pageIndex < 1)
                return Failed(Common.EStatusCodes.BadRequest, _localizer["invalidPageIndex"]);
            Pagination<ActionViewModel> data = await _actionHelper.GetAllAsync(pageIndex, pageSize);
            return Succeeded<Pagination<ActionViewModel>>(data, _localizer["dataFetchedSuccessfully"]);
        }
        [HttpGet("GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {

            IEnumerable<ActionViewModel> data = await _actionHelper.GetAllActiveAsync();
            return Succeeded<IEnumerable<ActionViewModel>>(data, _localizer["dataFetchedSuccessfully"]);
        }

        [HttpGet("GetEAction")]
        public async Task<IActionResult> GetEAction()
        {
            var data = await _actionHelper.GetEActionsAsync();
            return Succeeded<List<string>>(data, _localizer["dataFetchedSuccessfully"]);
        }

        /// <summary>
        /// Get data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ActionViewModel data = await _actionHelper.GetByIdAsync(id);
            if (data == null)
                return Failed(Common.EStatusCodes.NotFound, _localizer["dataNotFound"]);
            return Succeeded<ActionViewModel>(data, _localizer["dataFetchedSuccessfully"]);
        }
        /// <summary>
        /// Create data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [AuthorizeEnumPolicy(Common.ERoles.Admin)]
        public async Task<IActionResult> Create([FromBody] ActionViewModel model)
        {
            if (!ModelState.IsValid)
                return Failed(Common.EStatusCodes.BadRequest, _localizer["invalidData"]);
            bool result = await _actionHelper.CreateAsync(model);
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
        [AuthorizeEnumPolicy(Common.ERoles.Admin)]
        public async Task<IActionResult> Update([FromBody] ActionViewModel model)
        {
            if (!ModelState.IsValid)
                return Failed(Common.EStatusCodes.BadRequest, _localizer["invalidData"]);
            bool result = await _actionHelper.UpdateAsync(model);
            if (!result)
                return Failed(Common.EStatusCodes.NotFound, _localizer["dataUpdateFailed"]);
            return Succeeded(_localizer["dataUpdatedSuccessfully"]);
        }

    }
}
