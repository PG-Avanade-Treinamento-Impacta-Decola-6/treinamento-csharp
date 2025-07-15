namespace _09_web_api.Requests;

public record ProductEditRequest(string Name, string Description, decimal Price, string ImageUrl, float AmountInStock, int CategoryId) { }