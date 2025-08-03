using Common.Models;

namespace Common.Services.EMailServices
{
    public interface IMailService
    {
        Task<bool> SendSingleEmailAsync(SingleMailData mailData, CancellationToken ct);
        Task<bool> SendAsync(MailData mailData, CancellationToken ct);
        Task<bool> SendWithAttachmentsAsync(MailDataWithAttachments mailData, CancellationToken ct);
        string GetEmailTemplate<T>(string emailTemplate, T emailTemplateModel);

    }
}
