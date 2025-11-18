namespace EventManagementSystem.Models
{
    public class OtpSender_request
    {
        public int ID { get; set; }
        public string EMAIL { get; set; }
        public string OTP { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public string PASS { get; set; }

    }
}
