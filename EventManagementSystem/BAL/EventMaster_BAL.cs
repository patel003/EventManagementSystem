using EventManagementSystem.DAL;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using System.Data;

namespace EventManagementSystem.BAL
{
    public class EventMaster_BAL
    {

        // API FOR GetAllEvents OPERATION......
        public CommonResponse<EventMaster_DTO> GETALL()
        {
            var resp = new CommonResponse<EventMaster_DTO>();
            try
            {
                DataTable dt = new EventMaster_DAL().GETALL();
                if (dt.Rows.Count != 0)
                {
                    List<EventMaster_DTO> dataList = new List<EventMaster_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new EventMaster_DTO
                        {

                            Event_ID = dr.Table.Columns.Contains("Event_ID") ? Convert.ToInt32(dr["Event_ID"]) : 0,
                            Event_Name = dr.Table.Columns.Contains("Event_Name") ? dr["Event_Name"].ToString() : string.Empty,
                            Event_discription = dr.Table.Columns.Contains("Event_discription") ? dr["Event_discription"].ToString() : string.Empty,
                            Event_category = dr.Table.Columns.Contains("Event_category") ? Convert.ToInt32(dr["Event_category"]) : 0,
                            Event_Date = dr["Event_Date"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["Event_Date"])) : DateOnly.MinValue,
                            Start_Time = dr["Start_Time"] != DBNull.Value ? TimeOnly.FromDateTime(Convert.ToDateTime(dr["Start_Time"])) : TimeOnly.MinValue,
                            End_Time = dr["End_Time"] != DBNull.Value ? TimeOnly.FromDateTime(Convert.ToDateTime(dr["End_Time"])) : TimeOnly.MinValue,
                            Location = dr.Table.Columns.Contains("Location") ? dr["Location"].ToString() : string.Empty,
                            Organizer = dr.Table.Columns.Contains("Organizer") ? dr["Organizer"].ToString() : string.Empty,
                            Mobile_No = dr.Table.Columns.Contains("Mobile_No") ? dr["Mobile_No"].ToString() : string.Empty,
                            Theme = dr.Table.Columns.Contains("Theme") ? dr["Theme"].ToString() : string.Empty,
                            IsActive = dr.Table.Columns.Contains("IsActive") ? Convert.ToInt32(dr["IsActive"]) : 0,
                            Created_Date = dr["Created_Date"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["Created_Date"])) : DateOnly.MinValue,
                            price = dr["price"] != DBNull.Value ? Convert.ToDecimal(dr["price"]) : decimal.MinValue,
                            Update = dr["Update"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["Update"])) : DateOnly.MinValue,

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
                    resp.Data = new List<EventMaster_DTO>();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<EventMaster_DTO>();

                return resp;
            }
        }



