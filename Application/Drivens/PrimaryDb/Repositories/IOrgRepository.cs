using Application.Domain.Organization.Entities;
using Application.Domain.Organization.ValueObjects;

namespace Application.Drivens.PrimaryDb.Repositories;

public interface IOrgRepository : IBaseRepository<Org, OrgId>
{
    
}