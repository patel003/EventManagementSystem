using EventManagementSystem.DAL;
using EventManagementSystem.Models;
using System.Data;

namespace EventManagementSystem.BAL
{
    public class Result_BAL
    {
        public CommonResponse<Result_DTO> GetAllResult()
        {
            var resp = new CommonResponse<Result_DTO>();
            try
            {
                DataTable dt = new Result_DAL().GetAllResult();
                if (dt.Rows.Count != 0)
                {
                    List<Result_DTO> dataList = new List<Result_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new Result_DTO
                        {
                            Id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0,
                            Event_ID = dr["Event_ID"] != DBNull.Value ? Convert.ToInt32(dr["Event_ID"]) : 0,
                            First = dr["First"] != DBNull.Value ? dr["First"].ToString() : string.Empty,
                            Event_Name = dr["Event_Name"] != DBNull.Value ? dr["Event_Name"].ToString() : string.Empty,
                            Second = dr["Second"] != DBNull.Value ? dr["Second"].ToString() : string.Empty,
                            Third = dr["Third"] != DBNull.Value ? dr["Third"].ToString() : string.Empty,
                            Remark = dr["Remark"] != DBNull.Value ? dr["Remark"].ToString() : string.Empty,
                            Winner = dr["Winner"] != DBNull.Value ? dr["Winner"].ToString() : string.Empty,
                            CreateDate = dr["CreateDate"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["CreateDate"])) : DateOnly.MinValue,

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
                    resp.Data = new List<Result_DTO>();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<Result_DTO>();

                return resp;
            }
        }



        public CommonResponse<Result_DTO> ResultStatus()
        {
            var resp = new CommonResponse<Result_DTO>();
            try
            {
                DataTable dt = new Result_DAL().ResultStatus();
                if (dt.Rows.Count != 0)
                {
                    List<Result_DTO> dataList = new List<Result_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new Result_DTO
                        {
                            Id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0,
                            Event_ID = dr["Event_ID"] != DBNull.Value ? Convert.ToInt32(dr["Event_ID"]) : 0,
                            First = dr["First"] != DBNull.Value ? dr["First"].ToString() : string.Empty,
                            Event_Name = dr["Event_Name"] != DBNull.Value ? dr["Event_Name"].ToString() : string.Empty,
                            Second = dr["Second"] != DBNull.Value ? dr["Second"].ToString() : string.Empty,
                            Third = dr["Third"] != DBNull.Value ? dr["Third"].ToString() : string.Empty,
                            Remark = dr["Remark"] != DBNull.Value ? dr["Remark"].ToString() : string.Empty,
                            Winner = dr["Winner"] != DBNull.Value ? dr["Winner"].ToString() : string.Empty,
                            CreateDate = dr["CreateDate"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["CreateDate"])) : DateOnly.MinValue,
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
                    resp.Data = new List<Result_DTO>();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<Result_DTO>();

                return resp;
            }
        }

        public CommonResponse<Result_DTO> InsertResult(ResultRequest md)
        {
            var resp = new CommonResponse<Result_DTO>();
            try
            {
                DataTable dt = new Result_DAL().InsertResult(md);
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
                    resp.Data = new List<Result_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<Result_DTO>();

                return resp;
            }
        }


        public CommonResponse<Result_DTO> GetAllEvents()
        {
            var resp = new CommonResponse<Result_DTO>();
            try
            {
                DataTable dt = new Result_DAL().GetAllEvents();
                if (dt.Rows.Count != 0)
                {
                    List<Result_DTO> dataList = new List<Result_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new Result_DTO
                        {
                       
                            Event_ID = dr["Event_ID"] != DBNull.Value ? Convert.ToInt32(dr["Event_ID"]) : 0,
                            Event_Name = dr["Event_Name"] != DBNull.Value ? dr["Event_Name"].ToString() : string.Empty,
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
                    resp.Data = new List<Result_DTO>();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<Result_DTO>();

                return resp;
            }
        }

        public CommonResponse<Result_DTO> GetAllUsers(int Event_ID)
        {
            var resp = new CommonResponse<Result_DTO>();
            try
            {
                DataTable dt = new Result_DAL().GetAllUsers(Event_ID);
                if (dt.Rows.Count != 0)
                {
                    List<Result_DTO> dataList = new List<Result_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new Result_DTO
                        {

                            User_Id= dr["User_Id"] != DBNull.Value ? Convert.ToInt32(dr["User_Id"]) : 0,
                            FULL_NAME = dr["FULL_NAME"] != DBNull.Value ? dr["FULL_NAME"].ToString() : string.Empty,
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
                    resp.Data = new List<Result_DTO>();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<Result_DTO>();

                return resp;
            }
        }


        public CommonResponse<Result_DTO> EditResult(int Id)
        {
            var resp = new CommonResponse<Result_DTO>();
            try
            {
                DataTable dt = new Result_DAL().EditResult(Id);
                if (dt.Rows.Count != 0)
                {
                    List<Result_DTO> dataList = new List<Result_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new Result_DTO
                        {
                            Id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0,
                            Event_ID = dr["Event_ID"] != DBNull.Value ? Convert.ToInt32(dr["Event_ID"]) : 0,
                            First = dr["First"] != DBNull.Value ? dr["First"].ToString() : string.Empty,
                          
                            Second = dr["Second"] != DBNull.Value ? dr["Second"].ToString() : string.Empty,
                            Third = dr["Third"] != DBNull.Value ? dr["Third"].ToString() : string.Empty,
                            Remark = dr["Remark"] != DBNull.Value ? dr["Remark"].ToString() : string.Empty,
                            Winner = dr["Winner"] != DBNull.Value ? dr["Winner"].ToString() : string.Empty,
                            CreateDate = dr["CreateDate"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["CreateDate"])) : DateOnly.MinValue,
                            UpdatedBy = dr["UpdatedBy"] != DBNull.Value ? Convert.ToInt32(dr["UpdatedBy"]) : 0,

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
                    resp.Data = new List<Result_DTO>();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<Result_DTO>();

                return resp;
            }
        }


        public CommonResponse<Result_DTO> Delete(int Id)
        {
            var resp = new CommonResponse<Result_DTO>();
            try
            {
                DataTable dt = new Result_DAL().Delete(Id);
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
                    resp.Data = new List<Result_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<Result_DTO>();

                return resp;
            }
        }

    }
}
