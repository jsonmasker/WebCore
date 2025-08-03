using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.ConvertWordToPdfServices
{
    public class ConvertWordToPdfService : IConvertWordToPdfService
    {
        private readonly ServerAppConfig _appConfig;
        public ConvertWordToPdfService(ServerAppConfig appConfig)
        {
            _appConfig = appConfig;
        }
        public async Task<byte[]> ConvertWordToPdf(string filePath)
        {
            try
            {
                string aliasUrl = "api/convertwordtopdf";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_appConfig.PythonServiceUrl);
                    MultipartFormDataContent dataContent = new MultipartFormDataContent();

                    if (string.IsNullOrEmpty(filePath))
                    {
                        throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
                    }
                    if (!File.Exists(filePath))
                    {
                        throw new FileNotFoundException("File not found.", filePath);
                    }

                    using(var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        dataContent.Add(new StreamContent(fileStream)
                        {
                            Headers =
                            {
                                ContentLength = fileStream.Length,
                                ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                            }
                        }, "file", Path.GetFileName(filePath));
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
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
