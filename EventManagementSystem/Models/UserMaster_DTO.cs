namespace EventManagementSystem.Models
{
    public class UserMaster_DTO
    {
        public int ID{ get; set; }
        public string FULL_NAME { get; set; }
        public string EMAIL { get; set; }
        public string PHONE_NO { get; set; }
        public string ADDRESS { get; set; }
        public int ROLE_ID { get; set; }
        public string PASS { get; set; }
        public int ISACTIVE { get; set; }
        public int ISBLOCK { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string ROLE_NAME { get; set; }
    }
}
