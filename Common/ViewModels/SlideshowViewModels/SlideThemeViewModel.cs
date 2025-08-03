namespace Common.ViewModels.SlideshowViewModels
{
    public class SlideThemeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
