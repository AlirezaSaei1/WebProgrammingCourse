namespace ConsoleApp.Models;

public class VoucherSub
{
    public int RowNumber { get; set; }

    public Product Product { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public VoucherSub(int rowNumber, Product product, int quantity, decimal price)
    {
        RowNumber = rowNumber;
        Product = product;
        Quantity = quantity;
        Price = price;
    }
}
