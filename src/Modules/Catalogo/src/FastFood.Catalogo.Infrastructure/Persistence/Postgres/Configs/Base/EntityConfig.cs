using FastFood.Catalogo.Infrastructure.Persistence.Postgres.Configs.Converters;
using FastFood.Contracts.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Catalogo.Infrastructure.Persistence.Postgres.Configs.Base;

public abstract class EntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(typeof(TEntity).Name);
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion<UlidToStringConverter>();
        
        ConfigureFields(builder);
    }

    protected abstract void ConfigureFields(EntityTypeBuilder<TEntity> builder);
}