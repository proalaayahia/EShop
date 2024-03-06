using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EShop.Domain.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TEntity> Set<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.Interfaces)] TEntity>() where TEntity:class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
