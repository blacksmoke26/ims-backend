// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Entities;

[Table("transfers")]
public partial class Transfer : EntityBase {
  /// <summary>ID</summary>
  [Key] [Column("id")]
  public long Id { get; set; }

  /// <summary>From warehouse</summary>
  [Column("from_warehouse_id")]
  public long FromWarehouseId { get; set; }

  /// <summary>To warehouse</summary>
  [Column("to_warehouse_id")]
  public long ToWarehouseId { get; set; }

  /// <summary>Discount</summary>
  [Column("discount")] [Precision(10, 2)]
  public decimal Discount { get; set; }

  /// <summary>Shipping</summary>
  [Column("shipping")] [Precision(10, 2)]
  public decimal Shipping { get; set; }

  /// <summary>Status</summary>
  [Column("status")]
  public int Status { get; set; }

  /// <summary>Note</summary>
  [Column("note")]
  public string? Note { get; set; }

  /// <summary>Grand total</summary>
  [Column("grand_total")] [Precision(15, 2)]
  public decimal GrandTotal { get; set; }

  /// <summary>Created</summary>
  [Column("created_at", TypeName = "timestamp without time zone")]
  public DateTime? CreatedAt { get; set; }

  /// <summary>Updated</summary>
  [Column("updated_at", TypeName = "timestamp without time zone")]
  public DateTime? UpdatedAt { get; set; }

  [ForeignKey("FromWarehouseId")] [InverseProperty("TransferFromWarehouses")]
  public virtual Warehouse FromWarehouse { get; set; } = null!;

  [ForeignKey("ToWarehouseId")] [InverseProperty("TransferToWarehouses")]
  public virtual Warehouse ToWarehouse { get; set; } = null!;

  [InverseProperty("Transfer")]
  public virtual ICollection<TransferItem> TransferItems { get; set; } = new List<TransferItem>();

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