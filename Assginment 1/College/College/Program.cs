namespace College
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
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
                }

            }
        }
    }
}
