using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SlideshowViewModels
{
    public class SlideViewModel
    {
        public int Id { get; set; }
        public int SlideThemeId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int SlideType { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public string? ImageName { get; set; }
        public string? VideoName { get; set; }
        public IFormFile? ImageFile { get; set; }
        public IFormFile? VideoFile { get; set; }
        [Range(100, 10000)]
        public int SlideTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public SlideViewModel()
        {
            IsActive = true;
            Priority = 1;
            SlideTime = 200;
            Title = string.Empty;
        }
    }
}
