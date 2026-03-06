using EventManagementSystem.BAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashboardController
        public ActionResult Dashboard()
        {

         
            return View() ;
        }

        [HttpGet]
        public IActionResult PieChart()
        {
            int UserIdforchart = 0;
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.UserId = userId;
            int role = Convert.ToInt32(User.FindFirstValue("RoleId"));
            ViewBag.Role = role;
            if (role == 3)
            {
                UserIdforchart = userId;
            }

            Dashboard_BAL _BAL = new Dashboard_BAL();
            var response = _BAL.PieChart(UserIdforchart);
            return Json(response);
        }

        [HttpGet]
        public IActionResult DonutChart()
        {
            int UserIdforchart = 0;
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.UserId = userId;
            int role = Convert.ToInt32(User.FindFirstValue("RoleId"));
            ViewBag.Role = role;
            if (role == 3)
            {
                UserIdforchart = userId;
            }


            Dashboard_BAL _BAL = new Dashboard_BAL();
            var response = _BAL.DonutChart(UserIdforchart);
            return Json(response);


        }

        [HttpGet]
        public IActionResult AreaChart()
        {
            int UserIdforchart = 0;
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.UserId = userId;
            int role = Convert.ToInt32(User.FindFirstValue("RoleId"));
            ViewBag.Role = role;
            if (role == 3)
            {
                UserIdforchart = userId;
            }

            Dashboard_BAL _BAL = new Dashboard_BAL();
            var response = _BAL.AreaChart(UserIdforchart);
            return Json(response);
        }

        [HttpGet]
        public IActionResult ColumnChart()
        {
            int UserIdforchart = 0;
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.UserId = userId;
            int role = Convert.ToInt32(User.FindFirstValue("RoleId"));
            ViewBag.Role = role;
            if (role == 3)
            {
                UserIdforchart = userId;
            }


            Dashboard_BAL _BAL = new Dashboard_BAL();
            var response = _BAL.ColumnChart(UserIdforchart);
            return Json(response);
        }
    }
}
