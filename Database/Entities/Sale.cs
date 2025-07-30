// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Entities;

[Table("sales")]
public partial class Sale : EntityBase {
  /// <summary>ID</summary>
  [Key] [Column("id")]
  public long Id { get; set; }

  /// <summary>Warehouse</summary>
  [Column("warehouse_id")]
  public long WarehouseId { get; set; }

  /// <summary>Customer</summary>
  [Column("customer_id")]
  public long CustomerId { get; set; }

  /// <summary>Date</summary>
  [Column("date")]
  public DateOnly Date { get; set; }

  /// <summary>Discount</summary>
  [Column("discount")] [Precision(10, 2)]
  public decimal? Discount { get; set; }

  /// <summary>Shipping</summary>
  [Column("shipping")] [Precision(10, 2)]
  public decimal? Shipping { get; set; }

  /// <summary>Status</summary>
  [Column("status")] [StringLength(255)]
  public string Status { get; set; } = null!;

  /// <summary>Note</summary>
  [Column("note")]
  public string? Note { get; set; }

  /// <summary>Grand total</summary>
  [Column("grand_total")] [Precision(15, 2)]
  public decimal GrandTotal { get; set; }

  /// <summary>Paid amount</summary>
  [Column("paid_amount")] [Precision(10, 2)]
  public decimal PaidAmount { get; set; }

  /// <summary>Due amount</summary>
  [Column("due_amount")] [Precision(10, 2)]
  public decimal DueAmount { get; set; }

  /// <summary>Full paid</summary>
  [Column("full_paid")] [Precision(10, 2)]
  public decimal? FullPaid { get; set; }

  /// <summary>Created</summary>
  [Column("created_at", TypeName = "timestamp without time zone")]
  public DateTime? CreatedAt { get; set; }

  /// <summary>Updated</summary>
  [Column("updated_at", TypeName = "timestamp without time zone")]
  public DateTime? UpdatedAt { get; set; }

  [ForeignKey("CustomerId")] [InverseProperty("Sales")]
  public virtual Customer Customer { get; set; } = null!;

  [InverseProperty("Id1")]
  public virtual SaleItem? SaleItem { get; set; }

  [ForeignKey("WarehouseId")] [InverseProperty("Sales")]
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