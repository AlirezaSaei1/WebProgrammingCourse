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

public class VoucherSubComparer : IEqualityComparer<VoucherSub>
{
    public bool Equals(VoucherSub? x, VoucherSub? y)
    {
        return x.RowNumber == y.RowNumber;
    }

    public int GetHashCode(VoucherSub obj)
    {
        return obj.Product.GetHashCode() ^ obj.Quantity.GetHashCode();
    }
}
