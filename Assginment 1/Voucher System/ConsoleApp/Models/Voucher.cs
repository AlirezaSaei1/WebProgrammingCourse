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
    public static Voucher operator +(Voucher v1, Voucher v2)
    {
        var mergedVoucher = new Voucher
        {
            DeliveryDate = v1.DeliveryDate > v2.DeliveryDate ? v1.DeliveryDate : v2.DeliveryDate,
            Details = new List<VoucherSub>()
        };

        var d1 = v1.Details;
        var d2 = v2.Details;
        var mergedDetails = d1.Concat(d2).ToList();
        
        var rowNum = 1;
        foreach (var detail in mergedDetails)
        {
            var existingDetail = mergedVoucher.Details.FirstOrDefault(d => d.Product.Code == detail.Product.Code);
            if (existingDetail != null && detail.Product.IsMergeable)
            {
                existingDetail.Quantity += detail.Quantity;
                existingDetail.Price = Math.Max(existingDetail.Price, detail.Price);
            }
            else
            {
                mergedVoucher.Details.Add(new VoucherSub(
                    rowNum++,
                    detail.Product,
                    detail.Quantity,
                    detail.Price
                ));
            }
        }
        mergedVoucher.TotalPrice = mergedVoucher.Details.Sum(d => d.Price * d.Quantity);
        return mergedVoucher;
    }
}
