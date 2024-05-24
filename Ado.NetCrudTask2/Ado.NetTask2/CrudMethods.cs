using System.Data;

namespace Ado.NetTask2
{
    public class crudMethods
    {
        private CarsActions carsActions = new CarsActions();

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

            int result = carsActions.Add(id, name, price, color);

            Console.WriteLine($"{result} record added successfully");
        }

        public void DoUpdate()
        {
            Console.WriteLine("Enter the car ID which you want to update:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the new car model:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the new car price:");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter the new car color:");
            string color = Console.ReadLine();

            int result = carsActions.Update(id, name, price, color);

            if (result > 0)
                Console.WriteLine($"{result} record updated successfully");
            else if (result == 0)
                Console.WriteLine("No record found with the specified ID.");
            else
                Console.WriteLine("Update operation failed");
        }

        public void DoDelete()
        {
            Console.WriteLine("Enter the car ID which you want to delete:");
            int id = Convert.ToInt32(Console.ReadLine());

            int result = carsActions.Delete(id);

            if (result > 0)
                Console.WriteLine($"{result} record deleted successfully");
            else if (result == 0)
                Console.WriteLine("No record found with the specified ID.");
            else
                Console.WriteLine("Delete operation failed");
        }

        public void DoReadAll()
        {
            DataTable dt = carsActions.ReadAll();
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"\ncar Id : {row["id"].ToString()}");
                Console.WriteLine($"car Name : {row["carName"].ToString()}");
                Console.WriteLine($"car Price : {row["carPrice"].ToString()}");
                Console.WriteLine($"car Color : {row["carColor"].ToString()}");
            }
        }

        public void DoReadById()
        {
            Console.WriteLine("Enter the car ID which you want to retrieve:");
            int id = Convert.ToInt32(Console.ReadLine());

            DataTable dt = carsActions.ReadById(id);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Console.WriteLine($"\ncar Id : {row["id"].ToString()}");
                Console.WriteLine($"car Name : {row["carName"].ToString()}");
                Console.WriteLine($"car Price : {row["carPrice"].ToString()}");
                Console.WriteLine($"car Color : {row["carColor"].ToString()}");
            }
            else
            {
                Console.WriteLine("No car records found.");
            }
        }
    }
}


