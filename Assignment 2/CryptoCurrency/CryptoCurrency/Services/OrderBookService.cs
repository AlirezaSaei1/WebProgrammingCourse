using CryptoCurrency.Interfaces;
using CryptoCurrency.Models;

namespace CryptoCurrency.Services
{
    public class OrderBookService: IOrderBook
    {
        private static readonly Dictionary<string, List<Order>> BuyOrders = new Dictionary<string, List<Order>>();
        private static readonly Dictionary<string, int> TotalBuy = new Dictionary<string, int>();
        private static readonly Dictionary<string, List<Order>> SellOrders = new Dictionary<string, List<Order>>();
        private static readonly Dictionary<string, int> TotalSell = new Dictionary<string, int>();
    
        public void ProcessBuyOrder(Order order, int target)
        {
            if (!BuyOrders.ContainsKey(order.Coin))
            {
                BuyOrders[order.Coin] = new List<Order> { order };
                TotalBuy[order.Coin] = order.Size;
            }
            else
            {
                BuyOrders[order.Coin].Add(order);
                BuyOrders[order.Coin].Sort();
                TotalBuy[order.Coin] += order.Size;
            }
            CheckForCompletedOrders(order, target, "BUY");
        }

        public void ProcessSellOrder(Order order, int target)
        {
            if (!SellOrders.ContainsKey(order.Coin))
            {
                SellOrders[order.Coin] = new List<Order>{ order };
                TotalSell[order.Coin] = order.Size;
            }
            else
            {
                SellOrders[order.Coin].Add(order);
                SellOrders[order.Coin].Sort();
                TotalSell[order.Coin] += order.Size;
            }
            CheckForCompletedOrders(order, target, "SELL");
        }

        public void RemoveOrder(Order order)
        {
            if (SellOrders.ContainsKey(order.Coin))
            {
                
            }
            else if (BuyOrders.ContainsKey(order.Coin))
            {
                
            }
            else
            {
                Console.WriteLine("ID could not be found");
            }
        }

        private static void CheckForCompletedOrders(Order order, int target, string type)
        {
            if (type == "BUY")
            {
                 
            }
            else if (type == "SELL")
            {
                if (TotalSell[order.Coin] >= target)
                {
                    var money = 0.0;
                    var temp = target;
                    while (temp > 0)
                    {
                        var index = -1;
                        double minimumPrice = 200001;
                        for (int j = 0; j < SellOrders[order.Coin].Count; j++)
                        {
                            if (SellOrders[order.Coin][j].RemainingSize > 0 && SellOrders[order.Coin][j].Price < minimumPrice)
                            {
                                index = j;
                                minimumPrice = SellOrders[order.Coin][j].Price;
                            }
                        }
                        if (SellOrders[order.Coin][index].Size >= temp)
                        {
                            SellOrders[order.Coin][index].RemainingSize -= temp;
                            money += SellOrders[order.Coin][index].Price * temp;
                            TotalSell[order.Coin] -= temp;
                            temp = 0;
                        }
                        else
                        {
                            money = SellOrders[order.Coin][index].Price * SellOrders[order.Coin][index].RemainingSize;
                            temp -= SellOrders[order.Coin][index].RemainingSize;
                            TotalSell[order.Coin] -= SellOrders[order.Coin][index].RemainingSize;
                            SellOrders[order.Coin][index].RemainingSize = 0;
                        }
                    }
                    Console.WriteLine($"{order.Time} buy {order.Coin} {money.ToString("0.00")}");
                }
            }
            else
            {
                Console.WriteLine("Invalid Type");
            }
        }
    }   
}