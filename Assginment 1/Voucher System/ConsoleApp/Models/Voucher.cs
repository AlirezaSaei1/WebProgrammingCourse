namespace ConsoleApp.Models;

public class Voucher
{
    public DateTime DeliveryDate { get; set; }

    public decimal TotalPrice { get; set; }

    public List<VoucherSub> Details { get; set; }

    public Voucher()
    {
        Details = new List<VoucherSub>();
    }
    
    // Operator Overloading
    
}
