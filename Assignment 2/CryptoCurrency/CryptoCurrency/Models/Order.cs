using CryptoCurrency.Models.Enums;

namespace CryptoCurrency.Models
{
    public class Order
    {
        public int Time { get; set; }
        public string Id { get; set; }
        public OrderType Type { get; set; }
        public string Coin { get; set; }
        public float Price { get; set; }
        public int Size { get; set; }
        public int RemainingSize { get; set; }

        public Order(int time, string id, OrderType type, string coin, float price, int size)
        {
            Time = time;
            Id = id;
            Type = type;
            Coin = coin;
            Price = price;
            Size = size;
            RemainingSize = size;
        }
        
        public Order(int time, string id, OrderType type, int size)
        {
            Time = time;
            Id = id;
            Type = type;
            Size = size;
        }
    }
}