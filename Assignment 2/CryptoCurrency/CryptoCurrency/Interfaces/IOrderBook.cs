using CryptoCurrency.Models;

namespace CryptoCurrency.Interfaces
{
    public interface IOrderBook
    {
        void ProcessBuyOrder(Order order, int target);
        void ProcessSellOrder(Order order, int target);
        void RemoveOrder(Order order);
    }  
}