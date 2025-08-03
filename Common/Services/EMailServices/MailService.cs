using Common.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using MimeKit;
using RazorEngineCore;
using System.Text;

namespace Common.Services.EMailServices
{
    public class MailService : IMailService
    {
        private readonly ServerAppConfig _appConfig;
        public MailService(ServerAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public async Task<bool> SendAsync(MailData mailData, CancellationToken ct)
        {
            try
            {
                // if receiver is not exist, we won't send the email
                if (mailData == null || (mailData.To == null || mailData.To.Count <= 0)
                    && (mailData.Bcc == null || mailData.Bcc.Count <= 0)
                    && (mailData.Cc == null || mailData.Cc.Count <= 0))
                {
                    return false;
                }

                // Initialize a new instance of the MimeKit.MimeMessage class
                var mail = new MimeMessage();

                #region Sender / Receiver
                // Sender
                mail.From.Add(new MailboxAddress(_appConfig.DisplayName, mailData.From ?? _appConfig.From));
                mail.Sender = new MailboxAddress(mailData.DisplayName ?? _appConfig.DisplayName, mailData.From ?? _appConfig.From);

                // Receiver
                foreach (string mailAddress in mailData.To)
                    mail.To.Add(MailboxAddress.Parse(mailAddress));

                // Set Reply to if specified in mail data
                if (!string.IsNullOrEmpty(mailData.ReplyTo))
                    mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

                // BCC
                // Check if a BCC was supplied in the request
                if (mailData.Bcc != null)
                {
                    // Get only addresses where value is not null or with whitespace. x = value of address
                    foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }

                // CC
                // Check if a CC address was supplied in the request
                if (mailData.Cc != null)
                {
                    foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }
                #endregion

                #region Content

                // Add Content to Mime Message
                var body = new BodyBuilder();
                mail.Subject = mailData.Subject;
                body.HtmlBody = mailData.Body;
                mail.Body = body.ToMessageBody();

                #endregion

                #region Send Mail

                using var smtp = new SmtpClient();

                if (_appConfig.UseSSL)
                {
                    await smtp.ConnectAsync(_appConfig.Host, _appConfig.Port, SecureSocketOptions.SslOnConnect, ct);
                }
                else if (_appConfig.UseStartTls)
                {
                    await smtp.ConnectAsync(_appConfig.Host, _appConfig.Port, SecureSocketOptions.StartTls, ct);
                }
                await smtp.AuthenticateAsync(_appConfig.UserName, _appConfig.Password, ct);
                await smtp.SendAsync(mail, ct);
                await smtp.DisconnectAsync(true, ct);

                #endregion

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SendSingleEmailAsync(SingleMailData mailData, CancellationToken ct)
        {
            try
            {
                if (mailData == null)
                {
                    return false;
                }
                var mail = new MimeMessage();
                mail.From.Add(new MailboxAddress(_appConfig.DisplayName, _appConfig.From));
                mail.To.Add(MailboxAddress.Parse(mailData.To));

                // Add Content to Mime Message
                var body = new BodyBuilder();
                mail.Subject = mailData.Subject;

                // Check if we got any attachments and add the to the builder for our message
                if (mailData.Attachments != null)
                {
                    byte[] attachmentFileByteArray;
                    foreach (IFormFile attachment in mailData.Attachments)
                    {
                        if (attachment.Length > 0)
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                attachment.CopyTo(memoryStream);
                                attachmentFileByteArray = memoryStream.ToArray();
                            }
                            body.Attachments.Add(attachment.FileName, attachmentFileByteArray, ContentType.Parse(attachment.ContentType));
                        }
                    }
                }
                body.HtmlBody = mailData.Body;
                mail.Body = body.ToMessageBody();

                //initial simtp to send email
                using var smtp = new SmtpClient();
                if (_appConfig.UseSSL)
                {
                    await smtp.ConnectAsync(_appConfig.Host, _appConfig.Port, SecureSocketOptions.SslOnConnect, ct);
                }
                else if (_appConfig.UseStartTls)
                {
                    await smtp.ConnectAsync(_appConfig.Host, _appConfig.Port, SecureSocketOptions.StartTls, ct);
                }
                await smtp.AuthenticateAsync(_appConfig.UserName, _appConfig.Password, ct);
                await smtp.SendAsync(mail, ct);
                await smtp.DisconnectAsync(true, ct);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SendWithAttachmentsAsync(MailDataWithAttachments mailData, CancellationToken ct)
        {
            try
            {
                // Initialize a new instance of the MimeKit.MimeMessage class
                var mail = new MimeMessage();

                #region Sender / Receiver
                // Sender
                mail.From.Add(new MailboxAddress(_appConfig.DisplayName, mailData.From ?? _appConfig.From));
                mail.Sender = new MailboxAddress(mailData.DisplayName ?? _appConfig.DisplayName, mailData.From ?? _appConfig.From);

                // Receiver
                foreach (string mailAddress in mailData.To)
                    mail.To.Add(MailboxAddress.Parse(mailAddress));

                // Set Reply to if specified in mail data
                if (!string.IsNullOrEmpty(mailData.ReplyTo))
                    mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

                // BCC
                // Check if a BCC was supplied in the request
                if (mailData.Bcc != null)
                {
                    // Get only addresses where value is not null or with whitespace. x = value of address
                    foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }

                // CC
                // Check if a CC address was supplied in the request
                if (mailData.Cc != null)
                {
                    foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }
                #endregion

                #region Content

                // Add Content to Mime Message
                var body = new BodyBuilder();
                mail.Subject = mailData.Subject;

                // Check if we got any attachments and add the to the builder for our message
                if (mailData.Attachments != null)
                {
                    byte[] attachmentFileByteArray;
                    foreach (IFormFile attachment in mailData.Attachments)
                    {
                        if (attachment.Length > 0)
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                attachment.CopyTo(memoryStream);
                                attachmentFileByteArray = memoryStream.ToArray();
                            }
                            body.Attachments.Add(attachment.FileName, attachmentFileByteArray, ContentType.Parse(attachment.ContentType));
                        }
                    }
                }
                body.HtmlBody = mailData.Body;
                mail.Body = body.ToMessageBody();

                #endregion
                #region Send Mail

                using var smtp = new SmtpClient();

                if (_appConfig.UseSSL)
                {
                    await smtp.ConnectAsync(_appConfig.Host, _appConfig.Port, SecureSocketOptions.SslOnConnect, ct);
                }
                else if (_appConfig.UseStartTls)
                {
                    await smtp.ConnectAsync(_appConfig.Host, _appConfig.Port, SecureSocketOptions.StartTls, ct);
                }

                await smtp.AuthenticateAsync(_appConfig.UserName, _appConfig.Password, ct);
                await smtp.SendAsync(mail, ct);
                await smtp.DisconnectAsync(true, ct);

                return true;
                #endregion
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string GetEmailTemplate<T>(string emailTemplate, T emailTemplateModel)
        {
            string mailTemplate = LoadTemplate(emailTemplate);

            IRazorEngine razorEngine = new RazorEngine();
            IRazorEngineCompiledTemplate modifiedMailTemplate = razorEngine.Compile(mailTemplate);

            return modifiedMailTemplate.Run(emailTemplateModel);
        }
        private string LoadTemplate(string emailTemplate)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string templateDir = Path.Combine(baseDir, "Files/MailTemplates");
            string templatePath = Path.Combine(templateDir, $"{emailTemplate}.cshtml");

            using FileStream fileStream = new FileStream(templatePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);

            string mailTemplate = streamReader.ReadToEnd();
            streamReader.Close();

            return mailTemplate;
        }
    }
}
