namespace EventManagementSystem.Models
{
    public class ResultRequest
    {
        public int Id { get; set; }
        public int Event_ID { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
        public string Winner { get; set; }
        public DateOnly CreateDate { get; set; }
        public int UpdatedBy { get; set; }
        public string Remark { get; set; }
        public string Event_Name { get; set; }

        public int User_Id { get; set; }
        public string FULL_NAME { get; set; }
   

    }
}
