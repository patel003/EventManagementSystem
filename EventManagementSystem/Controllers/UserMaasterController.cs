using EventManagementSystem.BAL;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{

    public class UserMaasterController : Controller
    {
        // GET: UserMaasterController
        public ActionResult User()
        {
            return View();
        }

        // API FOR GetAllEvents OPERATION......
        public IActionResult GETALL()
        {
            var bal = new UserMaster_BAL();
            var response = bal.GETALL();
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<UserMaster_DTO>() });
            }
        }


        // API FOR GetById OPERATION......
        public IActionResult GetbyUserId(int ID)
        {
            var bal = new UserMaster_BAL();
            var response = bal.GetbyUserId(ID);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<UserMaster_DTO>() });
            }
        }



        // API FOR InsertUpdate OPERATION......
        [HttpPost]
        public IActionResult InsertUpdate(UserMasterRequest md)
        {
            var bal = new UserMaster_BAL();
            var response = bal.InsertUpdate(md);
            if (response.Status)
            {
                return RedirectToAction("User");
            }
            else
            {
                return RedirectToAction("User");
            }
        }


        // API FOR DELETE OPERATION......
        public IActionResult Delete(int ID)
        {
            var bal = new UserMaster_BAL();
            var response = bal.Delete(ID);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<UserMaster_DTO>() });
            }
        }

    }
}
