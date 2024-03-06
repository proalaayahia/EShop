using EShop.Domain.Primitives;

namespace EShop.Domain.Errors;

public static class DomainErrors
{
    public static class ProductErrors
    {
        //for example
        public static readonly Error NameNotFound = new("Product.NameNotFound", "Can't find product with this name");
    }
}
