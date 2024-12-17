using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;

namespace MainApp.MenuDialog;

public class MenuDialog : IMenuDialog
{
    public readonly UserService _UserService = new();
    public void ShowMenu()
    {
        bool IsRunning = true;
        do
        {
            Console.Clear();
            Console.WriteLine("1. List all users.");
            Console.WriteLine("2. Create user.");
            Console.WriteLine("3. Update user.");
            Console.WriteLine("Q. Exit application.");
            Console.Write("Choose menu: ");
            var option = Console.ReadLine()!;


            switch (option.ToLower())
            {

                case "1":
                    ShowAllUsers();
                    break;

                case "2":
                    ShowAddUsers();
                    break;

                case "3":
                    ShowUpdateUsers();
                    break;

                case "q":
                    ExitApplication();
                    break;

                default:
                    Console.WriteLine($"{option} is not a valid option, press any key to try again.");
                    Console.ReadKey();
                    break;
            }

        } while (IsRunning);

    }

    public void ExitApplication()
    {
        Environment.Exit(0);
    }

    public void ShowAddUsers()
    {
        var NewUser = UsersFactories.Create();
        Console.Clear();
        Console.Write("Enter first name: ");
        NewUser.FirstName = Console.ReadLine()!;
        Console.Write("Enter last name: ");
        NewUser.LastName = Console.ReadLine()!;
        Console.Write("Enter email: ");
        NewUser.Email = Console.ReadLine()!;
        Console.Write("Enter phonenumber: ");
        NewUser.PhoneNumber = Console.ReadLine()!;
        Console.Write("Enter address: ");
        NewUser.Address = Console.ReadLine()!;
        Console.Write("Enter Zip code: ");
        NewUser.ZipCode = Console.ReadLine()!;
        Console.Write("Enter city: ");
        NewUser.City = Console.ReadLine()!;

        _UserService.AddUser(NewUser);
    }

    public void ShowAllUsers()
    {
        bool hasError;
        var AllUsers = _UserService.ShowUsers(out hasError);
        Console.Clear();
        Console.WriteLine("All users: ");

        if (hasError)
        {
            Console.WriteLine("Couldnt´load file");
            Console.ReadKey();
            return;
        }

        if (!AllUsers.Any())
        {
            Console.WriteLine("No users found, press any key.");
            Console.ReadKey();
        }

        foreach (var user in AllUsers)
        {
            Console.WriteLine($"Id: {user.Id}");
            Console.WriteLine($"First name: {user.FirstName}");
            Console.WriteLine($"Last name: {user.LastName}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Phonenumber: {user.PhoneNumber}");
            Console.WriteLine($"Address: {user.Address}");
            Console.WriteLine($"Zipcode: {user.ZipCode}");
            Console.WriteLine($"City: {user.City}");
            Console.WriteLine();
        }
        Console.ReadKey();
    }

    public void ShowUpdateUsers()
    {
        Console.Clear();
        Console.Write("Enter email of user you want to update or delete: ");

    }
}
