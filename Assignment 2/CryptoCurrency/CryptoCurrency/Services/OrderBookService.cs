using CryptoCurrency.Interfaces;
using CryptoCurrency.Models;

namespace CryptoCurrency.Services
{
    public class OrderBookService: IOrderBook
    {
        private readonly Dictionary<string, List<Order>> _buyOrders = new Dictionary<string, List<Order>>();
        private readonly Dictionary<string, int> _totalBuy = new Dictionary<string, int>();
        private readonly Dictionary<string, List<Order>> _sellOrders = new Dictionary<string, List<Order>>();
        private readonly Dictionary<string, int> _totalSell = new Dictionary<string, int>();
    
        public void ProcessBuyOrder(Order order, int target)
        {
            if (!_buyOrders.ContainsKey(order.Coin))
            {
                _buyOrders[order.Coin] = new List<Order> { order };
                _totalBuy[order.Coin] = order.Size;
            }
            else
            {
                _buyOrders[order.Coin].Add(order);
                _totalBuy[order.Coin] += order.Size;
            }
        }

        public void ProcessSellOrder(Order order, int target)
        {
            if (!_sellOrders.ContainsKey(order.Coin))
            {
                _sellOrders[order.Coin] = new List<Order>();
            }
            else
            {
                _sellOrders[order.Coin].Add(order);    
            }
        }

        public void RemoveOrder(Order order)
        {
            if (_sellOrders.ContainsKey(order.Coin))
            {
                
            }
            else if (_buyOrders.ContainsKey(order.Coin))
            {
                
            }
            else
            {
                Console.WriteLine("ID could not be found");
            }
        }
    }   
}