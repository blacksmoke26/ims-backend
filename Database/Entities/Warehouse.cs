// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Entities;

[Table("warehouses")]
[Index("Email", Name = "UNQ_ware_houses_email", IsUnique = true)]
public partial class Warehouse: EntityBase {
  /// <summary>
  /// ID
  /// </summary>
  [Key] [Column("id")]
  public long Id { get; set; }

  /// <summary>
  /// Name
  /// </summary>
  [Column("name")] [StringLength(100)]
  public string Name { get; set; } = null!;

  /// <summary>
  /// Email address
  /// </summary>
  [Column("email")] [StringLength(255)]
  public string? Email { get; set; }

  /// <summary>
  /// Phone no.
  /// </summary>
  [Column("phone")] [StringLength(30)]
  public string? Phone { get; set; }

  /// <summary>
  /// City
  /// </summary>
  [Column("city")] [StringLength(50)]
  public string? City { get; set; }

  /// <summary>
  /// Created
  /// </summary>
  [Column("created_at", TypeName = "timestamp without time zone")]
  public DateTime? CreatedAt { get; set; }

  /// <summary>
  /// Updated
  /// </summary>
  [Column("updated_at", TypeName = "timestamp without time zone")]
  public DateTime? UpdatedAt { get; set; }

  [InverseProperty("Warehouse")]
  public virtual ICollection<Product> Products { get; set; } = new List<Product>();

  [InverseProperty("Warehouse")]
  public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

  [InverseProperty("Warehouse")]
  public virtual ICollection<ReturnPurchase> ReturnPurchases { get; set; } = new List<ReturnPurchase>();

  [InverseProperty("Warehouse")]
  public virtual ICollection<SaleReturn> SaleReturns { get; set; } = new List<SaleReturn>();

  [InverseProperty("Warehouse")]
  public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

  [InverseProperty("FromWarehouse")]
  public virtual ICollection<Transfer> TransferFromWarehouses { get; set; } = new List<Transfer>();

  [InverseProperty("ToWarehouse")]
  public virtual ICollection<Transfer> TransferToWarehouses { get; set; } = new List<Transfer>();

  /// <inheritdoc/>
  public override Task OnTrackChangesAsync(EntityState state, CancellationToken token = default) {
    if (state is EntityState.Added) {
      CreatedAt = DateTime.UtcNow;
    }

    if (state is EntityState.Added or EntityState.Modified) {
      UpdatedAt = DateTime.UtcNow;
    }

    return Task.CompletedTask;
  }}