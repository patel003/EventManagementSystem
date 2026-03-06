using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data;
using System.Data.SqlClient;

namespace EventManagementSystem.DAL
{
    public class Dashboard_DAL
    {
        public DataTable DonutChart(int UserIdforchart)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                   new SqlParameter("@Action", "DonutChart")
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_EventCharts", CommandType.StoredProcedure, sp);
        }

        public DataTable PieChart(int UserIdforchart)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                    new SqlParameter("@Action", "PieChart")
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_EventCharts", CommandType.StoredProcedure, sp);
        }

        public DataTable AreaChart(int UserIdforchart)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                   new SqlParameter("@Action", "AreaChart")
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_EventCharts", CommandType.StoredProcedure, sp);
        }

        public DataTable ColumnChart(int UserIdforchart)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                   new SqlParameter("@Action", "ColumnChart")
            };
            return DataHelper.ExecuteParameterisedDatatableCommand("SP_EventCharts", CommandType.StoredProcedure, sp);
        }

    }
}
