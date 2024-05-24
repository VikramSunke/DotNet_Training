using System;
using System.Data.SqlClient;

namespace SQLDemo
{
    public class CarsActions
    {
        private string conStr = "Data Source=QUAL-LT87PXQL3\\SQLEXPRESS;Initial Catalog=CarsDB;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dataReader;

        public SqlDataReader SelectQuery(string query)
        {
            con = new SqlConnection(conStr);
            cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();
                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertUpdateDeleteQuery(string query)
        {
            con = new SqlConnection(conStr);
            cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result <= 0)
                {
                    throw new Exception("Execution failed");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
