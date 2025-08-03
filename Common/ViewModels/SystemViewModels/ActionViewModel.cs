using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SystemViewModels
{
    public class ActionViewModel
    {
        public int Id { get; set; }
        [Range(1, 100)]
        public int Priority { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Label { get; set; }
    }
}
