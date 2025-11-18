using EventManagementSystem.Models;
using EventManagementSystem.Models.Login;
using System.Data;
using System.Data.SqlClient;

namespace EventManagementSystem.DAL
{
    public class Login_DAL
    {

        public DataTable Login(LoginModel lm)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
                {
                     new SqlParameter("@action", "login"),
                    new SqlParameter("@Email", lm.Email),
                    new SqlParameter("@Pass", lm.Pass)

                };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_LOGIN", CommandType.StoredProcedure, sqlParameters);
        }
    }
}


 