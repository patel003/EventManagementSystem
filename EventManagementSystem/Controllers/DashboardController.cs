using EventManagementSystem.BAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashboardController
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PieChart()
        {
            Dashboard_BAL _BAL = new Dashboard_BAL();
            var response = _BAL.PieChart();
            return Json(response);
        }

        [HttpGet]
        public IActionResult DonutChart()
        {
            Dashboard_BAL _BAL = new Dashboard_BAL();
            var response = _BAL.DonutChart();
            return Json(response);
        }

        [HttpGet]
        public IActionResult AreaChart()
        {
            Dashboard_BAL _BAL = new Dashboard_BAL();
            var response = _BAL.AreaChart();
            return Json(response);
        }

        [HttpGet]
        public IActionResult ColumnChart()
        {
            Dashboard_BAL _BAL = new Dashboard_BAL();
            var response = _BAL.ColumnChart();
            return Json(response);
        }
    }
}
