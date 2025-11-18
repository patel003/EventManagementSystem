using EventManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace EventManagementSystem.DAL
{
    public class Result_DAL
    {

        public DataTable GetAllResult()
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","GetAllResult"),

            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Result", CommandType.StoredProcedure, sp);
        }

        public DataTable ResultStatus()
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","ResultStatus"),

            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Result", CommandType.StoredProcedure, sp);
        }

        public DataTable InsertResult(ResultRequest md)
        {

            string CreateDate = md.CreateDate.ToString();


            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","InsertResult"),
                 new SqlParameter("@Id",md.Id),
                 new SqlParameter("@Event_ID",md.Event_ID),
                 new SqlParameter("@First",md.First),
                 new SqlParameter("@Second",md.Second),
                 new SqlParameter("@Third",md.Third),
                 new SqlParameter("@Winner",md.Winner),
                 new SqlParameter("@UpdatedBy",md.UpdatedBy),
                 new SqlParameter("@Remark",md.Remark),
                 new SqlParameter("@CreateDate",CreateDate),



            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Result", CommandType.StoredProcedure, sp);
        }




        public DataTable GetAllEvents()
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","GetAllEvents"),

            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Result", CommandType.StoredProcedure, sp);
        }



        public DataTable GetAllUsers(int Event_ID)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","GetAllUsers"),
                 new SqlParameter("@Event_ID",Event_ID),

            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Result", CommandType.StoredProcedure, sp);
        }

        public DataTable Delete(int Id)
        {

            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","Delete"),
          new SqlParameter("@Id",Id)
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Result", CommandType.StoredProcedure, sp);
        }

        public DataTable EditResult(int Id)
        {

            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","EditResult"),
          new SqlParameter("@Id",Id)
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Result", CommandType.StoredProcedure, sp);
        }

    }

}
