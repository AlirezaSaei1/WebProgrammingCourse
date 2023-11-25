using CryptoCurrency.Interfaces;
using CryptoCurrency.Models;

namespace CryptoCurrency.Services
{
    public class OrderBookService : IOrderBook
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
                TotalBuy[order.Coin] += order.Size;
            }
            
            BuyOrders[order.Coin] = BuyOrders[order.Coin].OrderBy(o => o.Time).ToList();
            CheckForCompletedBuyOrder(order, target);
        }

        public void ProcessSellOrder(Order order, int target)
        {
            if (!SellOrders.ContainsKey(order.Coin))
            {
                SellOrders[order.Coin] = new List<Order> { order };
                TotalSell[order.Coin] = order.Size;
            }
            else
            {
                SellOrders[order.Coin].Add(order);
                TotalSell[order.Coin] += order.Size;
            }
            
            SellOrders[order.Coin] = SellOrders[order.Coin].OrderBy(o => o.Time).ToList();
            CheckForCompletedSellOrder(order, target);
        }

        public void RemoveOrder(Order order, int target)
        {
            var allBuyOrders = BuyOrders.Values.SelectMany(orders => orders).ToList();
            var buyOrderToRemove = allBuyOrders.FirstOrDefault(o => o.Id == order.Id);

            if (buyOrderToRemove == null)
            {
                var allSellOrders = BuyOrders.Values.SelectMany(orders => orders).ToList();
                var sellOrderToRemove = allSellOrders.FirstOrDefault(o => o.Id == order.Id);

                if (sellOrderToRemove == null) { }
                else
                {
                    if (TotalSell[sellOrderToRemove.Coin] - order.Size < target)
                    {
                        Console.WriteLine($"{order.Time} sell {sellOrderToRemove.Coin} NA");
                    }
                    else
                    {
                        TotalSell[sellOrderToRemove.Coin] -= order.Size;    
                    }
                }
            }
            else
            {
                if (TotalBuy[buyOrderToRemove.Coin] - order.Size < target)
                {
                    Console.WriteLine($"{order.Time} sell {buyOrderToRemove.Coin} NA");
                }
                else
                {
                    TotalBuy[buyOrderToRemove.Coin] -= order.Size;    
                }
                
            }
        }

        private static void CheckForCompletedBuyOrder(Order order, int target)
        {
            if (TotalBuy[order.Coin] < target) return;
            float cumulativePrice = 0;
            var temp = target;
            while (temp > 0)
            {
                var index = -1;
                var maximumPrice = -1f;

                var buyOrders = BuyOrders[order.Coin];
                for (var j = 0; j < buyOrders.Count; j++)
                {
                    var currentOrder = buyOrders[j];
                    if (currentOrder.RemainingSize <= 0 || !(currentOrder.Price > maximumPrice)) continue;
                    index = j;
                    maximumPrice = currentOrder.Price;
                }

                if (BuyOrders[order.Coin][index].Size >= temp)
                {
                    BuyOrders[order.Coin][index].RemainingSize -= temp;
                    cumulativePrice += BuyOrders[order.Coin][index].Price * temp;
                    TotalBuy[order.Coin] -= temp;
                    temp = 0;
                }
                else
                {
                    cumulativePrice = (BuyOrders[order.Coin][index].Price * BuyOrders[order.Coin][index].RemainingSize);
                    temp -= BuyOrders[order.Coin][index].RemainingSize;
                    TotalBuy[order.Coin] -= BuyOrders[order.Coin][index].RemainingSize;
                    BuyOrders[order.Coin][index].RemainingSize = 0;
                }
            }

            Console.WriteLine($"{order.Time} sell {order.Coin} {cumulativePrice.ToString("0.00")}");
        }

        private static void CheckForCompletedSellOrder(Order order, int target)
        {
            if (TotalSell[order.Coin] < target) return;
            var cumulativePrice = 0.0;
            var temp = target;
            while (temp > 0)
            {
                var index = -1;
                var minimumPrice = float.PositiveInfinity;
                
                var sellOrders = SellOrders[order.Coin];
                for (var j = 0; j < sellOrders.Count; j++)
                {
                    var currentOrder = sellOrders[j];
                    if (currentOrder.RemainingSize <= 0 || !(currentOrder.Price < minimumPrice)) continue;
                    index = j;
                    minimumPrice = currentOrder.Price;
                }

                if (SellOrders[order.Coin][index].Size >= temp)
                {
                    SellOrders[order.Coin][index].RemainingSize -= temp;
                    cumulativePrice += SellOrders[order.Coin][index].Price * temp;
                    TotalSell[order.Coin] -= temp;
                    temp = 0;
                }
                else
                {
                    cumulativePrice = SellOrders[order.Coin][index].Price * SellOrders[order.Coin][index].RemainingSize;
                    temp -= SellOrders[order.Coin][index].RemainingSize;
                    TotalSell[order.Coin] -= SellOrders[order.Coin][index].RemainingSize;
                    SellOrders[order.Coin][index].RemainingSize = 0;
                }
            }

            Console.WriteLine($"{order.Time} buy {order.Coin} {cumulativePrice.ToString("0.00")}");
        }
    }
}