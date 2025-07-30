// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class SaleReturnItemEntityTypeConfiguration : IEntityTypeConfiguration<SaleReturnItem> {
  public void Configure(EntityTypeBuilder<SaleReturnItem> entity) {
    entity.ToTable("sale_return_items");

    entity.HasKey(e => e.Id).HasName("sale_return_items_pkey");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.Discount)
      .HasDefaultValueSql("0.00")
      .HasComment("Discount");
    entity.Property(e => e.NetUnitCost).HasComment("Net unit cost");
    entity.Property(e => e.ProductId).HasComment("Product");
    entity.Property(e => e.Quantity).HasComment("Quantity");
    entity.Property(e => e.SaleReturnId).HasComment("Sale return");
    entity.Property(e => e.Stock).HasComment("Stock");
    entity.Property(e => e.Subtotal)
      .HasDefaultValueSql("0.00")
      .HasComment("Subtotal");
    entity.Property(e => e.UpdatedAt).HasComment("Updated");
  }
}