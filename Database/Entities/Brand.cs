// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Entities;

[Table("brands")]
public partial class Brand : EntityBase {
  /// <summary>ID</summary>
  [Key] [Column("id")]
  public long Id { get; set; }

  /// <summary>Name</summary>
  [Column("name")] [StringLength(50)]
  public string Name { get; set; } = null!;

  /// <summary>Image</summary>
  [Column("image")] [StringLength(255)]
  public string? Image { get; set; }

  /// <summary>Status</summary>
  [Column("status")]
  public int? Status { get; set; }

  /// <summary>Created</summary>
  [Column("created_at", TypeName = "timestamp(0) without time zone")]
  public DateTime? CreatedAt { get; set; }

  /// <summary>Updated</summary>
  [Column("updated_at", TypeName = "timestamp(0) without time zone")]
  public DateTime? UpdatedAt { get; set; }

  [InverseProperty("Brand")]
  public virtual ICollection<Product> Products { get; set; } = new List<Product>();

  /// <inheritdoc/>
  public override Task OnTrackChangesAsync(EntityState state, CancellationToken token = default) {
    if (state is EntityState.Added) {
      CreatedAt = DateTime.UtcNow;
    }

    if (state is EntityState.Added or EntityState.Modified) {
      UpdatedAt = DateTime.UtcNow;
    }

    return Task.CompletedTask;
  }
}