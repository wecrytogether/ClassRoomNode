using Application.Drivens.PrimaryDb.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Drivens.PrimaryDb;

public abstract class PrimaryDbCtx : DbContext
{
    public abstract IOrgRepository OrgRepo { get; init; }

    protected PrimaryDbCtx(DbContextOptions options) : base(options)
    {
    }

    protected PrimaryDbCtx()
    {
    }
}