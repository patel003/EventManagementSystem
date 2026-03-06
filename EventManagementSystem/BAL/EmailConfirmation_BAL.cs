using EventManagementSystem.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace EventManagementSystem.BAL
{
    public class EventConfirmationMail_BAL
    {
        private readonly string FromName = "EMS Support";
        private readonly string FromEmail = "vp822156@gmail.com";
        private readonly string Password = "jzfz ugsg cbeo jxxz";
        private readonly string SmtpServer = "smtp.gmail.com";
        private readonly int Port = 587;

        public async Task EventMailConfirmationAsync(EmailConfirmation_DTO dTO)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(FromName, FromEmail));
            email.To.Add(MailboxAddress.Parse(dTO.EMAIL));
            email.Subject = "Your OTP Code";

            email.Body = new TextPart(TextFormat.Html)
            {
                Text = $@"
               <div class=""container"">

                      <table width=""100%"">
                        <tr>
                          <td width=""75px""><div class=""logotype"">EMS</div></td>
                          <td width=""300px"" style=""background: #fee977;border-left:15px solid #fff; padding-left:30px;font-size:26px;font-weight:bold;letter-spacing:-1px;"">Order confirmation</td>
                          <td></td>
                        </tr>
                      </table> 
                      <h3>Your contact details</h3>
                      <table width=""100%"" style=""border-collapse: collapse;"">
                        <tr>
                          <td width=""180px"" class=""column-title"">Event Name<td>
                          <td class=""column-detail"">{dTO.Event_Name}<td>
                        </tr>
                        <tr>
                          <td class=""column-title"">Date<td>
                          <td class=""column-detail"">{dTO.Event_Date}<td>
                        </tr>
                        <tr>
                          <td class=""column-title"">Description<td>
                          <td class=""column-detail"">{dTO.Event_discription}<td>
                        </td>
                        <tr>
                          <td class=""column-title"">Location<td>
                          <td class=""column-detail"">{dTO.Location}<td>
                        </tr>
                          <tr>
                          <td class=""column-title"">Price<td>
                          <td class=""column-detail"">{dTO.price}<td>
                        </tr>
                      </table>
                       "
            };
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(SmtpServer, Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(FromEmail, Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);



        }

        public async Task EventResultDeclareMailAsync(string Email, EventMaster_DTO dTO)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(FromName, FromEmail));
            email.To.Add(MailboxAddress.Parse(Email));
            email.Subject = $"Result Declared for {dTO.Event_Name}";

            email.Body = new TextPart(TextFormat.Html)
            {
                Text = $@"
                <div style='font-family:Arial,sans-serif;'>
                    <h2>Congratulations!</h2>
                    <p>The result for the event <b>{dTO.Event_Name}</b> has been declared.</p>

                    <h3>Event Details</h3>
                    <table style='border-collapse:collapse;'>
                        <tr><td><b>Date:</b></td><td>{dTO.Event_Date}</td></tr>
                        <tr><td><b>Description:</b></td><td>{dTO.Event_discription}</td></tr>
                        <tr><td><b>Location:</b></td><td>{dTO.Location}</td></tr>
                        <tr><td><b>Price:</b></td><td>{dTO.price}</td></tr>
                    </table>

                    <p>Check your dashboard for more details.</p>
                    <br/>
                    <p>– EMS Team</p>
                </div>"
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(SmtpServer, Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(FromEmail, Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }






    }
}