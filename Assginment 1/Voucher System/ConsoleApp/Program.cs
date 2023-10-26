using ConsoleApp.Models;
using System.Text.Json;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mergeableProduct = new Product(1, "Mergeable Product", true);
            var nonMergeableProduct = new Product(2, "Non-Mergeable Product", false);

            var voucher1 = new Voucher() { DeliveryDate = DateTime.Now.AddDays(1), TotalPrice = 50};
            voucher1.Details.Add(new VoucherSub(1, mergeableProduct, 3, 10));
            voucher1.Details.Add(new VoucherSub(2, nonMergeableProduct, 1, 20));

            var voucher2 = new Voucher() { DeliveryDate = DateTime.Now.AddDays(1), TotalPrice = 30 };
            voucher2.Details.Add(new VoucherSub(1, mergeableProduct, 1, 10));
            voucher2.Details.Add(new VoucherSub(2, nonMergeableProduct, 1, 20));

            // fix here
            var result = voucher1 + voucher2;
            /*
             * output result
             * {
                    "DeliveryDate": "2023-09-30T03:15:07.1448946+03:30",
                     "TotalPrice": 80,
                      "Details": [
                                    {
                                      "RowNumber": 1,
                                      "Product": { "Code": 1, "Name": "Mergeable Product", "IsMergeable": true },
                                      "Quantity": 4,
                                      "Price": 10
                                    },
                                    {
                                      "RowNumber": 2,
                                      "Product": { "Code": 2, "Name": "Non-Mergeable Product", "IsMergeable": false },
                                      "Quantity": 1,
                                      "Price": 20
                                    },
                                    {
                                      "RowNumber": 3,
                                      "Product": { "Code": 2, "Name": "Non-Mergeable Product", "IsMergeable": false },
                                      "Quantity": 1,
                                      "Price": 20
                                    }
                                ]
                        }
             */



            Console.ReadLine();
        }

  
    }
}
