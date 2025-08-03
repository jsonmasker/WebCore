using Microsoft.AspNetCore.Http;

namespace Common.ViewModels.QRViewModels
{
    public class MergeImageViewModel
    {
        public int Quantity { get; set; }
        public string Prefix { get; set; }
        public int CodeLength { get; set; }
        public IFormFile Image { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
