using Common.ViewModels.QRViewModels;
using System.Net.Http.Headers;

namespace Common.Services.QRCodeServices
{
    internal class GenerateQRCodeImageAPI
    {
        public async Task<byte[]> GenerateQRCodeImage(QRCodeViewModel model,string qrCodeServerUrl)
        {
            try
            {
                string aliasUrl = "api/generateqrcode";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(qrCodeServerUrl);
                    MultipartFormDataContent dataContent = new MultipartFormDataContent();
                    dataContent.Add(new StringContent(model.Content), "Content");
                    dataContent.Add(new StringContent(model.Size.ToString()), "Size");
                    dataContent.Add(new StringContent(model.FontSize.ToString()), "FontSize");
                    dataContent.Add(new StringContent(model.TextColor), "TextColor");
                    dataContent.Add(new StringContent(model.BackgroundColor), "BackgroundColor");
                    dataContent.Add(new StringContent(model.FillColor), "FillColor");
                    dataContent.Add(new StringContent(model.Border.ToString()), "Border");
                    if (model.Text != null)
                    {
                        dataContent.Add(new StringContent(model.Text), "Text");
                    }
                    if (model.FontFamily != null)
                    {
                        dataContent.Add(new StringContent(model.FontFamily), "FontFamily");
                    }
                    if (model.Logo != null)
                    {
                        dataContent.Add(new StreamContent(model.Logo.OpenReadStream())
                        {
                            Headers =
                            {
                                ContentLength = model.Logo.Length,
                                ContentType = new MediaTypeHeaderValue(model.Logo.ContentType)
                            }
                        }, "Logo", "logoImage");
                    }

                    //var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(aliasUrl, dataContent);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsByteArrayAsync();
                    }
                    else
                    {
                        throw new Exception("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}