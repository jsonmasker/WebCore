using Common.Models;
using Common.ViewModels.SystemViewModels;

namespace BusinessLogic.IHelpers.ISystemHelpers
{
    public interface IActionHelper
    {
        public Task<Pagination<ActionViewModel>> GetAllAsync(int pageIndex, int pageSize);
        public Task<IEnumerable<ActionViewModel>> GetAllActiveAsync();
        public Task<List<string>> GetEActionsAsync();
        public Task<ActionViewModel> GetByIdAsync(int id);
        public Task<bool> CreateAsync(ActionViewModel model);
        public Task<bool> UpdateAsync(ActionViewModel model);
    }
}
