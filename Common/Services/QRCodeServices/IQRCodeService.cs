using Common.ViewModels.QRViewModels;

namespace Common.Services.QRCodeServices
{
    public interface IQRCodeService
    {
        public Task<byte[]> Base64QRCodeImageAsync(QRCodeViewModel model);
    }
}
