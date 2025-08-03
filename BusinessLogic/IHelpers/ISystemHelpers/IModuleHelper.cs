using Common.ViewModels.SystemViewModels;
namespace BusinessLogic.IHelpers.ISystemHelpers
{
    public interface IModuleHelper
    {
        public Task<IEnumerable<ModuleViewModel>> GetAllAsync();
        public Task<ModuleViewModel> GetByIdAsync(int id);
        public Task<bool> CreateAsync(ModuleViewModel model);
        public Task<bool> UpdateAsync(ModuleViewModel model);
    }
}
