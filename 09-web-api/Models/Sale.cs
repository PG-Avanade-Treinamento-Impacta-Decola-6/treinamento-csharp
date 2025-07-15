namespace _09_web_api.Models;

public class Sale
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public decimal Price => Product.Price *  Quantity;
    
    public Sale(Product product, int quantity)
    {
        Date = DateTime.Now;
        Product = product;
        Quantity = quantity;
    }

    public Sale() { }
}