using System.Data;
using System.Data.SqlClient;

namespace EventManagementSystem.DAL
{
    public class DataHelper
    {
        const string connectionString = @"Data Source=localhost;Initial Catalog=EMS;Integrated Security=True;Connect Timeout=30;";
        internal static DataTable ExecuteCommand(string strComm, CommandType commandType)
        {
            DataTable dt = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandTimeout = 999;
                    cmd.CommandType = commandType;
                    cmd.CommandText = strComm;
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                }
            }

            return dt;
        }

        internal static DataTable ExecuteParameterisedDatatableCommand(string strComm, CommandType commandType, SqlParameter[] sqlParameter)
        {
            DataTable dt = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandTimeout = 999;
                    cmd.CommandType = commandType;
                    cmd.CommandText = strComm;
                    cmd.Parameters.AddRange(sqlParameter);
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return dt;
        }

        internal static bool ExecuteNonQuery(string strComm, CommandType commandType, SqlParameter[] sqlParameter)
        {
            int result = 0;
            SqlTransaction sqlTransaction;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                sqlTransaction = con.BeginTransaction();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandTimeout = 999;
                    cmd.CommandType = commandType;
                    cmd.CommandText = strComm;
                    cmd.Parameters.AddRange(sqlParameter);
                    cmd.Transaction = sqlTransaction;
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return (result > 0);
        }

        internal static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandTimeout = 999;//This is for timeout command
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            ad.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return table;
        }

    }
}
