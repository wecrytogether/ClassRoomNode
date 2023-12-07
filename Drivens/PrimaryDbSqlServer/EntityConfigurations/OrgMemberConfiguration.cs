using Application.Domain.Commons.ValueObjects;
using Application.Domain.Organization.Entities;
using Application.Domain.Organization.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PrimaryDbSqlServer.EntityConfigurations;

internal class OrgMemberConfiguration : BaseEntityConfiguration<OrgMember, OrgMemberId>
{
    public override void Configure(EntityTypeBuilder<OrgMember> builder)
    {
        base.Configure(builder);

        #region Indexes

        builder
            .HasIndex(o => o.UserId);

        #endregion

        #region Columns

        builder
            .Property(o => o.UserId)
            .HasConversion(
                userId => userId.Val,
                userIdVal => new UserId(userIdVal))
            .HasColumnType("NVARCHAR(100)");

        #endregion

        #region RelationShips

        builder
            .HasOne(o => o.Org)
            .WithMany(o => o.OrgMembers);

        #endregion
    }
}