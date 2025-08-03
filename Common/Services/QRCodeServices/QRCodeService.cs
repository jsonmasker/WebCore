using Common.ViewModels.QRViewModels;

namespace Common.Services.QRCodeServices
{
    public class QRCodeService : IQRCodeService
    {
        private readonly ServerAppConfig _appConfig;
        public QRCodeService(ServerAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public async Task<byte[]> Base64QRCodeImageAsync(QRCodeViewModel model)
        {
            GenerateQRCodeImageAPI generateQRCodeImageAPI = new GenerateQRCodeImageAPI();
            return await generateQRCodeImageAPI.GenerateQRCodeImage(model,_appConfig.PythonServiceUrl);
        }
    }
}
