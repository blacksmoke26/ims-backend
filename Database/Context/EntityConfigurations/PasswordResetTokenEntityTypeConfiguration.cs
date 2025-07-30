// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class PasswordResetTokenEntityTypeConfiguration : IEntityTypeConfiguration<PasswordResetToken> {
  public void Configure(EntityTypeBuilder<PasswordResetToken> entity) {
    entity.ToTable("password_reset_tokens");

    entity.HasKey(e => e.Id).HasName("password_reset_tokens_pkey");

    entity.Property(e => e.Id).HasComment("ID");
    entity.Property(e => e.CreatedAt).HasComment("Created");
    entity.Property(e => e.Email).HasComment("Email address");
    entity.Property(e => e.Token).HasComment("Token");
  }
}