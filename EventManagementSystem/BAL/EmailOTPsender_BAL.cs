using EventManagementSystem.DAL;
using EventManagementSystem.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Data;

namespace EventManagementSystem.BAL
{
    public class EmailOTPsender_BAL
    {
            private readonly string FromName = "EMS Support";
            private readonly string FromEmail = "vp822156@gmail.com";
            private readonly string Password = "jzfz ugsg cbeo jxxz";
            private readonly string SmtpServer = "smtp.gmail.com";
            private readonly int Port = 587;

            public async Task SendOtpAsync(string toEMAIL, string OTP)
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(FromName, FromEmail));
                email.To.Add(MailboxAddress.Parse(toEMAIL));
                email.Subject = "Your OTP Code";

                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = $@"
                <h2 style='color:#2d89ef;'>OTP Verification</h2>
                <p>Hello,</p>
                <p>Your One-Time Password (OTP) is: <b style='font-size:20px;'>{OTP}</b></p>
                <p>This code will expire in 5 minutes.</p>
                <br/>
                <p style='font-size:12px;color:gray;'>- Sent by Eventmanagementsystem</p>"
                };
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(SmtpServer, Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(FromEmail, Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                Console.WriteLine($"OTP sent to {toEMAIL}");

            }

            public string GenerateOtp()
            {
                return new Random().Next(100000, 999999).ToString();
            }




        public CommonResponse<OtpSender_DTO> OTPSENDER(string EMAIL)
        {
            var resp = new CommonResponse<OtpSender_DTO>();
            try
            {
                OtpSender_request request = new OtpSender_request();
                request.EMAIL= EMAIL;
                request.OTP = GenerateOtp();
                SendOtpAsync(EMAIL,request.OTP);
                DataTable dt = new OtpSender_DAL().OTPSENDER(request);
                if (dt.Rows.Count != 0)
                {
                    string message = dt.Rows[0]["MSG"].ToString();
                    resp.Code = 1;
                    resp.Message = message;
                    resp.Status = true;
                    resp.Data = null;
                    return resp;
                }
                else
                {
                    resp.Code = 0;
                    resp.Message = "Response not available";
                    resp.Status = true;
                    resp.Data = new List<OtpSender_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<OtpSender_DTO>();

                return resp;
            }
        }

        public CommonResponse<OtpSender_DTO> otpverification(string EMAIL, string OTP)
        {
            var resp = new CommonResponse<OtpSender_DTO>();
            try
            {
                OtpSender_request request = new OtpSender_request();
                request.EMAIL = EMAIL;
                request.OTP = OTP;
              
                DataTable dt = new OtpSender_DAL().OTPSENDER(request);
                if (dt.Rows.Count != 0)
                {
                    string message = dt.Rows[0]["MSG"].ToString();
                    resp.Code = 1;
                    resp.Message = message;
                    resp.Status = true;
                    resp.Data = null;
                    return resp;
                }
                else
                {
                    resp.Code = 0;
                    resp.Message = "Response not available";
                    resp.Status = true;
                    resp.Data = new List<OtpSender_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<OtpSender_DTO>();

                return resp;
            }
        }


        public CommonResponse<OtpSender_DTO> UpdatePassword(string EMAIL, string PASS)
        {
            var resp = new CommonResponse<OtpSender_DTO>();
            try
            {
                OtpSender_request request = new OtpSender_request();
                request.EMAIL = EMAIL;
                request.PASS = PASS;

                DataTable dt = new OtpSender_DAL().UpdatePassword(request);
                if (dt.Rows.Count != 0)
                {
                    string message = dt.Rows[0]["MSG"].ToString();
                    resp.Code = 1;
                    resp.Message = message;
                    resp.Status = true;
                    resp.Data = null;
                    return resp;
                }
                else
                {
                    resp.Code = 0;
                    resp.Message = "Response not available";
                    resp.Status = true;
                    resp.Data = new List<OtpSender_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<OtpSender_DTO>();

                return resp;
            }
        }



    }
}

