using FastFood.Atendimento.Infrastructure.Persistence.Postgres.Configs.Converters;
using FastFood.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Atendimento.Infrastructure.Persistence.Postgres.Configs.Base;

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