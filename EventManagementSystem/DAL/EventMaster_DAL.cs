using EventManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace EventManagementSystem.DAL
{
    public class EventMaster_DAL
    {
        // API FOR GetAllEvents OPERATION......
        public DataTable GETALL()
        {
            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","GETALL")
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Master", CommandType.StoredProcedure, sp);
        }




        // API FOR GetById OPERATION......
        public DataTable GetById(int id)
        {

            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","GetbyEventId"),
          new SqlParameter("@Event_ID",id)
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Master", CommandType.StoredProcedure, sp);
        }





        // API FOR InsertUpdate OPERATION......
        public DataTable InsertUpdate(EventMasterRequest md)
        {
            string starttime = md.Start_Time.ToString();
            string EventDate = md.Event_Date.ToString();
            string Endtime = md.End_Time.ToString();
            string Update = md.Update.ToString();

            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","CREATEUPDATE"),
                 new SqlParameter("@Event_ID",md.Event_ID),
                 new SqlParameter("@Event_Name",md.Event_Name),
                 new SqlParameter("@Event_discription",md.Event_discription),
                 new SqlParameter("@Event_category",md.Event_category),
                 new SqlParameter("@Event_Date",EventDate),
                 new SqlParameter("@Start_Time",starttime),
                 new SqlParameter("@End_Time",Endtime),
                 new SqlParameter("@Location",md.Location),
                 new SqlParameter("@Organizer",md.Organizer),
                 new SqlParameter("@Mobile_No",md.Mobile_No),
                 new SqlParameter("@Theme",md.Theme),
                 new SqlParameter("@price",md.price),
                 new SqlParameter("@Update",Update),


            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Master", CommandType.StoredProcedure, sp);
        }




        // API FOR DELETE OPERATION......
        public DataTable Delete(int id)
        {

            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","Delete"),
          new SqlParameter("@Event_ID",id)
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Master", CommandType.StoredProcedure, sp);
        }

        public DataTable getAllCategory()
        {
            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","getAllCategory")
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Master", CommandType.StoredProcedure, sp);
        }

        public DataTable InsertEvent(EventMasterRequest md)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","InsertEvent"),
                 new SqlParameter("@User_Id",md.User_Id),
                 new SqlParameter("@Event_ID",md.Event_ID),

            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Master", CommandType.StoredProcedure, sp);
        }


        public DataTable GetMyEvents(int User_Id)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","GetMyEvents"),
                 new SqlParameter("@User_Id",User_Id),
             

            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Master", CommandType.StoredProcedure, sp);
        }

        public DataTable CancelEvent(int Event_ID)
        {

            SqlParameter[] sp = new SqlParameter[]
            {
          new SqlParameter("@Action","CancelEvent"),
          new SqlParameter("@Event_ID",Event_ID)
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Master", CommandType.StoredProcedure, sp);
        }


        public DataTable BookedEvents()
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                 new SqlParameter("@Action","BookedEvents"),

            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_Event_Master", CommandType.StoredProcedure, sp);
        }
    }

}
