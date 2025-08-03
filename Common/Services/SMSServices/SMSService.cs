using Newtonsoft.Json;
using System.Text;


namespace Common.Services.SMSServices
{
    public class SMSService : ISMSService
    {
        public async Task<bool> SendSMSAsync(string phoneNumber, string message)
        {
            try
            {
                //using var client = new HttpClient();
                //client.BaseAddress = new Uri("https://ypyxdp.api.infobip.com");
                //client.DefaultRequestHeaders.Add("Authorization", "App d24436362338095186ace0d883aba666-b9573b4e-2ae2-4dc1-adb7-8a04e6d02d89");
                //client.DefaultRequestHeaders.Add("Accept", "application/json");

                //var body = new
                //{
                //    messages = new[]
                //    {
                //        new
                //        {
                //            destinations = new[]
                //            {
                //                new { to = "84704469237" }
                //            },
                //            from = "ServiceSMS",
                //            text = message
                //        }
                //    }
                //};
                //var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                //var response = await client.PostAsync("/sms/2/text/advanced", content);
                //var responseContent = await response.Content.ReadAsStringAsync();

                //return response.IsSuccessStatusCode;
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error sending SMS: {ex.Message}");
                return false;
            }
        }
    }
}
