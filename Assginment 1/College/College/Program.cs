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
                string username1;
                string username2;
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
                        username1 = parts[1];
                        username2 = parts[2];
                        userService.ApproveMembership(username1, username2);
                        break;
                    case "REJECT":
                        username1 = parts[1];
                        username2 = parts[2];
                        userService.RejectMembership(username1, username2);
                        break;
                    case "QUEUE":
                        username = parts[1];
                        userService.GetWaitingList(username);
                        break;
                    case "CHANGEROLE":
                        username1 = parts[1];
                        username2 = parts[2];
                        role = parts[3];
                        userService.ChangeRole(username1, username2, role);
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
