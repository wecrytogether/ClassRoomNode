using Application.Domain.Commons.ValueObjects;
using Application.Domain.Organization.Entities;
using Application.Domain.Organization.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PrimaryDbSqlServer.EntityConfigurations;

public class OrgConfiguration : BaseEntityConfiguration<Org, OrgId>
{
    public override void Configure(EntityTypeBuilder<Org> builder)
    {
        base.Configure(builder);

        #region Indexes

        builder
            .HasIndex(o => o.Name)
            .IsUnique();

        builder
            .HasIndex(o => o.OwnerUserId);

        #endregion
        
        #region Columns

        builder
            .Property(o => o.Name)
            .HasConversion(
                name => name.Val,
                nameVal => new OrgName(nameVal))
            .HasColumnType("NVARCHAR(100)");
        
        builder
            .Property(o => o.OwnerUserId)
            .HasConversion(
                ownerId => ownerId.Val,
                ownerIdVal => new UserId(ownerIdVal))
            .HasColumnType("NVARCHAR(100)");

        #endregion

        #region RelationShips

        builder
            .HasMany(o => o.OrgMembers)
            .WithOne(m => m.Org);

        #endregion
    }
}