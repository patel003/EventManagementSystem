using EventManagementSystem.BAL;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;

namespace EventManagementSystem.Controllers
{
    public class EventMasterController : Controller
    {
        // GET: EventMasterController1
        public ActionResult Event()
        {
           
            var result = new EventMaster_BAL().getAllCategory();
            ViewBag.AllCategory = result;
            return View();
        }

        public ActionResult BookedEvent()
        {

            return View();

        }

        // API FOR GetAllEvents OPERATION......
        public IActionResult GetAllEvents()
        {
            var bal = new EventMaster_BAL();
            var response = bal.GETALL();
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<EventMaster_DTO>() });
            }
        }


        // API FOR GetById OPERATION......
        public IActionResult GetAllEventID(int Event_ID)
        {
            var bal = new EventMaster_BAL();
            var response = bal.GetById(Event_ID);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<EventMaster_DTO>() });
            }
        }



        // API FOR InsertUpdate OPERATION......
        [HttpPost]
        public IActionResult InsertUpdate(EventMasterRequest md)
        {
            var bal = new EventMaster_BAL();
            var response = bal.InsertUpdate(md);
            if (response.Status)
            {
                return RedirectToAction("Event");
            }
            else
            {
                return RedirectToAction("Event");
            }
        }


        // API FOR DELETE OPERATION......
        public IActionResult Delete(int Event_ID)
        {
            var bal = new EventMaster_BAL();
            var response = bal.Delete(Event_ID);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<EventMaster_DTO>() });
            }
        }

        public IActionResult AllEvents()
        {

            var result = new EventMaster_BAL().GETALL();
            ViewBag.GETALL = result;
            return View();
        }

        public IActionResult MyEvents()
        {

            int userID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var response = new EventMaster_BAL().GetMyEvents(userID);
            //ViewBag.GETALL = response;
            var Events = response.Status ? response.Data : new List<EventMaster_DTO>();
            return View(Events);
        }


        [HttpPost]
        public IActionResult InsertEvent(int Event_ID)
        {
            EventMasterRequest request = new EventMasterRequest();
            int User_Id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            string EMAIL= User.FindFirstValue(ClaimTypes.Email);
            request.Event_ID = Event_ID;
            request.User_Id = User_Id;
            request.EMAIL = EMAIL;
            var bal = new EventMaster_BAL();
            var response = bal.InsertEvent(request);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<EventMaster_DTO>() });
            }
        }

        [HttpGet]
        public IActionResult GetMyEvents()
        {
            var User_Id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var response= new EventMaster_BAL().GetMyEvents(User_Id);
           

            return Json(new
            {
                code = response.Status,
                message = response.Message,
                data = response.Data
            });
        }


        public IActionResult CancelEvent(int Event_ID)
        {
            var bal = new EventMaster_BAL();
            var response = bal.CancelEvent(Event_ID);
            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<EventMaster_DTO>() });
            }
        }

        public IActionResult BookedEvents()
        {
            var User_Id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var response = new EventMaster_BAL().BookedEvents();

            if (response.Status)
            {
                return Json(new { code = response.Code, message = response.Message, data = response.Data });
            }
            else
            {
                return Json(new { code = response.Code, message = response.Message, data = new List<EventMaster_DTO>() });
            }
        }

    }
}
 