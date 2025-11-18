using EventManagementSystem.BAL;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    public class EventCategoryController : Controller
    {
        // GET: EventCategoryController
        public ActionResult EventCategory()
        {
            return View();
        }

        public IActionResult GETALL()
        {
            var bal = new EventCategory_BAL();
            var response = bal.GETALL();
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<EventCategory_DTO>() });
            }
        }


        // API FOR GetById OPERATION......
        public IActionResult getbyCATEGORYID(int CATEGORY_ID)
        {
            var bal = new EventCategory_BAL();
            var response = bal.CategoryID(CATEGORY_ID);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<EventCategory_DTO>() });
            }
        }



        // API FOR InsertUpdate OPERATION......
        [HttpPost]
        public IActionResult Event_Category(EventCategoryRequest md)
        {
            var bal = new EventCategory_BAL();
            var response = bal.Event_Category(md);
            if (response.Status)
            {
                return RedirectToAction("EventCategory");
            }
            else
            {
                return RedirectToAction("EventCategory");
            }
        }


        // API FOR DELETE OPERATION......
        public IActionResult Delete(int CATEGORY_ID)
        {
            var bal = new EventCategory_BAL();
            var response = bal.Delete(CATEGORY_ID);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<EventCategory_DTO>() });
            }
        }


    }
}
