using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQLDemo
{
    public class crudMethods
    {
        CarsActions carsActions=new CarsActions();

        SqlDataReader dataReader;
        public void DoAdd() 
        {
            
            Console.WriteLine("Enter the car ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the car model:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the car price:");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter the car color:");
            string color = Console.ReadLine();

            string sqltext = $"INSERT INTO CarsTable VALUES({id}, '{name}', {price}, '{color}')";
            
            int result = carsActions.Add(sqltext);
            
            Console.WriteLine($"{result} record added successfully");
        }

        public void DoUpdate()
        {
            Console.WriteLine("Enter the car ID which you want to retrieve:");
            int carId = Convert.ToInt32(Console.ReadLine());

            dataReader = carsActions.ReadById(carId);
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
                int updatedPrice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the car color: ");
                string updatedColor = Console.ReadLine();



                int result = carsActions.Update(carId, updatedName, updatedPrice, updatedColor);

                if (result > 0)
                {
                    Console.WriteLine($"{result} record updated successfully");
                }
                else
                {
                    Console.WriteLine("Update operation failed");
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
            Console.WriteLine("Enter the car ID which you want to Update:");
            int carId = Convert.ToInt32(Console.ReadLine());

            int result = carsActions.Delete(carId);

            Console.WriteLine($"{result} record deleted successfully");
        }

        public void DoReadAll()
        {
            dataReader = carsActions.ReadAll();

            while (dataReader.Read())
            {
                Console.WriteLine("\nCar Id is:" + dataReader[0].ToString());
                Console.WriteLine("Car Name is:" + dataReader[1].ToString());
                Console.WriteLine("Car Price is:" + dataReader[2].ToString());
                Console.WriteLine("Car DeliveryDate is:" + dataReader[3].ToString());
            }
            dataReader.Close();

        }
        public void ReadById() { 

            Console.WriteLine("Enter the car ID which you want to retrieve:");
            int carId = Convert.ToInt32(Console.ReadLine());
            
            dataReader = carsActions.ReadById(carId);

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
