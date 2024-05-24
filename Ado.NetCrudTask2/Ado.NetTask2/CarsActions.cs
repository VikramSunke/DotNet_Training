using System.Data;
using System.Data.SqlClient;

namespace Ado.NetTask2
{
    public class CarsActions
    {
        private SqlDataAdapter dataAdapter;
        private SqlConnection con;
        private SqlCommandBuilder cmdBuilder;

        private readonly string conStr = "Data Source=QUAL-LT87PXQL3\\SQLEXPRESS;Initial Catalog=CarsDB;Integrated Security=True";

        public CarsActions()
        {
            con = new SqlConnection(conStr);
            dataAdapter = new SqlDataAdapter();
            cmdBuilder = new SqlCommandBuilder(dataAdapter);
        }

        public int Add(int id, string carName, decimal carPrice, string carColor)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM CarsTable", con);
                dataAdapter.Fill(dt);

                DataRow newRow = dt.NewRow();
                newRow["id"] = id;
                newRow["carName"] = carName;
                newRow["carPrice"] = carPrice;
                newRow["carColor"] = carColor;
                dt.Rows.Add(newRow);

                return dataAdapter.Update(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1; // Return -1 to indicate failure
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public int Update(int id, string carName, decimal carPrice, string carColor)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                dataAdapter.SelectCommand = new SqlCommand($"SELECT * FROM CarsTable WHERE id = {id}", con);
                dataAdapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("No record found with the specified ID.");
                    return 0; // Return 0 to indicate no update
                }

                DataRow rowToUpdate = dt.Rows[0];
                rowToUpdate["carName"] = carName;
                rowToUpdate["carPrice"] = carPrice;
                rowToUpdate["carColor"] = carColor;

                return dataAdapter.Update(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1; // Return -1 to indicate failure
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public int Delete(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                dataAdapter.SelectCommand = new SqlCommand($"SELECT * FROM CarsTable WHERE id = {id}", con);
                dataAdapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("No record found with the specified ID.");
                    return 0; // Return 0 to indicate no deletion
                }

                dt.Rows[0].Delete();
                return dataAdapter.Update(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1; // Return -1 to indicate failure
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public DataTable ReadAll()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM CarsTable", con);
                dataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return dt;
        }

        public DataTable ReadById(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                dataAdapter.SelectCommand = new SqlCommand($"SELECT * FROM CarsTable WHERE id = {id}", con);
                dataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return dt;
        }
    }
}


