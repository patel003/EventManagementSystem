using EventManagementSystem.Models;
using EventManagementSystem.Models.Login;
using System.Data;
using System.Data.SqlClient;

namespace EventManagementSystem.DAL
{
    public class SignUp_DAL
    {


        public DataTable SignUp (SignUpData sr)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
                {
                     new SqlParameter("@action", "USER_REGISTRATION"),
                     new SqlParameter("@FULL_NAME", sr.FULL_NAME),
                    new SqlParameter("@EMAIL", sr.EMAIL),
                    new SqlParameter("@PASS", sr.PASS),
                    new SqlParameter("@PHONE_NO", sr.PHONE_NO),
                    new SqlParameter("@ADDRESS", sr.ADDRESS)

                };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_LOGIN", CommandType.StoredProcedure, sqlParameters);
        }
    

     }
}
