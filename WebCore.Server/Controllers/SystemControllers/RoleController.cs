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
    public class RoleController : BaseApiController
    {
        private readonly IRoleHelper _roleHelper;
        private readonly IStringLocalizer<SharedResource> _localizer;
        public RoleController(IRoleHelper roleHelper, IStringLocalizer<SharedResource> localizer)
        {
            _roleHelper = roleHelper;
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
                return Failed(Common.EStatusCodes.BadRequest, _localizer["invalidPageIndex"]);
            Pagination<RoleViewModel> data = await _roleHelper.GetAllAsync(pageIndex, pageSize);
            return Succeeded<Pagination<RoleViewModel>>(data, _localizer["dataFetchedSuccessfully"]);
        }

        [HttpGet("GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {
            var data = await _roleHelper.GetAllActiveAsync();
            return Succeeded(data, _localizer["dataFetchedSuccessfully"]);
        }

        /// <summary>
        /// Get data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            RoleViewModel data = await _roleHelper.GetByIdAsync(id);
            if (data == null)
                return Failed(Common.EStatusCodes.NotFound, _localizer["dataNotFound"]);
            return Succeeded<RoleViewModel>(data, _localizer["dataFetchedSuccessfully"]);
        }
        /// <summary>
        /// Create data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [AuthorizeEnumPolicy(Common.ERoles.Admin)]
        public async Task<IActionResult> Create([FromBody] RoleViewModel model)
        {
            if (!ModelState.IsValid)
                return Failed(Common.EStatusCodes.BadRequest, _localizer["invalidData"]);
            bool result = await _roleHelper.CreateAsync(model);
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
        public async Task<IActionResult> Update([FromBody] RoleViewModel model)
        {
            if (!ModelState.IsValid)
                return Failed(Common.EStatusCodes.BadRequest, _localizer["invalidData"]);
            bool result = await _roleHelper.UpdateAsync(model);
            if (!result)
                return Failed(Common.EStatusCodes.NotFound, _localizer["dataUpdateFailed"]);
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
            bool result = await _roleHelper.SoftDeleteAsync(id);
            if (!result)
                return Failed(Common.EStatusCodes.NotFound, _localizer["dataDeletionFailed"]);
            return Succeeded(_localizer["dataDeletedSuccessfully"]);
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
            bool result = await _roleHelper.RestoreAsync(id);
            if (!result)
                return Failed(Common.EStatusCodes.NotFound, _localizer["dataRestorationFailed"]);
            return Succeeded(_localizer["dataRestoredSuccessfully"]);
        }
        /// <summary>
        /// delete data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        [AuthorizeEnumPolicy(Common.ERoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _roleHelper.DeleteAsync(id);
            if (!result)
                return Failed(Common.EStatusCodes.NotFound, _localizer["dataDeletionFailed"]);
            return Succeeded(_localizer["dataDeletedSuccessfully"]);
        }
    }
}
