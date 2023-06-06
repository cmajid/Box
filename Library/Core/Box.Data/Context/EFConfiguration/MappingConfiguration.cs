using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using Box.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Box.Data.EntityFramework
{
	public class MappingConfiguration
	{
        public class DataFileMappingConfiguration : BaseEntityConfiguration<DataFile>
        {
            public override void Configure(EntityTypeBuilder<DataFile> builder)
            {
                base.Configure(builder);

                builder.Property(p => p.Extention).HasMaxLength(10);
                builder.Property(p => p.SystemName).IsRequired().HasMaxLength(64);
                builder.Property(p => p.CreatedDatetime).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
                builder.Property(p => p.UpdatedDateTime).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
                builder.Property(p => p.UserId).IsRequired();
                builder.Property(p => p.UserName).IsRequired().HasMaxLength(64);
                builder.HasIndex(p => p.SystemName).IsUnique();
            }
        }

        public class DownloadMappingConfiguration : BaseEntityConfiguration<Download>
        {
            public override void Configure(EntityTypeBuilder<Download> builder)
            {
                base.Configure(builder);

                builder.Property(p => p.FileId).IsRequired();
                builder.Property(p => p.CreateDateTime).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
                builder.HasIndex(p => p.FileId);
            }
        }

        public class UserMappingConfiguration : BaseEntityConfiguration<User>
        {
            public override void Configure(EntityTypeBuilder<User> builder)
            {
                base.Configure(builder);

                builder.Property(p => p.Username).IsRequired().HasMaxLength(64);
                builder.Property(p => p.PasswordHash).IsRequired().HasMaxLength(64);
                builder.HasIndex(p => p.Username).IsUnique();
            }
        }
    }
}

