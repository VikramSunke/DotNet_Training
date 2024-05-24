
namespace Ado.NetTask2
{
    // Enum to represent CRUD operations
    public enum CrudOptions // Enum for CRUD operations
    {
        add,
        update,
        delete,
        readAll,
        readById,
        Quit
    }

    // Class to handle user menu options
    public class MenuOptions
    {
        // Method to display menu and handle user input
        public void UserOptions()
        {
            // Variable to control program execution
            bool continueProgram = true;

            // Loop to display menu and handle user input
            while (continueProgram)
            {
                // Displaying menu options
                Console.WriteLine("\nChoose your method:\n0. Add\n1. Update\n2. Delete\n3. ReadAll\n4. ReadById\n5. Quit\n");

                // Reading user input
                int choice = Convert.ToInt32(Console.ReadLine());
                CrudOptions crudOptions = (CrudOptions)choice;
                crudMethods crudMethods = new crudMethods();

                // Switch case to execute corresponding method based on user input
                switch (crudOptions)
                {
                    case CrudOptions.add:
                        Console.WriteLine("Add Car");
                        crudMethods.DoAdd();
                        break;
                    case CrudOptions.update:
                        Console.WriteLine("Update Car Details");
                        //crudMethods.DoUpdate();
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
                        crudMethods.DoReadById();
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
