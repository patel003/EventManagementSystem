using EventManagementSystem.BAL;
using EventManagementSystem.Models;
using EventManagementSystem.Models.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace EventManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        private object user;

        // GET: AuthController
        public ActionResult Login()
        {
            if (TempData["Status"] != null)
            {
                ViewBag.Message = TempData["Message"];
                ViewBag.Status = TempData["Status"];
            }
           
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginViaPin(LoginModel lm)
        {
            var User = new Login_BAL().login(lm);
            if (User.Status == true)
            {
                // Create the identity with your userId
                var claims = new List<Claim>
                {
                 new Claim(ClaimTypes.NameIdentifier,User.Data[0].ID.ToString()),
               
                 new Claim(ClaimTypes.Name, User.Data[0].FULL_NAME.ToString()),
                 new Claim(ClaimTypes.Email, User.Data[0].EMAIL.ToString()),
                 new Claim("RoleId", User.Data[0].ROLE_ID.ToString()),
                 new Claim(ClaimTypes.Actor,User.Data[0].ROLE_NAME.ToString()),
                 new Claim(ClaimTypes.Role, User.Data[0].ROLE_ID == 1 ? "Admin" : "Guest")

                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                return RedirectToAction("DashBoard", "DashBoard");
            }
            else
            {
                TempData["Message"] = User.Message;
                TempData["Status"] = false;

                return RedirectToAction("Login", "Auth");
            }
        }

        // optional for form logout
        public ActionResult Logout()
        {
            // Clears the existing external cookie and claims
             HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }

       public IActionResult USER_REGISTRATION(SignUpData sr)
        {
            var bal = new SignUp_BAL();
            var response = bal.SignUp(sr);

            return RedirectToAction("Login", "Auth");
        }

    }



    
}




