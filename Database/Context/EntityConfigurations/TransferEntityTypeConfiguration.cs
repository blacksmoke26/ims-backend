// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class TransferEntityTypeConfiguration : IEntityTypeConfiguration<Transfer> {
  public void Configure(EntityTypeBuilder<Transfer> entity) {
    entity.ToTable("transfers");
    
    entity.HasKey(e => e.Id).HasName("transfers_pkey");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.Discount).HasComment("Discount");
    entity.Property(e => e.FromWarehouseId).HasComment("From warehouse");
    entity.Property(e => e.GrandTotal).HasComment("Grand total");
    entity.Property(e => e.Note).HasComment("Note");
    entity.Property(e => e.Shipping).HasComment("Shipping");
    entity.Property(e => e.Status).HasComment("Status");
    entity.Property(e => e.ToWarehouseId).HasComment("To warehouse");
    entity.Property(e => e.UpdatedAt).HasComment("Updated");
  }
}