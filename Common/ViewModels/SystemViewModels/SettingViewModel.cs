using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SystemViewModels
{
    public class SettingViewModel
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
