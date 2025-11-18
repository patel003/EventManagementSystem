using EventManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace EventManagementSystem.DAL
{
    public class OtpSender_DAL
    {

        public DataTable OTPSENDER(OtpSender_request md)
        {

            string CreateDate = md.CREATE_DATE.ToString();


            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","OTPSENDER"),
                 new SqlParameter("@ID",md.ID),
                 new SqlParameter("@EMAIL",md.EMAIL),
                 new SqlParameter("@OTP",md.OTP),
                 new SqlParameter("@PASS",md.PASS),
               
                 new SqlParameter("@CREATE_DATE", CreateDate),



            };
            return DataHelper.ExecuteParameterisedDatatableCommand("OtpSender", CommandType.StoredProcedure, sp);
        }


        public DataTable otpverification(OtpSender_request md)
        {

            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","otpverification"), 
                 new SqlParameter("@EMAIL",md.EMAIL),
                 new SqlParameter("@OTP",md.OTP), 
                
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("OtpSender", CommandType.StoredProcedure, sp);
        }

        public DataTable UpdatePassword(OtpSender_request md)
        {

            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","UpdatePassword"),
                 new SqlParameter("@EMAIL",md.EMAIL),
                 new SqlParameter("@PASS",md.PASS),

            };
            return DataHelper.ExecuteParameterisedDatatableCommand("OtpSender", CommandType.StoredProcedure, sp);
        }


    }
}
