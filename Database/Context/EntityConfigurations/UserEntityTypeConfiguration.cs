// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Database.Seeders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<User> {
  public void Configure(EntityTypeBuilder<User> entity) {
    entity.ToTable("users");

    entity.HasKey(e => e.Id).HasName("users_pkey");

    entity.HasIndex(e => e.Metadata, "IDX_users_metadata")
      .HasMethod("gin")
      .HasAnnotation("Npgsql:StorageParameter:gin_pending_list_limit", "2097151");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.AuthKey).HasComment("Authorization Key");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.Email).HasComment("Email Address");
    entity.Property(e => e.FirstName).HasComment("First name");
    entity.Property(e => e.LastName).HasComment("Last name");
    entity.Property(e => e.Metadata).HasDefaultValueSql("'{}'::jsonb").HasComment("Metadata");
    entity.Property(e => e.Password).HasComment("Password");
    entity.Property(e => e.PasswordHash).HasComment("Password Hash");
    entity.Property(e => e.Role).HasComment("Role");
    entity.Property(e => e.Status).HasComment("Status");
    entity.Property(e => e.UpdatedAt).HasComment("Updated");
    
    entity.SeedData();
  }
}