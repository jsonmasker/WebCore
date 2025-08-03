using Common.ViewModels.QRViewModels;

namespace BusinessLogic.IHelpers.IFeatureHelper
{
    public interface IQRCodeHelper
    {
        public Task<byte[]> GenerateQRCodeAsync(QRCodeViewModel model);
        public Task<string> GenerateListQRCodeAsync(QRCodeListViewModel model);
    }
}
