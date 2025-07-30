// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Database.Seeders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class WarehouseEntityTypeConfiguration : IEntityTypeConfiguration<Warehouse> {
  public void Configure(EntityTypeBuilder<Warehouse> entity) {
    entity.ToTable("warehouses");
    
    entity.HasKey(e => e.Id).HasName("PK_warehouses_id");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.City).HasComment("City");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.Email).HasComment("Email address");
    entity.Property(e => e.Name).HasComment("Name");
    entity.Property(e => e.Phone).HasComment("Phone no.");
    entity.Property(e => e.UpdatedAt).HasComment("Updated");

    entity.SeedData();
  }
}