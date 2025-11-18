using EventManagementSystem.BAL;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    public class ResultController : Controller
    {
        // GET: ResultController
        public ActionResult Result()
        {

            var Event = new Result_BAL().GetAllEvents();
            ViewBag.CategoryData = Event;


            //var User = new Result_BAL().GetAllUsers();
            //ViewBag.JoinUser1 = User;
            return View();
        }

        public IActionResult GetAllResult()
        {
            var bal = new Result_BAL();
            var response = bal.GetAllResult();
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<Result_DTO>() });
            }
        }
        public IActionResult ResultStatus()
        {
            var bal = new Result_BAL();
            var response = bal.ResultStatus();
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<Result_DTO>() });
            }
        }

        [HttpPost]
        public IActionResult InsertResult(ResultRequest md)
        {
            var bal = new Result_BAL();
            var response = bal.InsertResult(md);
            if (response.Status)
            {
                return RedirectToAction("Result");
            }
            else
            {
                return RedirectToAction("Result");
            }
        }

        public IActionResult EditResult(int Id)
        {
            var bal = new Result_BAL();
            var response = bal.EditResult(Id);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<Result_DTO>() });
            }
        }



        public IActionResult Delete(int Id)
        {
            var bal = new Result_BAL();
            var response = bal.Delete(Id);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<Result_DTO>() });
            }
        }

        public IActionResult GetAllUserOption(int Event_ID)
        {
            var user = new Result_BAL().GetAllUsers(Event_ID);
            return Json(user);
        }
    }
}
