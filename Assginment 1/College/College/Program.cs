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
                
                // Boolean to check input length
                var hasInvalidLength = false;

                // Variable to store command results
                string result;
                
                // Check Length of Each Part
                foreach (var part in parts)
                {
                    if (part.Length is >= 1 and <= 10) continue;
                    hasInvalidLength = true;
                    Console.WriteLine($"Invalid part length: {part}. Parts should be between 1 and 10 characters.");
                    break;
                }
                
                // Skip to the next iteration of the loop
                if (hasInvalidLength) { continue; }

                result = parts?[0] switch
                {
                    "REGISTER" => userService.RegisterUser(parts[1], parts[2]),
                    "APPROVE" => userService.ApproveMembership(parts[1], parts[2]),
                    "REJECT" => userService.RejectMembership(parts[1], parts[2]),
                    "QUEUE" => userService.GetWaitingList(parts[1]),
                    "CHANGEROLE" => userService.ChangeRole(parts[1], parts[2], parts[3]),
                    "STATUS" => userService.GetUserStatus(parts[1]),
                    _ => "INVALID COMMAND"
                };
                Console.WriteLine(result);
            }
        }
    }
}
