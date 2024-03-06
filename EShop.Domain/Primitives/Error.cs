namespace EShop.Domain.Primitives;

public sealed record Error(string Code, string? Description = null)
{
    public static readonly Error None = new(string.Empty);
    public static implicit operator Result(Error error) => Result.Failure(error);//this will convert my error to result if my function's return type is result
}
