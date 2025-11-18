using EventManagementSystem.BAL;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    public class OTPController : Controller
    {
        // GET: OTPController
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult OTPSENDER(string EMAIL )
        {
            var bal = new EmailOTPsender_BAL();
            var response = bal.OTPSENDER(EMAIL);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<OtpSender_DTO>() });
            }
        }
        [HttpPost]
        public IActionResult otpverification(string EMAIL ,string OTP)
        {
            var bal = new EmailOTPsender_BAL();
            var response = bal.otpverification(EMAIL ,OTP );
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<OtpSender_DTO>() });
            }
        }
        [HttpPost]
        public IActionResult UpdatePassword(string EMAIL, string PASS)
        {
            var bal = new EmailOTPsender_BAL();
            var response = bal.UpdatePassword(EMAIL, PASS);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<OtpSender_DTO>() });
            }
        }
    }

        
}
