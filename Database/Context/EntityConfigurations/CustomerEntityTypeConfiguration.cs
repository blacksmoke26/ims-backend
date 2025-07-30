// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Database.Seeders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer> {
  public void Configure(EntityTypeBuilder<Customer> entity) {
    entity.ToTable("customers");
    
    entity.HasKey(e => e.Id).HasName("PK_customers_id");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.Address).HasComment("Address");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.Email).HasComment("Email address");
    entity.Property(e => e.Name).HasComment("Name");
    entity.Property(e => e.Phone).HasComment("Phone no.");
    entity.Property(e => e.UpdatedAt).HasComment("Updated");

    entity.SeedData();
  }
}