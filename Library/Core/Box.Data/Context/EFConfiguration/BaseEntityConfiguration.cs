using System;
using Box.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Box.Data.EntityFramework
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            var entitytype = typeof(TEntity);
            builder.ToTable($"{entitytype.Namespace.Split('.').Last()}_{entitytype.Name}");
        }
    }
}

