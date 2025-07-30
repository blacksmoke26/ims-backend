// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Database.Seeders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product> {
  public void Configure(EntityTypeBuilder<Product> entity) {
    entity.ToTable("products");

    entity.HasKey(e => e.Id).HasName("products_pkey");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.BrandId).HasComment("Brand");
    entity.Property(e => e.CategoryId).HasComment("Category");
    entity.Property(e => e.Code).HasComment("Code");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.Discount)
      .HasDefaultValueSql("0")
      .HasComment("Discount");
    entity.Property(e => e.Image).HasComment("Image");
    entity.Property(e => e.IsActive).HasComment("Active");
    entity.Property(e => e.Name).HasComment("Name");
    entity.Property(e => e.Note).HasComment("Note");
    entity.Property(e => e.Price)
      .HasDefaultValueSql("0")
      .HasComment("Price");
    entity.Property(e => e.Quantity)
      .HasDefaultValue(0L)
      .HasComment("Quantity");
    entity.Property(e => e.Status)
      .HasDefaultValue(10)
      .HasComment("Status");
    entity.Property(e => e.StockAlert)
      .HasDefaultValue(false)
      .HasComment("Stock alert");
    entity.Property(e => e.SupplierId).HasComment("Supplier");
    entity.Property(e => e.UpdatedAt).HasComment("Updated");
    entity.Property(e => e.WarehouseId).HasComment("Warehouse");

    entity.HasOne(d => d.Brand).WithMany(p => p.Products).OnDelete(DeleteBehavior.SetNull);

    entity.HasOne(d => d.Category).WithMany(p => p.Products)
      .OnDelete(DeleteBehavior.SetNull)
      .HasConstraintName("FK_products_categories_category_id");

    entity.HasOne(d => d.Supplier).WithMany(p => p.Products).OnDelete(DeleteBehavior.SetNull);

    entity.HasOne(d => d.Warehouse).WithMany(p => p.Products).OnDelete(DeleteBehavior.SetNull);

    entity.SeedData();
  }
}