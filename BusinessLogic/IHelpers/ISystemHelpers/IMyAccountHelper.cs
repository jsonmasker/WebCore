using Common.ViewModels.SystemViewModels;
using DataAccess.DTOs;

namespace BusinessLogic.IHelpers.ISystemHelpers
{
    public interface IMyAccountHelper
    {
        public Task<UserDTO?> FindByNameAsync(string userName);
        public Task<JwtViewModel> Authenticate(UserDTO user, bool rememberMe);
        public Task<JwtViewModel> LoginAsync(LoginViewModel model);
        public Task<JwtViewModel> ReNewTokenAsync(string refreshToken, string token);
        public Task<bool> ValidateRefreshTokenAsync(string refreshToken);
        public Task<bool> ChangePasswordAsync(ChangePasswordViewModel model);
        public Task<bool> RecoverPassword(RecoverPasswordViewModel model);
        public Task<bool> ResetPasswordAsync(ResetPasswordViewModel model);
    }
}
