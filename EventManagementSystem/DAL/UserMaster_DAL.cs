using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace EventManagementSystem.DAL
{
    public class UserMaster_DAL
    {
        public DataTable GETALL()
        {
            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","GETALL")
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("User_Management", CommandType.StoredProcedure, sp);
        }




        // API FOR GetById OPERATION......
        public DataTable GetbyUserId(int id)
        {

            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","GetbyUserId"),
          new SqlParameter("@ID",id)
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("User_Management", CommandType.StoredProcedure, sp);
        }





        // API FOR InsertUpdate OPERATION......
        public DataTable CREATEUPDATE(UserMasterRequest md)
        {

            string CREATED_DATE = md.CREATED_DATE.ToString();

            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","CREATEUPDATE"),
                 new SqlParameter("@ID",md.ID),
                 new SqlParameter("@FULL_NAME",md.FULL_NAME),
                 new SqlParameter("@EMAIL",md.EMAIL),
                 new SqlParameter("@PHONE_NO",md.PHONE_NO),
                 new SqlParameter("@ADDRESS",md.ADDRESS),
                 new SqlParameter("@ROLE_ID",md.ROLE_ID),
                 new SqlParameter("@ISACTIVE",md.ISACTIVE),
                 new SqlParameter("@ISBLOCK",md.ISBLOCK),
                 new SqlParameter("@PASS",md.PASS),
                 
                 new SqlParameter("@CREATED_DATE",CREATED_DATE),
                

            };
            return DataHelper.ExecuteParameterisedDatatableCommand("User_Management", CommandType.StoredProcedure, sp);
        }




        // API FOR DELETE OPERATION......
        public DataTable Delete(int id)
        {

            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","Delete"),
          new SqlParameter("@ID",id)
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("User_Management", CommandType.StoredProcedure, sp);
        }
    }
}
