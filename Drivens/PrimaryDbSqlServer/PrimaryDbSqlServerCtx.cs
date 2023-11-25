using Application.Domain.Organization.Entities;
using Application.Drivens.PrimaryDb;
using Application.Drivens.PrimaryDb.Repositories;
using Microsoft.EntityFrameworkCore;
using PrimaryDbSqlServer.EntityConfigurations;
using PrimaryDbSqlServer.Repositories;

namespace PrimaryDbSqlServer;

public sealed class PrimaryDbSqlServerCtx : PrimaryDbCtx
{
    #region Repositories

    public override IOrgRepository OrgRepo { get; init; }

    #endregion
    
    #region DbSets

    public required DbSet<Org> Orgs { get; init; }
    public required DbSet<OrgMember> OrgMembers { get; init; }
    
    #endregion
    
    public PrimaryDbSqlServerCtx(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        OrgRepo = new OrgRepository(this);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration<,>).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}