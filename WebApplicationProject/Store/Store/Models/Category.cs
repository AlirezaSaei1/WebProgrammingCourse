namespace WebApplicationProject.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Category> Children { get; set; }
    public Category Parent { get; set; }
    public List<byte[]> Image { get; set; }
    public List<Product> Products { get; set; }
}