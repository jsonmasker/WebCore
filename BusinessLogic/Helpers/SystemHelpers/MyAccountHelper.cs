using AutoMapper;
using BusinessLogic.IHelpers.ISystemHelpers;
using Common.Services.JwtServices;
using Common.ViewModels.SystemViewModels;
using DataAccess;
using DataAccess.DTOs;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BusinessLogic.Helpers.SystemHelpers
{
    public class MyAccountHelper : IMyAccountHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserDTO> _userManager;
        private readonly RoleManager<RoleDTO> _roleManager;
        private readonly IJwtService _jwtService;
        public MyAccountHelper(IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<UserDTO> userManager,
            RoleManager<RoleDTO> roleManager,
            IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            //_userInformation = userInformation;
            //_userLogHelper = userLogHelper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            IEnumerable<UserDTO> data = await _unitOfWork.UserSystemRepository.GetAllAsync(s => !s.IsDeleted);
            return _mapper.Map<IEnumerable<UserViewModel>>(data);
        }
        public async Task<JwtViewModel> LoginAsync(LoginViewModel model)
        {

            JwtViewModel jwtViewModel = new JwtViewModel();
            var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (result)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim("Id",user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                jwtViewModel.Token = _jwtService.CreateToken(authClaims);
                jwtViewModel.RefreshToken = _jwtService.GenerateRefreshToken();
                UserTokenDTO userToken = new UserTokenDTO
                {
                    UserId = user.Id,
                    LoginProvider = "Web API",
                    Name = "RefreshToken",
                    Value = jwtViewModel.RefreshToken,
                    ExpirationTime = DateTime.Now.AddDays(1)
                };
                if (model.RememberMe)
                {
                    userToken.ExpirationTime = DateTime.Now.AddYears(100);
                }
                var userTokens = await _unitOfWork.UserTokenRepository.GetAllAsync(s => s.UserId == user.Id);
                if (userTokens != null)
                {
                    foreach (var item in userTokens)
                    {
                        _unitOfWork.UserTokenRepository.Delete(item);
                    }
                }
                await _unitOfWork.UserTokenRepository.CreateAsync(userToken);
                await _unitOfWork.SaveChangesAsync();

                return jwtViewModel;
            }
            return jwtViewModel;
        }

        public async Task<bool> ValidateRefreshTokenAsync(string refreshToken)
        {
            try
            {
                var data = await _unitOfWork.UserTokenRepository.GetUserTokenByRefreshToken(refreshToken);
                if (data != null)
                {
                    if (data.ExpirationTime > DateTime.Now)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JwtViewModel> ReNewTokenAsync(string refreshToken, string token)
        {
            JwtViewModel jwtViewModel = new JwtViewModel();
            if (string.IsNullOrEmpty(refreshToken) || string.IsNullOrEmpty(token))
            {
                return null;
            }
            bool check = await ValidateRefreshTokenAsync(refreshToken);
            if (!check)
            {
                return null;
            }
            jwtViewModel.RefreshToken = refreshToken;
            jwtViewModel.Token = _jwtService.RenewToken(token);
            if (jwtViewModel.Token == null)
            {
                return null;
            }
            return jwtViewModel;
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            var user = await _unitOfWork.UserSystemRepository.GetByIdAsync(model.UserId);
            if (user == null || model.NewPassword != model.ConfirmPassword)
            {
                return false;
            }
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RecoverPassword(RecoverPasswordViewModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return false;
                }
                //string baseUrl = _settingHelper.GetValueByKey(EWebConfig.AdminLoginUrl);
                //string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                //string subject = _webTemplateHelper.GetValueByKey(EWebTemplate.SubjectResetPassword, ELanguage.VN.ToString());
                //string body = _webTemplateHelper.GetValueByKey(EWebTemplate.CRMBodyResetPassword, ELanguage.VN.ToString());
                //SingleEmailModel singleEmail = new SingleEmailModel();
                //singleEmail.To = user.Email;
                //singleEmail.Subject = subject;
                //singleEmail.Body = body.Replace("#BaseUrl#", baseUrl).Replace("#Token#", token).Replace("#Email#", user.Email);
                //return await _mailService.SendSingleEmailAsync(singleEmail, new CancellationToken());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return false;
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            return result.Succeeded;
        }

    }
}
