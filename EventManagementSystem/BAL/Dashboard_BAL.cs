using EventManagementSystem.DAL;
using EventManagementSystem.Models;
using System.Data;

namespace EventManagementSystem.BAL
{
    public class Dashboard_BAL
    {

        CommonResponse<AreaChart_DTO> Response = new CommonResponse<AreaChart_DTO>();
        public CommonResponse<AreaChart_DTO> AreaChart()
        {
            try
            {
                Dashboard_DAL DAL = new Dashboard_DAL();
                DataTable dt = DAL.AreaChart();
                if (dt.Rows.Count > 0)
                {
                    List<AreaChart_DTO> dTOs = new List<AreaChart_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        AreaChart_DTO dTO = new AreaChart_DTO
                        {
                            TotalEvents = dr["TotalEvents"] != DBNull.Value ? Convert.ToInt32(dr["TotalEvents"]) : 0,
                            MonthName = dr["MonthName"] != DBNull.Value ? dr["MonthName"].ToString() : "",
                        };
                        dTOs.Add(dTO);
                    }

                    Response.Code = 1;
                    Response.Message = "successfully get";
                    Response.Status = true;
                    Response.Data = dTOs;
                    return Response;
                }
                else
                {
                    Response.Code = 0;
                    Response.Message = "Not found";
                    Response.Status = true;
                    Response.Data = null;
                    return Response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        CommonResponse<ColumnChart_DTO> ColResponse = new CommonResponse<ColumnChart_DTO>();
        public CommonResponse<ColumnChart_DTO> ColumnChart()
        {
            try
            {
                Dashboard_DAL DAL = new Dashboard_DAL();
                DataTable dt = DAL.ColumnChart();
                if (dt.Rows.Count > 0)
                {
                    List<ColumnChart_DTO> dTOs = new List<ColumnChart_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ColumnChart_DTO dTO = new ColumnChart_DTO
                        {
                            TotalParticipants = dr["TotalParticipants"] != DBNull.Value ? Convert.ToInt32(dr["TotalParticipants"]) : 0,
                            Event_Name = dr["Event_Name"] != DBNull.Value ? dr["Event_Name"].ToString() : "",
                        };
                        dTOs.Add(dTO);
                    }

                    ColResponse.Code = 1;
                    ColResponse.Message = "successfully get";
                    ColResponse.Status = true;
                    ColResponse.Data = dTOs;
                    return ColResponse;
                }
                else
                {
                    ColResponse.Code = 0;
                    ColResponse.Message = "Not found";
                    ColResponse.Status = true;
                    ColResponse.Data = null;
                    return ColResponse;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        CommonResponse<DonutChart_DTO> DonResponse = new CommonResponse<DonutChart_DTO>();
        public CommonResponse<DonutChart_DTO> DonutChart()
        {
            try
            {
                Dashboard_DAL DAL = new Dashboard_DAL();
                DataTable dt = DAL.DonutChart();
                if (dt.Rows.Count > 0)
                {
                    List<DonutChart_DTO> dTOs = new List<DonutChart_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        DonutChart_DTO dTO = new DonutChart_DTO
                        {
                            TotalEvents = dr["TotalEvents"] != DBNull.Value ? Convert.ToInt32(dr["TotalEvents"]) : 0,
                            CATEGORY_NAME = dr["CATEGORY_NAME"] != DBNull.Value ? dr["CATEGORY_NAME"].ToString() : "",
                        };
                        dTOs.Add(dTO);
                    }

                    DonResponse.Code = 1;
                    DonResponse.Message = "successfully get";
                    DonResponse.Status = true;
                    DonResponse.Data = dTOs;
                    return DonResponse;
                }
                else
                {
                    DonResponse.Code = 0;
                    DonResponse.Message = "Not found";
                    DonResponse.Status = true;
                    DonResponse.Data = null;
                    return DonResponse;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        CommonResponse<PieChart_DTO> PieResponse = new CommonResponse<PieChart_DTO>();
        public CommonResponse<PieChart_DTO> PieChart()
        {
            try
            {
                Dashboard_DAL DAL = new Dashboard_DAL();
                DataTable dt = DAL.DonutChart();
                if (dt.Rows.Count > 0)
                {
                    List<PieChart_DTO> dTOs = new List<PieChart_DTO>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        PieChart_DTO dTO = new PieChart_DTO
                        {
                            TotalEvents = dr["TotalEvents"] != DBNull.Value ? Convert.ToInt32(dr["TotalEvents"]) : 0,
                            CATEGORY_NAME = dr["CATEGORY_NAME"] != DBNull.Value ? dr["CATEGORY_NAME"].ToString() : "",
                        };
                        dTOs.Add(dTO);
                    }

                    PieResponse.Code = 1;
                    PieResponse.Message = "successfully get";
                    PieResponse.Status = true;
                    PieResponse.Data = dTOs;
                    return PieResponse;
                }
                else
                {
                    PieResponse.Code = 0;
                    PieResponse.Message = "Not found";
                    PieResponse.Status = true;
                    PieResponse.Data = null;
                    return PieResponse;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
