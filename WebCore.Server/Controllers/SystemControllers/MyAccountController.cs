using BusinessLogic.IHelpers.ISystemHelpers;
using Common;
using Common.Models;
using Common.Services.ActionLoggingServices;
using Common.ViewModels.SystemViewModels;
using DataAccess.DTOs;
using LulusiaAdmin.Server.Controllers.BaseApiControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LulusiaAdmin.Server.Controllers.SystemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAccountController : BaseApiController
    {
        private readonly SignInManager<UserDTO> _signInManager;
        private readonly IMyAccountHelper _myAccountHelper;
        private readonly IActionloggingService _actionLog;
        public readonly IStringLocalizer<MyAccountController> _localizer;
        public readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        public MyAccountController(SignInManager<UserDTO> signInManager,
            IStringLocalizer<MyAccountController> localizer,
            IStringLocalizer<SharedResource> sharedLocalizer,
            IActionloggingService actionLog,
            IMyAccountHelper myAccountHelper)
        {
            _signInManager = signInManager;
            _myAccountHelper = myAccountHelper;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
            _actionLog = actionLog;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Failed(EStatusCodes.BadRequest, _sharedLocalizer["invalidData"]);
            }
            var user = await _myAccountHelper.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return Failed(EStatusCodes.BadRequest, _localizer["usernameOrPasswordIncorrect"]);
            }
            else if (!user.IsActive)
            {
                return Failed(EStatusCodes.BadRequest, _localizer["deactiveUser"]);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                JwtViewModel jwt = await _myAccountHelper.Authenticate(user, model.RememberMe);

                return Succeeded(jwt, _localizer["loginSuccess"]);
            }
            else if (result.IsLockedOut)
            {
                //await _actionLog.CreateAsync(userAction);
                return Failed(EStatusCodes.Locked, _localizer["accountLocked"]);
            }
            else
            {
                //await _actionLog.CreateAsync(userAction);
                return Failed(EStatusCodes.BadRequest, _localizer["usernameOrPasswordIncorrect"]);
            }
        }

        [HttpPost("RecoverPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> RecoverPassword([FromBody] RecoverPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Failed(EStatusCodes.BadRequest, _sharedLocalizer["invalidData"]);
            }
            bool result = await _myAccountHelper.RecoverPassword(model);
            if (result)
            {
                return Succeeded(_localizer["recoverPasswordSuccess"]);
            }
            else
            {
                return Failed(EStatusCodes.BadRequest, _localizer["recoverPasswordFailed"]);
            }
        }

        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Failed(EStatusCodes.BadRequest, _sharedLocalizer["invalidData"]);
            }
            var result = await _myAccountHelper.ResetPasswordAsync(model);
            if (result)
            {
                return Succeeded(_localizer["resetPasswordSuccess"]);
            }
            else
            {
                return BadRequest(_localizer["resetPasswordFailed"]);
            }
        }

        [HttpGet("ValidateRefreshToken")]
        [AllowAnonymous]
        public async Task<IActionResult> ValidateRefreshToken([FromHeader] string refreshToken)
        {
            if (!ModelState.IsValid)
            {
                return Failed(EStatusCodes.BadRequest, _sharedLocalizer["invalidData"]);
            }
            bool result = await _myAccountHelper.ValidateRefreshTokenAsync(refreshToken);
            if (result)
            {
                return Succeeded(_localizer["refreshTokenValid"]);
            }
            else
            {
                return Failed(EStatusCodes.BadRequest, _localizer["refreshTokenInvalid"]);
            }
        }

        [HttpGet("ReNewToken")]
        [AllowAnonymous]
        public async Task<IActionResult> ReNewToken([FromHeader] string refreshToken, [FromHeader] string token)
        {
            try
            {
                if (string.IsNullOrEmpty(refreshToken) || string.IsNullOrEmpty(token))
                {
                    return Failed(EStatusCodes.BadRequest, _localizer["renewTokenFailed"]);
                }

                JwtViewModel jwt = await _myAccountHelper.ReNewTokenAsync(refreshToken, token);
                if (jwt != null)
                {
                    return Succeeded<JwtViewModel>(jwt, _localizer["renewTokenSuccess"]);
                }
                else
                {
                    return Failed(EStatusCodes.BadRequest, _localizer["renewTokenFailed"]);
                }
            }
            catch
            {
                return Failed(EStatusCodes.Unauthorized, _localizer["renewTokenFailed"]);
            }

        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Failed(EStatusCodes.BadRequest, _sharedLocalizer["invalidData"]);
            }
            bool result = await _myAccountHelper.ChangePasswordAsync(model);
            if (result)
            {
                return Succeeded(_localizer["changePasswordSuccess"]);
            }
            else
            {
                return Failed(EStatusCodes.BadRequest, _localizer["changePasswordFailed"]);
            }
        }
    }
}
