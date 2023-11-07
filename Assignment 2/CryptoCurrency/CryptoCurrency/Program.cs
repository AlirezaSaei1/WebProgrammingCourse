using CryptoCurrency.Models;
using CryptoCurrency.Models.Enums;
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
                var time = int.Parse(message[0]);
                var command = message[1];
                var id = message[2];

                Order order;
                OrderType orderType;
                
                if (command == "REM")
                {
                    var size = int.Parse(message[3]); 
                    Enum.TryParse(command, ignoreCase:true, out orderType);
                    order = new Order(time, id, orderType, size);
                }
                else
                {
                    var type = message[3];
                    Enum.TryParse(type, ignoreCase:true, out orderType);
                    var coin = message[4];
                    var price = float.Parse(message[5]);
                    var size = int.Parse(message[6]); 
                    order = new Order(time, id, orderType, coin, price, size);
                }
                
                if (command == "ADD")
                {
                    if (orderType == OrderType.Buy)
                    {
                        orderBookService.ProcessBuyOrder(order, target);
                    }
                    else if (orderType == OrderType.Sell)
                    {
                        orderBookService.ProcessSellOrder(order, target);
                    }
                }
                else if (command == "REM")
                {
                    orderBookService.RemoveOrder(order);
                }
            }
        }
    }
}

