using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SystemViewModels
{
    public class ControllerViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Label { get; set; }
        [Range(1, 100)]
        public int Priority { get; set; }
        public ICollection<ControllerActionViewModel> ControllerActions { get; set; }
        public ControllerViewModel()
        {
            ControllerActions = new List<ControllerActionViewModel>();
        }
    }
}
