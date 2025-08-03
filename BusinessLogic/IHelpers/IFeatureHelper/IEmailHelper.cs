using Common.Models;

namespace BusinessLogic.IHelpers.IFeatureHelper
{
    public interface IEmailHelper
    {
        public Task<bool> SendSingleEmail(SingleMailData mailData);
        public Task<bool> SendMailAsync(MailData mailData);
        public Task<bool> SendMailWithAttachments(MailDataWithAttachments mailDataWithAttachments);
    }
}
