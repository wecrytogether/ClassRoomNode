using Application.Domain.Commons.ValueObjects;

namespace Application.Domain.Commons.Entities;

public abstract class BaseEntity<TId> 
    where TId : BaseId
{
    public TId Id { get; } = (TId)Activator.CreateInstance(typeof(TId), new [] { Guid.NewGuid() })!;

    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public DateTime? LastUpdatedAt { get; init; }
}