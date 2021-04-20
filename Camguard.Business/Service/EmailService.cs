using Camguard.Business.IContract;
using Skylight.DAL;
using Skylight.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Camguard.Business.Service
{
    public class EmailService: IEmailService
    {
        public async Task SendMail(UnitOfWork service, string subject, string entityID, string message, Module module, byte[] file, string fileName)
        {
            string RecipientName = "";
            string RecipientEmail = "";

            var emailSettings = service.EmailSettingsRepository.Get().FirstOrDefault();
            var emailAccount = await service.EmailAccountRepository.GetByIDAsync(module);

            switch (module)
            {
                case Module.Company:
                    var clientId = Convert.ToInt32(entityID);
                    var client = await service.CompanyRepository.GetByIDAsync(clientId);
                    RecipientEmail = client.Email;
                    RecipientName = client.CompanyName;
                    break;
                case Module.Employee:
                    var employeeId = Convert.ToInt32(entityID);
                    var employee = await service.EmployeeRepository.GetByIDAsync(employeeId);
                    RecipientEmail = employee.Email;
                    RecipientName = $"{employee.Surname} {employee.OtherName}";
                    break;
                case Module.Capitation:
                    var providerId = Convert.ToInt32(entityID);
                    var provider = await service.ProviderRepository.GetByIDAsync(providerId);
                    RecipientEmail = provider.Email;
                    //RecipientEmail = "kins4swagg@gmail.com";
                    RecipientName = $"{provider.ProviderName}";
                    break;
                case Module.Provider:
                    var proId = Convert.ToInt32(entityID);
                    var pro = await service.ProviderRepository.GetByIDAsync(proId);
                    RecipientEmail = pro.Email;
                    RecipientName = pro.ProviderName;
                    break;
                case Module.Claim:
                    var providerIdClaims = Convert.ToInt32(entityID);
                    var providerClaims = await service.ProviderRepository.GetByIDAsync(providerIdClaims);
                    break;

            }
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(emailSettings.Host);

                mail.From = new MailAddress(emailAccount.EmailAddress);
                mail.To.Add(RecipientEmail);
                mail.Subject = subject;
                mail.Body = message;
                if (file != null)
                {
                    MemoryStream ms = new MemoryStream(file);

                    ms.Position = 0;
                    var contentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                    Attachment attachment = new Attachment(ms, contentType);
                    attachment.ContentDisposition.FileName = fileName;
                    mail.Attachments.Add(attachment);
                }

                SmtpServer.Port = emailSettings.Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(emailAccount.EmailAddress, emailAccount.Password);
                SmtpServer.EnableSsl = emailSettings.Ssl;
                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
            }

        }
    }

}
