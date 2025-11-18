namespace EventManagementSystem.Models
{
    public class EventCategory_DTO
    {
        public int CATEGORY_ID { get; set; }
        public string? CATEGORY_NAME { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public string? CREATED_BY { get; set; }
        public int? ISACTIVE { get; set; }

        public string DESCRIPTION { get; set; }
    }
}
