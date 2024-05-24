using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SQLDemo
{
    public enum CrudOptions // Enum for CRUD operations
    {
        add,
        update,
        delete,
        readAll,
        readById,
        Quit
    }

    public class MenuOptions
    {
        public void UserOptions()
        {
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("\nChoose your method:\n0. Add\n1. Update\n2. Delete\n3. ReadAll\n4. ReadById\n5. Quit\n");

                int choice = Convert.ToInt32(Console.ReadLine());
                CrudOptions crudOptions = (CrudOptions)choice;
                crudMethods crudMethods = new crudMethods();

                switch (crudOptions)
                {
                    case CrudOptions.add:
                        Console.WriteLine("Add Car");
                        crudMethods.DoAdd();                      
                        break;
                    case CrudOptions.update:
                        Console.WriteLine("Update Car Details");
                        crudMethods.DoUpdate();
                        break;
                    case CrudOptions.delete:
                        Console.WriteLine("Delete record");
                        crudMethods.DoDelete();
                        break;
                    case CrudOptions.readAll:
                        Console.WriteLine("Read All records");
                        crudMethods.DoReadAll();
                        break;
                    case CrudOptions.readById:
                        Console.WriteLine("Read record by Id");
                        crudMethods.ReadById();
                        break;

                    case CrudOptions.Quit:
                        Console.WriteLine("Exiting the program.");
                        continueProgram = false; // Exit the loop
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }

        
        
    }
}
