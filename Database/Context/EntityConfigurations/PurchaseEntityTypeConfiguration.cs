// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class PurchaseEntityTypeConfiguration : IEntityTypeConfiguration<Purchase> {
  public void Configure(EntityTypeBuilder<Purchase> entity) {
    entity.ToTable("purchases");

    entity.HasKey(e => e.Id).HasName("purchases_pkey");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.Date).HasComment("Purchase date");
    entity.Property(e => e.Discount)
      .HasDefaultValueSql("0.0")
      .HasComment("Discount");
    entity.Property(e => e.GrandTotal).HasComment("Grand total");
    entity.Property(e => e.Note).HasComment("Note");
    entity.Property(e => e.Shipping)
      .HasDefaultValueSql("0.0")
      .HasComment("Shipping");
    entity.Property(e => e.Status)
      .HasDefaultValue(10)
      .HasComment("Status");
    entity.Property(e => e.SupplierId).HasComment("Supplier");
    entity.Property(e => e.UpdatedAt).HasComment("Updated");
    entity.Property(e => e.WarehouseId).HasComment("Warehouse");
  }
}