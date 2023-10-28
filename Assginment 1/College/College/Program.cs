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
                
                // Variable to store command results
                string result;
                
                switch (parts?[0])
                {
                    case "REGISTER":
                        result = userService.RegisterUser(parts[1], parts[2]);
                        break;
                    case "APPROVE":
                        result = userService.ApproveMembership(parts[1], parts[2]);
                        break;
                    case "REJECT":
                        result = userService.RejectMembership(parts[1], parts[2]);
                        break;
                    case "QUEUE":
                        result = userService.GetWaitingList(parts[1]);
                        break;
                    case "CHANGEROLE":
                        result = userService.ChangeRole(parts[1], parts[2], parts[3]);
                        break;
                    case "STATUS":
                        result = userService.GetUserStatus(parts[1]);
                        break;
                    default:
                        result = "INVALID COMMAND";
                        break;
                }
                Console.WriteLine(result);
            }
        }
    }
}
