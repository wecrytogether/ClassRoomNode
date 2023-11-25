using Application.Domain.Commons.Entities;
using Application.Domain.Commons.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PrimaryDbSqlServer.EntityConfigurations;

public abstract class BaseEntityConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity<TId>
    where TId : BaseId
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .HasKey(e => e.Id);
        
        builder
            .Property(e => e.Id)
            .HasConversion(
                id => id.Val,
                idVal => (TId)Activator.CreateInstance(typeof(TId), new object[] { idVal })!);
        
        builder
            .Property(e => e.CreatedAt)
            .HasColumnType("DATETIME2");
        
        builder
            .Property(e => e.LastUpdatedAt)
            .IsRequired(false)
            .HasColumnType("DATETIME2");
    }
}