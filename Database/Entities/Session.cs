// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using NpgsqlTypes;

namespace Database.Entities;

[Keyless]
[Table("sessions")]
[Index("LastActivity", Name = "IDX_sessions_last_activity")]
public partial class Session : EntityBase {
  /// <summary>ID</summary>
  [Column("id")]
  public long Id { get; set; }

  /// <summary>User</summary>
  [Column("user_id")]
  public long UserId { get; set; }

  /// <summary>IP address</summary>
  [Column("ip_address")]
  public NpgsqlCidr? IpAddress { get; set; }

  /// <summary>User agent</summary>
  [Column("user_agent")]
  public string? UserAgent { get; set; }

  /// <summary>Payload</summary>
  [Column("payload")]
  public string? Payload { get; set; }

  /// <summary>Last activity</summary>
  [Column("last_activity")]
  public long? LastActivity { get; set; }

  [ForeignKey("UserId")]
  public virtual User User { get; set; } = null!;
}