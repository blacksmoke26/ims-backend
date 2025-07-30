// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class ProductCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ProductCategory> {
  public void Configure(EntityTypeBuilder<ProductCategory> entity) {
    entity.ToTable("product_categories");
    
    entity.HasKey(e => e.Id).HasName("product_categories_pkey");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.Name).HasComment("Name");
    entity.Property(e => e.Slug).HasComment("Slug");
    entity.Property(e => e.Status).HasComment("Status");
    entity.Property(e => e.UpdatedAt).HasComment("Updated");
  }
}