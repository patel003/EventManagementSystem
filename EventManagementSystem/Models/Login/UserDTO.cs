using System.Security;

namespace EventManagementSystem.Models.Login
{
    public class UserDTO
    {
        public int ID { get; set; }

        public String  FULL_NAME { get; set; }

        public string EMAIL { get; set; }
        public String  PHONE_NO { get; set; }
        public String ADDRESS { get; set; }
        public int ROLE_ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool  ISACTIVE{ get; set; }
         public string PASS { get; set; }

       
        public string ROLE_NAME { get;  set; }
    }
}
