using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.QRViewModels
{
    public class QRCodeViewModel
    {
        public required string Content { get; set; }
        [Range(1, 1000)]
        public int Size { get; set; } // height and weight of qr code
        public IFormFile? Logo { get; set; } // if Logo not null, insert image into center qr code image
        public string? Text { get; set; } // if text not null, insert text button qr code
        [Range(10, 100)]
        public int FontSize { get; set; } // font size of text
        public string TextColor { get; set; } // color of text
        public string BackgroundColor { get; set; }
        public string FillColor { get; set; }
        public string? FontFamily { get; set; } // font family of text
        [Range(0, 100)]
        public int Border { get; set; } // Quiet Zones
        public QRCodeViewModel()
        {
            Size = 1;
            Border = 0;
            FontSize = 12; // px
            TextColor = "#000000";
            BackgroundColor = "#FFFFFF";
            FillColor = "#000000";
        }
    }
}
