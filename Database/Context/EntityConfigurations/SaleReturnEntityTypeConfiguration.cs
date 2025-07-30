// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class SaleReturnEntityTypeConfiguration : IEntityTypeConfiguration<SaleReturn> {
  public void Configure(EntityTypeBuilder<SaleReturn> entity) {
    entity.ToTable("sale_returns");

    entity.HasKey(e => e.Id).HasName("sale_returns_pkey");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.CustomerId).HasComment("Customer");
    entity.Property(e => e.Date).HasComment("Date");
    entity.Property(e => e.Discount).HasComment("Discount");
    entity.Property(e => e.DueAmount)
      .HasDefaultValueSql("0.00")
      .HasComment("Due amount");
    entity.Property(e => e.FullPaid)
      .HasDefaultValue(false)
      .HasComment("Full paid");
    entity.Property(e => e.GrandTotal).HasComment("Grand total");
    entity.Property(e => e.Note).HasComment("Note");
    entity.Property(e => e.PaidAmount)
      .HasDefaultValueSql("0.00")
      .HasComment("Paid amount");
    entity.Property(e => e.Shipping).HasComment("Shipping");
    entity.Property(e => e.Status).HasComment("Status");
    entity.Property(e => e.UpdatedAt).HasComment("Updated");
    entity.Property(e => e.WarehouseId).HasComment("Warehouse");
  }
}