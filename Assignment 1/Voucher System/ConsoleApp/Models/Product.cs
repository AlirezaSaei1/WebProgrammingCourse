namespace ConsoleApp.Models;

public class Product
{
    public int Code { get; set; }

    public string Name { get; set; } = null!;

    public bool IsMergeable { get; set; }

    public Product(int code, string name, bool isMergeable)
    {
        Code = code;
        Name = name;
        IsMergeable = isMergeable;
    }
}

