using Application.Domain.Commons.Entities;
using Application.Domain.Commons.ValueObjects;

namespace Application.Drivens.PrimaryDb.Repositories;

public interface IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : BaseId
{
    Task TrackAsync(TEntity entity);

    Task<TEntity?> FindById(TId id);
}