using BusinessLogic.IHelpers.IFeatureHelper;
using Common.Models;
using Common.Services.EMailServices;

namespace BusinessLogic.Helpers.FeatureHelpers
{
    public class EmailHelper : IEmailHelper
    {
        private IMailService _mailService;
        public EmailHelper(IMailService mailService)
        {
            _mailService = mailService;
        }
        public async Task<bool> SendSingleEmail(SingleMailData mailData)
        {
            bool result = await _mailService.SendSingleEmailAsync(mailData, new CancellationToken());
            if (!result)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> SendMailAsync(MailData mailData)
        {
            bool result = await _mailService.SendAsync(mailData, new CancellationToken());
            if (!result)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> SendMailWithAttachments(MailDataWithAttachments mailDataWithAttachments)
        {
            bool result = await _mailService.SendWithAttachmentsAsync(mailDataWithAttachments, new CancellationToken());
            if (!result)
            {
                return false;
            }
            return true;
        }
    }
}
