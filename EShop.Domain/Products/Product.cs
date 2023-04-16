namespace EShop.Domain.Products;

public class Product
{
    public ProductId Id { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Money Price { get; private set; } = null!;
    public SKU SKU { get; private set; } = null!;
}