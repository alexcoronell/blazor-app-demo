namespace blazor_app_demo;

public class Product
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public decimal? Price { get; set; }
    public required string Description { get; set; }
    public int CategoryId { get; set; }

    public string[]? Images { get; set; }
    public string? Image { get; set; }
}