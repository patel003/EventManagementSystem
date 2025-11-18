using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventManagementSystem.Models
{
    public class EventMasterRequest
    {

       
        public int User_Id { get; set; }
        public int Event_ID { get; set; }
        public string Event_Name { get; set; }
        public string Event_discription { get; set; }
        public int Event_category { get; set; }
        public DateOnly Event_Date { get; set; }
        public TimeOnly Start_Time { get; set; }
        public TimeOnly End_Time { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        public string Mobile_No { get; set; }
        public string Theme { get; set; }
        public int IsActive { get; set; }
        public DateOnly? Created_Date { get; set; }
        public decimal price { get; set; }
        public string EMAIL { get; set; }

        public DateOnly Update { get; set; }


        public string ResultStatus { get; set; }


    }
}
