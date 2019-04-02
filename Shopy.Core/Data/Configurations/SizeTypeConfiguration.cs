﻿using Shopy.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Shopy.Core.Data.Configurations
{
    public class SizeTypeConfiguration : EntityTypeConfiguration<SizeTypeEF>
    {
        public SizeTypeConfiguration()
        {
            this.ToTable("size_type")
                .HasKey(s => s.SizeTypeEID);

            this.Property(s => s.SizeTypeEID)
                .HasColumnName("eid");

            this.Property(s => s.Caption)
                .HasColumnName("caption")
                .IsRequired();
        }
    }
}