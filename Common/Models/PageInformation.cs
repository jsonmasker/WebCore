namespace Common.Models
{
    public class PageInformation
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
