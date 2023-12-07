using Application.Domain.Commons.Entities;
using Application.Domain.Commons.ValueObjects;
using Application.Drivens.PrimaryDb.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PrimaryDbSqlServer.Repositories;

internal record BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : BaseId
{
    protected readonly PrimaryDbSqlServerCtx DbCtx;
    protected readonly DbSet<TEntity> Resource;

    protected BaseRepository(PrimaryDbSqlServerCtx dbCtx)
    {
        DbCtx = dbCtx;
        Resource = dbCtx.Set<TEntity>();
    }
    
    public async Task TrackAsync(TEntity entity)
    {
        await Resource.AddAsync(entity);
    }

    public Task<TEntity?> FindById(TId id)
    {
        // TODO implement it, research auto include relationship by default
        throw new NotImplementedException();
    }
}