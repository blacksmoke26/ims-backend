// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Entities;

[Table("purchase_items")]
public partial class PurchaseItem: EntityBase {
  /// <summary>
  /// ID
  /// </summary>
  [Key] [Column("id")]
  public long Id { get; set; }

  /// <summary>
  /// Purchase
  /// </summary>
  [Column("purchase_id")]
  public long PurchaseId { get; set; }

  /// <summary>
  /// Product
  /// </summary>
  [Column("product_id")]
  public long ProductId { get; set; }

  /// <summary>
  /// Net unit cost
  /// </summary>
  [Column("net_unit_cost")] [Precision(10, 2)]
  public decimal NetUnitCost { get; set; }

  /// <summary>
  /// Stock
  /// </summary>
  [Column("stock")]
  public long Stock { get; set; }

  /// <summary>
  /// Quantity
  /// </summary>
  [Column("quantity")]
  public long Quantity { get; set; }

  /// <summary>
  /// Discount
  /// </summary>
  [Column("discount")] [Precision(10, 2)]
  public decimal? Discount { get; set; }

  /// <summary>
  /// Subtotal
  /// </summary>
  [Column("subtotal")] [Precision(10, 2)]
  public decimal? Subtotal { get; set; }

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

  [ForeignKey("ProductId")] [InverseProperty("PurchaseItems")]
  public virtual Product Product { get; set; } = null!;

  [ForeignKey("PurchaseId")] [InverseProperty("PurchaseItems")]
  public virtual Purchase Purchase { get; set; } = null!;
 
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