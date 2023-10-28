using System.Runtime.InteropServices;
using College.Models.Enums;
using College.Services;

namespace College
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initiate UserService
            UserService userService = new UserService();

            // Get number of commands
            var n = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                // Read Command and Split Parts
                var input = Console.ReadLine();
                var parts = input?.Split(" ");
                
                //Command Parts
                string username;
                string role;
                string status;
                
                switch (parts?[0])
                {
                    case "REGISTER":
                        username = parts[1];
                        role = parts[2];
                        userService.RegisterUser(username, role);
                        break;
                    case "APPROVE":
                        break;
                    case "REJECT":
                        break;
                    case "QUEUE":
                        break;
                    case "CHANGEROLE":
                        break;
                    case "STATUS":
                        username = parts[1];
                        userService.GetUserStatus(username);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;  
                }

            }
        }
    }
}
