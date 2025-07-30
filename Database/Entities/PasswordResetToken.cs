// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Entities;

[Table("password_reset_tokens")]
[Index("Email", Name = "UNQ_password_reset_tokens_email", IsUnique = true)]
public partial class PasswordResetToken : EntityBase {
  /// <summary>
  /// ID
  /// </summary>
  [Key] [Column("id")]
  public long Id { get; set; }

  /// <summary>
  /// Email address
  /// </summary>
  [Column("email")] [StringLength(255)]
  public string Email { get; set; } = null!;

  /// <summary>
  /// Token
  /// </summary>
  [Column("token")] [StringLength(255)]
  public string Token { get; set; } = null!;

  /// <summary>
  /// Created
  /// </summary>
  [Column("created_at", TypeName = "timestamp without time zone")]
  public DateTime? CreatedAt { get; set; }

  /// <inheritdoc/>
  public override Task OnTrackChangesAsync(EntityState state, CancellationToken token = default) {
    if (state is EntityState.Added) {
      CreatedAt = DateTime.UtcNow;
    }

    return Task.CompletedTask;
  }
}