// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class ProductImageEntityTypeConfiguration : IEntityTypeConfiguration<ProductImage> {
  public void Configure(EntityTypeBuilder<ProductImage> entity) {
    entity.ToTable("product_images");

    entity.HasKey(e => e.Id).HasName("product_images_pkey");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.Image).HasComment("Image");
    entity.Property(e => e.ProductId).HasComment("Product");
    entity.Property(e => e.UpdatedAt).HasComment("Updated");
  }
}