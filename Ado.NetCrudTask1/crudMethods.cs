using System;
using System.Data.SqlClient;

namespace SQLDemo
{
    public class crudMethods
    {
        CarsActions carsActions = new CarsActions();
        SqlDataReader dataReader;

        public void DoAdd()
        {
            Console.WriteLine("\nEnter the car ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the car model:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the car price:");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter the car color:");
            string color = Console.ReadLine();

            string query = $"INSERT INTO CarsTable VALUES({id}, '{name}', {price}, '{color}')";
            try
            {
                carsActions.InsertUpdateDeleteQuery(query);

                Console.WriteLine($"record added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DoUpdate()
        {
            Console.WriteLine("\nEnter the car ID which you want to retrieve:");
            int carId = Convert.ToInt32(Console.ReadLine());

            dataReader = carsActions.SelectQuery($"SELECT * FROM CarsTable WHERE id = {carId}");
            if (dataReader.Read())
            {
                Console.WriteLine("\nCurrent Car Details:");
                Console.WriteLine("Car Id is: " + dataReader[0].ToString());
                Console.WriteLine("Car Name is: " + dataReader[1].ToString());
                Console.WriteLine("Car Price is: " + dataReader[2].ToString());
                Console.WriteLine("Car Color is: " + dataReader[3].ToString());

                Console.WriteLine("\nEnter the updated car details:");
                Console.WriteLine("Enter the car model:");
                string updatedName = Console.ReadLine();
                Console.WriteLine("Enter the car price:");
                decimal updatedPrice = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter the car color: ");
                string updatedColor = Console.ReadLine();
                string updateQuery = $"UPDATE CarsTable SET carName = '{updatedName}', carPrice = {updatedPrice}, carColor = '{updatedColor}' WHERE id = {carId}";

                try
                {
                    carsActions.InsertUpdateDeleteQuery(updateQuery);
                    Console.WriteLine("\nRecord Updated Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("No Record Found");
            }
            dataReader.Close();
        }

        public void DoDelete()
        {
            Console.WriteLine("\nEnter the car ID which you want to Delete:");
            int carId = Convert.ToInt32(Console.ReadLine());
            string deleteQuery = $"DELETE FROM CarsTable WHERE id={carId}";
            try
            {
                carsActions.InsertUpdateDeleteQuery(deleteQuery);
                Console.WriteLine($"record deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DoReadAll()
        {
            dataReader = carsActions.SelectQuery("SELECT * FROM CarsTable");

            while (dataReader.Read())
            {
                Console.WriteLine("\nCar Id is:" + dataReader[0].ToString());
                Console.WriteLine("Car Name is:" + dataReader[1].ToString());
                Console.WriteLine("Car Price is:" + dataReader[2].ToString());
                Console.WriteLine("Car DeliveryDate is:" + dataReader[3].ToString());
            }
            dataReader.Close();
        }

        public void ReadById()
        {
            Console.WriteLine("\nEnter the car ID which you want to retrieve:");
            int carId = Convert.ToInt32(Console.ReadLine());

            dataReader = carsActions.SelectQuery($"SELECT * FROM CarsTable WHERE id = {carId}");

            if (dataReader.Read())
            {
                Console.WriteLine("\nCar Id is:" + dataReader[0].ToString());
                Console.WriteLine("Car Name is:" + dataReader[1].ToString());
                Console.WriteLine("Car Price is:" + dataReader[2].ToString());
                Console.WriteLine("Car DeliveryDate is:" + dataReader[3].ToString());
            }
            else
            {
                Console.WriteLine("No Record Found");
            }
            dataReader.Close();
        }
    }
}
