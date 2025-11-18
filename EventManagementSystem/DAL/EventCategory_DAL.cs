using EventManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace EventManagementSystem.DAL
{
    public class EventCategory_DAL
    {

        public DataTable GETALL()
        {
            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","GETALL")
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Category", CommandType.StoredProcedure, sp);
        }




        // API FOR GetById OPERATION......
        public DataTable CategoryID(int id)
        {

            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","getbyCATEGORYID"),
          new SqlParameter("@CATEGORY_ID",id)
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Category", CommandType.StoredProcedure, sp);
        }





        // API FOR InsertUpdate OPERATION......
        public DataTable Event_Category(EventCategoryRequest md)
        {

            string CREATED_DATE = md.CREATED_DATE.ToString();
            string UPDATE_DATE = md.UPDATE_DATE.ToString();
          
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","Event_Category"),
                 new SqlParameter("@CATEGORY_ID",md.CATEGORY_ID),
                 new SqlParameter("@CATEGORY_NAME",md.CATEGORY_NAME),
                 new SqlParameter("@CREATED_DATE",CREATED_DATE),
                 new SqlParameter("@UPDATE_DATE",UPDATE_DATE),
                 new SqlParameter("@CREATED_BY", md.CREATED_BY),
                 new SqlParameter("@ISACTIVE",md.ISACTIVE),
                 new SqlParameter("@DESCRIPTION",md.DESCRIPTION)
               

            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Category", CommandType.StoredProcedure, sp);
        }




        // API FOR DELETE OPERATION......
        public DataTable Delete(int id)
        {

            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","Delete"),
          new SqlParameter("@CATEGORY_ID",id)
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Category", CommandType.StoredProcedure, sp);
        }

        internal DataTable Event_Category(EventMasterRequest md)
        {
            throw new NotImplementedException();
        }
    }
}
