// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Database.Seeders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand> {
  public void Configure(EntityTypeBuilder<Brand> entity) {
    entity.ToTable("brands");

    entity.HasKey(e => e.Id).HasName("brands_pkey");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.Image).HasComment("Image");
    entity.Property(e => e.Name).HasComment("Name");
    entity.Property(e => e.Status)
      .HasDefaultValue(10)
      .HasComment("Status");
    entity.Property(e => e.UpdatedAt).HasComment("Updated");

    entity.SeedData();
  }
}