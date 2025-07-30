// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Entities;

[Table("suppliers")]
[Index("Email", Name = "UNQ_suppliers_email", IsUnique = true)]
public partial class Supplier : EntityBase {
  /// <summary>ID</summary>
  [Key] [Column("id")]
  public long Id { get; set; }

  /// <summary>Name</summary>
  [Column("name")] [StringLength(100)]
  public string Name { get; set; } = null!;

  /// <summary>Email address</summary>
  [Column("email")] [StringLength(255)]
  public string? Email { get; set; }

  /// <summary>Phone no.</summary>
  [Column("phone")] [StringLength(30)]
  public string? Phone { get; set; }

  /// <summary>Address</summary>
  [Column("address")] [StringLength(255)]
  public string? Address { get; set; }

  /// <summary>Created</summary>
  [Column("created_at", TypeName = "timestamp without time zone")]
  public DateTime? CreatedAt { get; set; }

  /// <summary>Updated</summary>
  [Column("updated_at", TypeName = "timestamp without time zone")]
  public DateTime? UpdatedAt { get; set; }

  [InverseProperty("Supplier")]
  public virtual ICollection<Product> Products { get; set; } = new List<Product>();

  [InverseProperty("Supplier")]
  public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

  [InverseProperty("Supplier")]
  public virtual ICollection<ReturnPurchase> ReturnPurchases { get; set; } = new List<ReturnPurchase>();

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