using College.Services;

namespace College
{
    public class Program
    {
        private static readonly UserService _userService = new UserService();
        public static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var parts = input?.Split(" ");

                switch (parts?[0])
                {
                    case "REGISTER":
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
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

            }
        }
    }
}
