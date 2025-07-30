// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Entities;

[Table("purchases")]
public partial class Purchase : EntityBase {
  /// <summary>
  /// ID
  /// </summary>
  [Key] [Column("id")]
  public long Id { get; set; }

  /// <summary>
  /// Warehouse
  /// </summary>
  [Column("warehouse_id")]
  public long WarehouseId { get; set; }

  /// <summary>
  /// Supplier
  /// </summary>
  [Column("supplier_id")]
  public long SupplierId { get; set; }

  /// <summary>
  /// Purchase date
  /// </summary>
  [Column("date")]
  public DateOnly Date { get; set; }

  /// <summary>
  /// Discount
  /// </summary>
  [Column("discount")] [Precision(10, 2)]
  public decimal? Discount { get; set; }

  /// <summary>
  /// Shipping
  /// </summary>
  [Column("shipping")] [Precision(10, 2)]
  public decimal? Shipping { get; set; }

  /// <summary>
  /// Status
  /// </summary>
  [Column("status")]
  public int? Status { get; set; }

  /// <summary>
  /// Note
  /// </summary>
  [Column("note")]
  public string? Note { get; set; }

  /// <summary>
  /// Grand total
  /// </summary>
  [Column("grand_total")] [Precision(15, 2)]
  public decimal? GrandTotal { get; set; }

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

  [InverseProperty("Purchase")]
  public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

  [ForeignKey("SupplierId")] [InverseProperty("Purchases")]
  public virtual Supplier Supplier { get; set; } = null!;

  [ForeignKey("WarehouseId")] [InverseProperty("Purchases")]
  public virtual Warehouse Warehouse { get; set; } = null!;
  
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