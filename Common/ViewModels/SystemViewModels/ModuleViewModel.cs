using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SystemViewModels
{
    public class ModuleViewModel
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Label { get; set; }
        public int Priority { get; set; }
        public ICollection<ControllerViewModel> Controllers { get; set; }
        public ModuleViewModel()
        {
            Controllers = new List<ControllerViewModel>();
        }

    }
}
