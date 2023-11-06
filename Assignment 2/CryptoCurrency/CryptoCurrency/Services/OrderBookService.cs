using CryptoCurrency.Interfaces;
using CryptoCurrency.Models;

namespace CryptoCurrency.Services
{
    public class OrderBookService: IOrderBook
    {
        private readonly Dictionary<string, List<Order>> _buyOrders = new Dictionary<string, List<Order>>();
        private readonly Dictionary<string, List<Order>> _sellOrders = new Dictionary<string, List<Order>>();
    
        public void ProcessBuyOrder(Order order, int target)
        {
            if (!_buyOrders.ContainsKey(order.Coin))
            {
                _buyOrders[order.Coin] = new List<Order>();
            }
            _buyOrders[order.Coin].Add(order);
        }

        public void ProcessSellOrder(Order order, int target)
        {
            if (!_sellOrders.ContainsKey(order.Coin))
            {
                _sellOrders[order.Coin] = new List<Order>();
            }

            _sellOrders[order.Coin].Add(order);
        
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