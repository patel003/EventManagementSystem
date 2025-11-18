using EventManagementSystem.DAL;
using EventManagementSystem.Models;
using System.Data;

namespace EventManagementSystem.BAL
{
    public class UserMaster_BAL
    {

        // API FOR GetAllEvents OPERATION......
        public CommonResponse<UserMaster_DTO> GETALL()
        {
            var resp = new CommonResponse<UserMaster_DTO>();
            try
            {
                DataTable dt = new UserMaster_DAL().GETALL();
                if (dt.Rows.Count != 0)
                {
                    List<UserMaster_DTO> dataList = new List<UserMaster_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new UserMaster_DTO
                        {

                            ID = dr.Table.Columns.Contains("ID") ? Convert.ToInt32(dr["ID"]) : 0,
                            FULL_NAME = dr.Table.Columns.Contains("FULL_NAME") ? dr["FULL_NAME"].ToString() : string.Empty,
                            EMAIL = dr.Table.Columns.Contains("EMAIL") ? dr["EMAIL"].ToString() : string.Empty,
                            PHONE_NO = dr.Table.Columns.Contains("PHONE_NO") ? dr["PHONE_NO"].ToString() : string.Empty,
                            ADDRESS = dr.Table.Columns.Contains("ADDRESS") ? dr["ADDRESS"].ToString() : string.Empty,
                            ROLE_ID = dr.Table.Columns.Contains("ROLE_ID") ? Convert.ToInt32(dr["ROLE_ID"]) : 0,
                            PASS = dr.Table.Columns.Contains("PASS") ? dr["PASS"].ToString() : string.Empty,
                            ISACTIVE = dr.Table.Columns.Contains("ISACTIVE") ? Convert.ToInt32(dr["ISACTIVE"]) : 0,
                            ISBLOCK = dr.Table.Columns.Contains("ISBLOCK") ? Convert.ToInt32(dr["ISBLOCK"]) : 0,
                            CREATED_DATE = dr["CREATED_DATE"] != DBNull.Value ? Convert.ToDateTime(dr["CREATED_DATE"]) : DateTime.MinValue,
                            ROLE_NAME = dr.Table.Columns.Contains("FULL_NAME") ? dr["FULL_NAME"].ToString() : string.Empty,


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
                    resp.Data = new List<UserMaster_DTO>();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<UserMaster_DTO>();

                return resp;
            }
        }



        // API FOR GetById OPERATION......
        public CommonResponse<UserMaster_DTO> GetbyUserId( int ID)
        {
            var resp = new CommonResponse<UserMaster_DTO>();
            try
            {
                DataTable dt = new UserMaster_DAL().GetbyUserId(ID);
                if (dt.Rows.Count != 0)
                {
                    List<UserMaster_DTO> dataList = new List<UserMaster_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new UserMaster_DTO
                        {

                            ID = dr.Table.Columns.Contains("ID") ? Convert.ToInt32(dr["ID"]) : 0,
                            FULL_NAME = dr.Table.Columns.Contains("FULL_NAME") ? dr["FULL_NAME"].ToString() : string.Empty,
                            EMAIL = dr.Table.Columns.Contains("EMAIL") ? dr["EMAIL"].ToString() : string.Empty,
                            PHONE_NO = dr.Table.Columns.Contains("PHONE_NO") ? dr["PHONE_NO"].ToString() : string.Empty,
                            ADDRESS = dr.Table.Columns.Contains("ADDRESS") ? dr["ADDRESS"].ToString() : string.Empty,
                            ROLE_ID = dr.Table.Columns.Contains("ROLE_ID") ? Convert.ToInt32(dr["ROLE_ID"]) : 0,
                            PASS = dr.Table.Columns.Contains("PASS") ? dr["PASS"].ToString() : string.Empty,
                            ISACTIVE = dr.Table.Columns.Contains("ISACTIVE") ? Convert.ToInt32(dr["ISACTIVE"]) : 0,
                            ISBLOCK = dr.Table.Columns.Contains("ISBLOCK") ? Convert.ToInt32(dr["ISBLOCK"]) : 0,
                            CREATED_DATE = dr["CREATED_DATE"] != DBNull.Value ? Convert.ToDateTime(dr["CREATED_DATE"]) : DateTime.MinValue,
                            ROLE_NAME = dr.Table.Columns.Contains("FULL_NAME") ? dr["FULL_NAME"].ToString() : string.Empty,



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
                    resp.Data = new List<UserMaster_DTO>();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<UserMaster_DTO>();

                return resp;
            }
        }
        // API FOR InsertUpdate OPERATION......

        public CommonResponse<UserMaster_DTO> InsertUpdate(UserMasterRequest md)
        {
            var resp = new CommonResponse<UserMaster_DTO>();
            try
            {
                DataTable dt = new UserMaster_DAL().CREATEUPDATE(md);
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
                    resp.Data = new List<UserMaster_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<UserMaster_DTO>();

                return resp;
            }
        }


        // API FOR DELETE OPERATION......

        public CommonResponse<UserMaster_DTO> Delete(int ID)
        {
            var resp = new CommonResponse<UserMaster_DTO>();
            try
            {
                DataTable dt = new UserMaster_DAL().Delete(ID);
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
                    resp.Data = new List<UserMaster_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<UserMaster_DTO>();

                return resp;
            }
        }

       
    }
}
