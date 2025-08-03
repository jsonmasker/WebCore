using System.IO.Compression;
using BusinessLogic.IHelpers.IFeatureHelper;
using ClosedXML.Excel;
using Common;
using Common.Models;
using Common.Services.FileStorageServices;
using Common.Services.QRCodeServices;
using Common.ViewModels.QRViewModels;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace BusinessLogic.Helpers.FeatureHelpers
{
    public class QRCodeHelper : IQRCodeHelper
    {
        private readonly IQRCodeService _qrCodeService;
        private readonly IFileStorageService _fileStorageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public QRCodeHelper(IQRCodeService qrCodeService,
            IWebHostEnvironment webHostEnvironment,
            IFileStorageService fileStorageService)
        {
            _qrCodeService = qrCodeService;
            _webHostEnvironment = webHostEnvironment;
            _fileStorageService = fileStorageService;
        }
        public async Task<byte[]> GenerateQRCodeAsync(QRCodeViewModel model)
        {
            return await _qrCodeService.Base64QRCodeImageAsync(model);
        }

        public async Task<string> GenerateListQRCodeAsync(QRCodeListViewModel model)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, EModules.Feature.ToString(),EFolderNames.QRCodes.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                // Remove old files
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
            // Generate data for QR code
            List<QRVoucherModel> data = GenderData(model.Quantity, model.RandomType, model.CodeLength, model.Prefix);
            // Export data to excel
            ExportDataToExcel(data);
            // Generate QR code
            for (int i = 0; i < model.Quantity; i++)
            {
                QRCodeViewModel qrCodeModel = new QRCodeViewModel()
                {
                    Content = data[i].Code,
                    Size = model.Size,
                    Logo = model.Logo,
                    Text = model.Text,
                    FontSize = model.FontSize,
                    TextColor = model.TextColor,
                    BackgroundColor = model.BackgroundColor,
                    FillColor = model.FillColor,
                    FontFamily = model.FontFamily,
                    Border = model.Border
                };
                byte[] fileBytes = await _qrCodeService.Base64QRCodeImageAsync(qrCodeModel);
                string fileName = string.Concat(data[i].Name, ".png");
                string filePath = Path.Combine(path, fileName);

                File.WriteAllBytes(filePath, fileBytes);
            }
            // Zip all files
            string zipFilePath = Path.Combine(_webHostEnvironment.WebRootPath, EModules.Feature.ToString(), "QRCodes.zip");
            if (File.Exists(zipFilePath))
                File.Delete(zipFilePath);
            ZipFile.CreateFromDirectory(path, zipFilePath);
            return zipFilePath;

        }

        /// <summary>
        /// Generate data for QR code
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="randomType"></param>
        /// <param name="numberOfCharacter"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        private List<QRVoucherModel> GenderData(int quantity, int randomType, int numberOfCharacter, string? prefix = null)
        {
            List<QRVoucherModel> voucherModels = new List<QRVoucherModel>();
            string format = "D" + (quantity.ToString().Length + 1);

            for (int i = 1; i <= quantity; i++)
            {
                //string.IsNullOrEmpty(prefix) ? i.ToString(format) :
                string name = string.IsNullOrEmpty(prefix) ? i.ToString(format) : string.Concat(prefix,"_",i.ToString(format));
                string code = prefix + Global.GenerateRandomString(numberOfCharacter, randomType);
                //Check code is exist in QRVoucherModel list
                bool check = voucherModels.Any(x => x.Code == code);
                while (check)
                {
                    code = prefix + Global.GenerateRandomString(numberOfCharacter, randomType);
                    check = voucherModels.Any(x => x.Code == code);
                }
                voucherModels.Add(new QRVoucherModel { Name = name, Code = code });
            }
            return voucherModels;

        }
       
        /// <summary>
        /// Export data to excel
        /// </summary>
        /// <param name="QRVoucherModels"></param>
        private void ExportDataToExcel(List<QRVoucherModel> QRVoucherModels)
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, EModules.Feature.ToString(), EFolderNames.QRCodes.ToString(), "VoucherData.xlsx");
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.AddWorksheet("QRVoucherModels");
                // Write headers
                worksheet.Cell(1, 1).Value = "Name";
                worksheet.Cell(1, 2).Value = "Code";
                // Write data
                for (int i = 0; i < QRVoucherModels.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = QRVoucherModels[i].Name;
                    worksheet.Cell(i + 2, 2).Value = QRVoucherModels[i].Code;
                }
                workbook.SaveAs(filePath);
            }
        }
    }
}
