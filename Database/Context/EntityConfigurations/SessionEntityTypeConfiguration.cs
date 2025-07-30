// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.EntityConfigurations;

internal sealed class SessionEntityTypeConfiguration : IEntityTypeConfiguration<Session> {
  public void Configure(EntityTypeBuilder<Session> entity) {
    entity.ToTable("sessions");
    
    entity.Property(e => e.Id)
      .ValueGeneratedOnAdd()
      .HasComment("ID");
    entity.Property(e => e.IpAddress).HasComment("IP address");
    entity.Property(e => e.LastActivity).HasComment("Last activity");
    entity.Property(e => e.Payload).HasComment("Payload");
    entity.Property(e => e.UserAgent).HasComment("User agent");
    entity.Property(e => e.UserId).HasComment("User");

    entity.HasOne(d => d.User).WithMany().HasConstraintName("sessions_users_user_id");

  }
}