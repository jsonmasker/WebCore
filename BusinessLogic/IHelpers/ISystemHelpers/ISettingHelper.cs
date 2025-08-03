using Common.ViewModels.SystemViewModels;

namespace BusinessLogic.IHelpers.ISystemHelpers
{
    public interface ISettingHelper
    {
        public IEnumerable<SettingViewModel> GetAll();
        public SettingViewModel GetByKey(string key);
        public void Update(SettingViewModel model);
    }
}
