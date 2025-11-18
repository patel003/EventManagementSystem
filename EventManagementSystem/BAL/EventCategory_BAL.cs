using EventManagementSystem.DAL;
using EventManagementSystem.Models;
using System.Data;

namespace EventManagementSystem.BAL
{
    public class EventCategory_BAL
    {

        public CommonResponse<EventCategory_DTO> GETALL()
        {
            var resp = new CommonResponse<EventCategory_DTO>();
            try
            {
                DataTable dt = new EventCategory_DAL().GETALL();
                if (dt.Rows.Count != 0)
                {
                    List<EventCategory_DTO> dataList = new List<EventCategory_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new EventCategory_DTO
                        {

                            CATEGORY_ID = dr.Table.Columns.Contains("CATEGORY_ID") ? Convert.ToInt32(dr["CATEGORY_ID"]) : 0,
                            CATEGORY_NAME = dr.Table.Columns.Contains("CATEGORY_NAME") ? dr["CATEGORY_NAME"].ToString() : string.Empty,
                            CREATED_DATE = dr["CREATED_DATE"] != DBNull.Value ? Convert.ToDateTime(dr["CREATED_DATE"]) : DateTime.MinValue,
                            UPDATE_DATE = dr["UPDATE_DATE"] != DBNull.Value ? Convert.ToDateTime(dr["UPDATE_DATE"]) : DateTime.MinValue,
                            CREATED_BY =  dr["CREATED_BY"] != DBNull.Value ? dr["CREATED_BY"].ToString():"",
                            ISACTIVE = dr["ISACTIVE"] != DBNull.Value ? Convert.ToInt32(dr["ISACTIVE"]) : 0,
                          DESCRIPTION = dr.Table.Columns.Contains("DESCRIPTION") ? dr["DESCRIPTION"].ToString() : string.Empty,

                        };
                        dataList.Add(dto);
                    }
                    resp.Code = 1;
                    resp.Message = "Successfully Show";
                    resp.Status = true;
                    resp.Data = dataList;
                    return resp;
                }
                else
                {
                    resp.Code = 0;
                    resp.Message = "Response not available";
                    resp.Status = true;
                    resp.Data = new List<EventCategory_DTO>();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<EventCategory_DTO>();

                return resp;
            }
        }



        // API FOR GetById OPERATION......
        public CommonResponse<EventCategory_DTO> CategoryID(int CATEGORY_ID)
        {
            var resp = new CommonResponse<EventCategory_DTO>();
            try
            {
                DataTable dt = new EventCategory_DAL().CategoryID(CATEGORY_ID);
                if (dt.Rows.Count != 0)
                {
                    List<EventCategory_DTO> dataList = new List<EventCategory_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new EventCategory_DTO
                        {


                            CATEGORY_ID = dr.Table.Columns.Contains("CATEGORY_ID") ? Convert.ToInt32(dr["CATEGORY_ID"]) : 0,
                            CATEGORY_NAME = dr.Table.Columns.Contains("CATEGORY_NAME") ? dr["CATEGORY_NAME"].ToString() : string.Empty,
                            CREATED_DATE = dr["CREATED_DATE"] != DBNull.Value ? Convert.ToDateTime(dr["CREATED_DATE"]) : DateTime.MinValue,
                            UPDATE_DATE = dr["UPDATE_DATE"] != DBNull.Value ? Convert.ToDateTime(dr["UPDATE_DATE"]) : DateTime.MinValue,
                            CREATED_BY = dr["CREATED_BY"] != DBNull.Value ? dr["CREATED_BY"].ToString() : "",
                            ISACTIVE = dr["ISACTIVE"] != DBNull.Value ? Convert.ToInt32(dr["ISACTIVE"]) : 0,
                            DESCRIPTION = dr.Table.Columns.Contains("DESCRIPTION") ? dr["DESCRIPTION"].ToString() : string.Empty,


                        };
                        dataList.Add(dto);
                    }
                    resp.Code = 1;
                    resp.Message = "Successfully Show";
                    resp.Status = true;
                    resp.Data = dataList;
                    return resp;
                }
                else
                {
                    resp.Code = 0;
                    resp.Message = "Response not available";
                    resp.Status = true;
                    resp.Data = new List<EventCategory_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<EventCategory_DTO>();

                return resp;
            }
        }




        // API FOR InsertUpdate OPERATION......
        public CommonResponse<EventCategory_DTO> Event_Category(EventCategoryRequest md)
        {
            var resp = new CommonResponse<EventCategory_DTO>();
            try
            {
                DataTable dt = new EventCategory_DAL().Event_Category(md);
                if (dt.Rows.Count != 0)
                {
                    string message = dt.Rows[0]["MSG"].ToString();
                    resp.Code = 1;
                    resp.Message = message;
                    resp.Status = true;
                    resp.Data = null;
                    return resp;
                }
                else
                {
                    resp.Code = 0;
                    resp.Message = "Response not available";
                    resp.Status = true;
                    resp.Data = new List<EventCategory_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<EventCategory_DTO>();

                return resp;
            }
        }


        // API FOR DELETE OPERATION......

        public CommonResponse<EventCategory_DTO> Delete(int CATEGORY_ID)
        {
            var resp = new CommonResponse<EventCategory_DTO>();
            try
            {
                DataTable dt = new EventCategory_DAL().Delete(CATEGORY_ID);
                if (dt.Rows.Count != 0)
                {
                    string message = dt.Rows[0]["MSG"].ToString();
                    resp.Code = 1;
                    resp.Message = message;
                    resp.Status = true;
                    resp.Data = null;
                    return resp;
                }
                else
                {
                    resp.Code = 0;
                    resp.Message = "Response not available";
                    resp.Status = true;
                    resp.Data = new List<EventCategory_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<EventCategory_DTO>();

                return resp;
            }
        }
    }
}
