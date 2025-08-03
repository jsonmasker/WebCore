using BusinessLogic.IHelpers.ISystemHelpers;
using Common;
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
    public class UserController : BaseApiController
    {
        private readonly IUserHelper _userSystemHelper;
        public readonly IStringLocalizer<SharedResource> _localizer;
        public UserController(IUserHelper userSystemHelper, IStringLocalizer<SharedResource> localizer)
        {
            _userSystemHelper = userSystemHelper;
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
            if (pageIndex < 1)
            {
                return Failed(EStatusCodes.BadRequest, _localizer["invalidPageIndex"]);
            }
            Pagination<UserViewModel> data = await _userSystemHelper.GetAllAsync(pageIndex, pageSize);
            return Succeeded<Pagination<UserViewModel>>(data, _localizer["dataFetchedSuccessfully"]);
        }
        /// <summary>
        /// Get data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _userSystemHelper.GetByIdAsync(id);
            if (data == null)
            {
                return Failed(EStatusCodes.NotFound, _localizer["dataNotFound"]);
            }
            return Succeeded<UserViewModel>(data, _localizer["dataFetchedSuccessfully"]);
        }

        /// <summary>
        /// Create data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [AuthorizeEnumPolicy(Common.ERoles.Admin)]
        public async Task<IActionResult> Create([FromBody] UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Failed(EStatusCodes.BadRequest, _localizer["invalidData"]);
            }
            bool result = await _userSystemHelper.CreateAsync(model);
            if (!result)
                return Failed(EStatusCodes.BadRequest, _localizer["dataCreationFailed"]);
            return Succeeded(_localizer["dataCreatedSuccessfully"]);
        }

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        [AuthorizeEnumPolicy(Common.ERoles.Admin)]
        public async Task<IActionResult> Update([FromBody] UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Failed(EStatusCodes.BadRequest, _localizer["invalidData"]);
            }
            bool result = await _userSystemHelper.UpdateAsync(model);
            if (!result)
                return Failed(EStatusCodes.BadRequest, _localizer["dataUpdateFailed"]);
            return Succeeded(_localizer["dataUpdatedSuccessfully"]);
        }

        /// <summary>
        /// Soft delete data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("SoftDelete/{id}")]
        [AuthorizeEnumPolicy(Common.ERoles.Admin)]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await _userSystemHelper.SoftDeleteAsync(id);
            if (!result)
                return Failed(EStatusCodes.BadRequest, _localizer["dataSoftDeleteFailed"]);
            return Succeeded(_localizer["dataSoftDeletedSuccessfully"]);
        }

        /// <summary>
        /// Restore data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("Restore/{id}")]
        [AuthorizeEnumPolicy(Common.ERoles.Admin)]
        public async Task<IActionResult> Restore(int id)
        {
            bool result = await _userSystemHelper.RestoreAsync(id);
            if (!result)
                return Failed(EStatusCodes.BadRequest, _localizer["dataRestoreFailed"]);
            return Succeeded(_localizer["dataRestoredSuccessfully"]);
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        [AuthorizeEnumPolicy(Common.ERoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _userSystemHelper.DeleteAsync(id);
            if (!result)
                return Failed(EStatusCodes.BadRequest, _localizer["dataDeleteFailed"]);
            return Succeeded(_localizer["dataDeletedSuccessfully"]);
        }
    }
}
