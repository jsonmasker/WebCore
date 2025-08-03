using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.QRViewModels
{
    public class QRCodeListViewModel : QRCodeViewModel
    {
        [Range(1,10000)]
        public int Quantity { get; set; }
        public string? Prefix { get; set; }
        [Range(5, 20)]
        public int CodeLength { get; set; }
        [Range(0, 10)]
        public int RandomType { get; set; }
    }
}
