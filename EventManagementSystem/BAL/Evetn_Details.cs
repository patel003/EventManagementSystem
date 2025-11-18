using EventManagementSystem.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace EventManagementSystem.BAL
{
    public class Evetn_Details
    {
        private readonly string FromName = "EMS Support";
        private readonly string FromEmail = "vp822156@gmail.com";
        private readonly string Password = "jzfz ugsg cbeo jxxz";
        private readonly string SmtpServer = "smtp.gmail.com";
        private readonly int Port = 587;

        public async Task SendEmail(EventsDetail_DTO ED)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(FromName, FromEmail));
            email.To.Add(MailboxAddress.Parse(ED.EMAIL));
            email.Subject = "Your OTP Code";

            email.Body = new TextPart(TextFormat.Html)
            {
                Text = $@"
                <div class=""container"">

  <table width=""100%"">
    <tr>
      <td width=""75px""><div class=""logotype"">Copmany</div></td>
      <td width=""300px"" style=""background: #fee977;border-left:15px solid #fff; padding-left:30px;font-size:26px;font-weight:bold;letter-spacing:-1px;"">Order confirmation</td>
      <td></td>
    </tr>
  </table> 
  <h3>Your contact details</h3>
  <table width=""100%"" style=""border-collapse: collapse;"">
    <tr>
      <td width=""180px"" class=""column-title"">Event_Name<td>
      <td class=""column-detail"">{ED.Event_Name}<td>
    </tr>
    <tr>
      <td class=""column-title"">Event_Date<td>
      <td class=""column-detail"">{ED.Event_Date}<td>
    </tr>
   
    
    <tr>
      <td class=""column-title"">Location<td>
      <td class=""column-detail"">{ED.Location}<td>
    </tr>
     <tr>
      <td class=""column-title"">Mobile_No<td>
      <td class=""column-detail"">{ED.Mobile_No}<td>
    </tr>
  </table>
 
  
  
  
</div><!-- container -->"
            };
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(SmtpServer, Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(FromEmail, Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

          

        }



    }
}
