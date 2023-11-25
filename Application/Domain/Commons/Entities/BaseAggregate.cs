using Application.Domain.Commons.ValueObjects;

namespace Application.Domain.Commons.Entities;

public abstract class BaseAggregate<TId> 
    : BaseEntity<TId> 
    where TId : BaseId
{

}