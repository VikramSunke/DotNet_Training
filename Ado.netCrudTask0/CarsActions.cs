using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SQLDemo
{
    public class CarsActions
    {
        private string conStr = "Data Source=QUAL-LT87PXQL3\\SQLEXPRESS;Initial Catalog=CarsDB;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dataReader;

        public int Add(string sqltext)
        {
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(sqltext, con);
            return cmd.ExecuteNonQuery();
        }

        public int Update(int carId, string carName, int carPrice, string carColor)
        {
            
            con.Open();

            string query = $"UPDATE CarsTable SET carName = '{carName}', carPrice = {carPrice}, carColor = '{carColor}' WHERE id = {carId}";
            cmd = new SqlCommand(query, con);

            int result = cmd.ExecuteNonQuery();

            con.Close();

            return result;
        }

        public int Delete(int carId)
        {
           
            con = new SqlConnection(conStr);
            con.Open();
            string query = $"DELETE FROM CarsTable WHERE id={carId}";
            cmd = new SqlCommand(query, con);
            return cmd.ExecuteNonQuery();
        }

        public SqlDataReader ReadAll()
        {
            con = new SqlConnection(conStr);
            con.Open();
            string query = "SELECT * FROM CarsTable";
            cmd = new SqlCommand(query, con);
            dataReader = cmd.ExecuteReader();
            return dataReader;
        }

        public SqlDataReader ReadById(int id)
        {
            con = new SqlConnection(conStr);
            con.Open();
            string query = $"SELECT * FROM CarsTable WHERE id = {id}";
            cmd = new SqlCommand(query, con);

            dataReader = cmd.ExecuteReader();
            return dataReader;
        }
        
    }
}
