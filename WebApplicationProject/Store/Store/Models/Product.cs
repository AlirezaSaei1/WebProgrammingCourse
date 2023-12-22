namespace WebApplicationProject.Models;

public class Product
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public List<string> Colors { get; set; }
    public List<string> Sizes { get; set; }
    public List<byte[]> Images { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public Category Category { get; set; }
    public User User { get; set; }
}