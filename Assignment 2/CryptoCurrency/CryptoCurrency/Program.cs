using CryptoCurrency.Services;

namespace CryptoCurrency
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Create an order book service
            var orderBookService = new OrderBookService();
            
            // Line 1
            var firstLine = Console.ReadLine()!.Split(' ');
            var target = int.Parse(firstLine[0]);
            var coinCount = int.Parse(firstLine[1]);
            
            // Line 2
            var coinNames = Console.ReadLine()!.Split(' ');

            // Line 3
            var messageCount = int.Parse(Console.ReadLine()!);

            // Read the messages
            for (var i = 0; i < messageCount; i++)
            {  
                var message = Console.ReadLine()!.Split(' ');
                var time = message[0];
                var command = message[1];
                var id = message[2];
                var type = message[3];
                var coin = message[4];
                var price = decimal.Parse(message[5]);
                var size = int.Parse(message[6]);
            }
        }
    }
}

