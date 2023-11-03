namespace CryptoCurrency
{
    public class Program
    {
        public static void main(string[] args)
        {
            // Line 1
            var firstLine = Console.ReadLine().Split(' ');
            var target = int.Parse(firstLine[0]);
            var coinCount = int.Parse(firstLine[1]);
            
            // Line 2
            var coinNames = Console.ReadLine().Split(' ');

            // Line 3
            var messageCount = int.Parse(Console.ReadLine());

            // Read the messages
            for (var i = 0; i < messageCount; i++)
            {  
                var command = Console.ReadLine();
            }
        }
    }
}