        // API FOR GetById OPERATION......
        public CommonResponse<EventMaster_DTO> GetById(int Event_ID)
        {
            var resp = new CommonResponse<EventMaster_DTO>();
            try
            {
                DataTable dt = new EventMaster_DAL().GetById(Event_ID);
                if (dt.Rows.Count != 0)
                {
                    List<EventMaster_DTO> dataList = new List<EventMaster_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new EventMaster_DTO
                        {

                            Event_ID = dr.Table.Columns.Contains("Event_ID") ? Convert.ToInt32(dr["Event_ID"]) : 0,
                            Event_Name = dr.Table.Columns.Contains("Event_Name") ? dr["Event_Name"].ToString() : string.Empty,
                            Event_discription = dr.Table.Columns.Contains("Event_discription") ? dr["Event_discription"].ToString() : string.Empty,
                            Event_category = dr.Table.Columns.Contains("Event_category") ? Convert.ToInt32(dr["Event_category"]) : 0,
                            Event_Date = dr["Event_Date"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["Event_Date"])) : DateOnly.MinValue,
                            Start_Time = dr["Start_Time"] != DBNull.Value ? TimeOnly.FromDateTime(Convert.ToDateTime(dr["Start_Time"])) : TimeOnly.MinValue,
                            End_Time = dr["End_Time"] != DBNull.Value ? TimeOnly.FromDateTime(Convert.ToDateTime(dr["End_Time"])) : TimeOnly.MinValue,
                            Location = dr.Table.Columns.Contains("Location") ? dr["Location"].ToString() : string.Empty,
                            Organizer = dr.Table.Columns.Contains("Organizer") ? dr["Organizer"].ToString() : string.Empty,
                            Mobile_No = dr.Table.Columns.Contains("Mobile_No") ? dr["Mobile_No"].ToString() : string.Empty,
                            Theme = dr.Table.Columns.Contains("Theme") ? dr["Theme"].ToString() : string.Empty,
                            IsActive = dr.Table.Columns.Contains("IsActive") ? Convert.ToInt32(dr["IsActive"]) : 0,
                            Created_Date = dr["Created_Date"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["Created_Date"])) : DateOnly.MinValue,
                            price = dr["price"] != DBNull.Value ? Convert.ToDecimal(dr["price"]) : decimal.MinValue,
                            Update = dr["Update"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["Update"])) : DateOnly.MinValue,


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
                    resp.Data = new List<EventMaster_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<EventMaster_DTO>();

                return resp;
            }
        }




        // API FOR InsertUpdate OPERATION......
        public CommonResponse<EventMaster_DTO> InsertUpdate(EventMasterRequest md)
        {
            var resp = new CommonResponse<EventMaster_DTO>();
            try
            {
                DataTable dt = new EventMaster_DAL().InsertUpdate(md);
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
                    resp.Data = new List<EventMaster_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<EventMaster_DTO>();

                return resp;
            }
        }


        // API FOR DELETE OPERATION......

        public CommonResponse<EventMaster_DTO> Delete(int Event_ID)
        {
            var resp = new CommonResponse<EventMaster_DTO>();
            try
            {
                DataTable dt = new EventMaster_DAL().Delete(Event_ID);
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
                    resp.Data = new List<EventMaster_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<EventMaster_DTO>();

                return resp;
            }
        }


        public CommonResponse<EventCategory_DTO> getAllCategory()
        {
            var resp = new CommonResponse<EventCategory_DTO>();
            try
            {
                DataTable dt = new EventMaster_DAL().getAllCategory();
                if (dt.Rows.Count != 0)
                {
                    List<EventCategory_DTO> dataList = new List<EventCategory_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new EventCategory_DTO
                        {

                            CATEGORY_ID = dr.Table.Columns.Contains("CATEGORY_ID") ? Convert.ToInt32(dr["CATEGORY_ID"]) : 0,
                            CATEGORY_NAME = dr.Table.Columns.Contains("CATEGORY_NAME") ? dr["CATEGORY_NAME"].ToString() : string.Empty,

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


        public CommonResponse<EventMaster_DTO> InsertEvent(EventMasterRequest md)
        {
            var resp = new CommonResponse<EventMaster_DTO>();
            try
            {


                if (md.User_Id == 0)
                {
                    throw new Exception("UserId missing");
                }
                EventMaster_DAL DAL = new EventMaster_DAL();
                DataTable dt = new EventMaster_DAL().InsertEvent(md);

                if (dt.Rows.Count != 0)
                {
                    string message = dt.Rows[0]["MSG"].ToString();
                    if (message == "You already  join this event")
                    {
                        resp.Code = 0;
                        resp.Message = message;
                        resp.Status = false;
                        resp.Data = new List<EventMaster_DTO>();
                        return resp;

                    }
                    else
                    {

                        List<EventsDetail_DTO> dataList = new List<EventsDetail_DTO>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            var dto = new EventsDetail_DTO
                            {


                                Event_Name = dr.Table.Columns.Contains("Event_Name") ? dr["Event_Name"].ToString() : string.Empty,


                                Event_Date = dr["Event_Date"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["Event_Date"])) : DateOnly.MinValue,

                                Location = dr.Table.Columns.Contains("Location") ? dr["Location"].ToString() : string.Empty,

                                Mobile_No = dr.Table.Columns.Contains("Mobile_No") ? dr["Mobile_No"].ToString() : string.Empty,
                                EMAIL = md.EMAIL,


                            };
                            dataList.Add(dto);
                            Evetn_Details booked = new Evetn_Details();
                            var sendEmail = booked.SendEmail(dto);
                



                        }
                    }
                }
                else
                {
                    resp.Code = 0;
                    resp.Message = "Faield To Book Event";
                    resp.Status = false;
                    resp.Data = new List<EventMaster_DTO>();
                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = ex.Message;
                resp.Status = false;
                resp.Data = new List<EventMaster_DTO>();


            }
            return resp;
        }


        public CommonResponse<EventMaster_DTO> GetMyEvents(int User_Id)
        {
            var resp = new CommonResponse<EventMaster_DTO>();
            try
            {
                DataTable dt = new EventMaster_DAL().GetMyEvents(User_Id);
                if (dt.Rows.Count != 0)
                {
                    List<EventMaster_DTO> dataList = new List<EventMaster_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new EventMaster_DTO
                        {
                            Event_ID = dr.Table.Columns.Contains("Event_ID") ? Convert.ToInt32(dr["Event_ID"]) : 0,
                            Event_Name = dr.Table.Columns.Contains("Event_Name") ? dr["Event_Name"].ToString() : string.Empty,
                            Organizer = dr.Table.Columns.Contains("Organizer") ? dr["Organizer"].ToString() : string.Empty,
                            Start_Time = dr["Start_Time"] != DBNull.Value ? TimeOnly.FromDateTime(Convert.ToDateTime(dr["Start_Time"])) : TimeOnly.MinValue,
                            End_Time = dr["End_Time"] != DBNull.Value ? TimeOnly.FromDateTime(Convert.ToDateTime(dr["End_Time"])) : TimeOnly.MinValue,
                            Event_Date = dr["Event_Date"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["Event_Date"])) : DateOnly.MinValue,
                            price = dr["price"] != DBNull.Value ? Convert.ToDecimal(dr["price"]) : decimal.MinValue,
                            Event_discription = dr.Table.Columns.Contains("Event_discription") ? dr["Event_discription"].ToString() : string.Empty,
                            Mobile_No = dr.Table.Columns.Contains("Mobile_No") ? dr["Mobile_No"].ToString() : string.Empty,
                            Theme = dr.Table.Columns.Contains("Theme") ? dr["Theme"].ToString() : string.Empty,
                            Location = dr.Table.Columns.Contains("Location") ? dr["Location"].ToString() : string.Empty,
                            Created_Date = dr["Created_Date"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["Created_Date"])) : DateOnly.MinValue,
                            Event_category = dr.Table.Columns.Contains("Event_category") ? Convert.ToInt32(dr["Event_category"]) : 0,
                            ResultStatus = dr["ResultStatus"] != DBNull.Value ? dr["ResultStatus"].ToString() : string.Empty,
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
                    resp.Data = new List<EventMaster_DTO>();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<EventMaster_DTO>();

                return resp;
            }
        }


        public CommonResponse<EventMaster_DTO> CancelEvent(int Event_ID)
        {
            var resp = new CommonResponse<EventMaster_DTO>();
            try
            {
                DataTable dt = new EventMaster_DAL().CancelEvent(Event_ID);
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
                    resp.Data = new List<EventMaster_DTO>();

                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<EventMaster_DTO>();

                return resp;
            }
        }

        public CommonResponse<EventMaster_DTO> BookedEvents()
        {
            var resp = new CommonResponse<EventMaster_DTO>();
            try
            {
                DataTable dt = new EventMaster_DAL().BookedEvents();
                if (dt.Rows.Count != 0)
                {
                    List<EventMaster_DTO> dataList = new List<EventMaster_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dto = new EventMaster_DTO
                        {
                            Event_ID = dr.Table.Columns.Contains("Event_ID") ? Convert.ToInt32(dr["Event_ID"]) : 0,
                            Event_Name = dr.Table.Columns.Contains("Event_Name") ? dr["Event_Name"].ToString() : string.Empty,
                            Organizer = dr.Table.Columns.Contains("Organizer") ? dr["Organizer"].ToString() : string.Empty,
                            Start_Time = dr["Start_Time"] != DBNull.Value ? TimeOnly.FromDateTime(Convert.ToDateTime(dr["Start_Time"])) : TimeOnly.MinValue,
                            End_Time = dr["End_Time"] != DBNull.Value ? TimeOnly.FromDateTime(Convert.ToDateTime(dr["End_Time"])) : TimeOnly.MinValue,
                            Event_Date = dr["Event_Date"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["Event_Date"])) : DateOnly.MinValue,
                            price = dr["price"] != DBNull.Value ? Convert.ToDecimal(dr["price"]) : decimal.MinValue,
                            Event_discription = dr.Table.Columns.Contains("Event_discription") ? dr["Event_discription"].ToString() : string.Empty,
                            Mobile_No = dr.Table.Columns.Contains("Mobile_No") ? dr["Mobile_No"].ToString() : string.Empty,
                            Theme = dr.Table.Columns.Contains("Theme") ? dr["Theme"].ToString() : string.Empty,
                            Location = dr.Table.Columns.Contains("Location") ? dr["Location"].ToString() : string.Empty,
                            Created_Date = dr["Created_Date"] != DBNull.Value ? DateOnly.FromDateTime(Convert.ToDateTime(dr["Created_Date"])) : DateOnly.MinValue,
                            Event_category = dr.Table.Columns.Contains("Event_category") ? Convert.ToInt32(dr["Event_category"]) : 0,
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
                    resp.Data = new List<EventMaster_DTO>();

                    return resp;

                }

            }
            catch (Exception ex)
            {
                resp.Code = 0;
                resp.Message = "ex Message";
                resp.Status = false;
                resp.Data = new List<EventMaster_DTO>();

                return resp;
            }
        }




    }

}

