using Common.ViewModels.SystemViewModels;

namespace BusinessLogic.IHelpers.ISystemHelpers
{
    public interface IRoleHelper : IBaseAsyncHelper<RoleViewModel>
    {
        Task<IEnumerable<RoleViewModel>> GetAllActiveAsync();
        Task<RoleViewModel> GetEagerRoleByIdAsync(int id);
    }
}
