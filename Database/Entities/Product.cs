// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Entities;

[Table("products")]
public partial class Product: EntityBase {
  /// <summary>
  /// ID
  /// </summary>
  [Key] [Column("id")]
  public long Id { get; set; }

  /// <summary>
  /// Category
  /// </summary>
  [Column("category_id")]
  public long? CategoryId { get; set; }

  /// <summary>
  /// Brand
  /// </summary>
  [Column("brand_id")]
  public long? BrandId { get; set; }

  /// <summary>
  /// Warehouse
  /// </summary>
  [Column("warehouse_id")]
  public long? WarehouseId { get; set; }

  /// <summary>
  /// Supplier
  /// </summary>
  [Column("supplier_id")]
  public long? SupplierId { get; set; }

  /// <summary>
  /// Name
  /// </summary>
  [Column("name")] [StringLength(100)]
  public string Name { get; set; } = null!;

  /// <summary>
  /// Code
  /// </summary>
  [Column("code")] [StringLength(100)]
  public string? Code { get; set; }

  /// <summary>
  /// Image
  /// </summary>
  [Column("image")] [StringLength(255)]
  public string? Image { get; set; }

  /// <summary>
  /// Price
  /// </summary>
  [Column("price")] [Precision(10, 2)]
  public decimal? Price { get; set; }

  /// <summary>
  /// Stock alert
  /// </summary>
  [Column("stock_alert")]
  public bool? StockAlert { get; set; }

  /// <summary>
  /// Note
  /// </summary>
  [Column("note")] [StringLength(255)]
  public string? Note { get; set; }

  /// <summary>
  /// Quantity
  /// </summary>
  [Column("quantity")]
  public long? Quantity { get; set; }

  /// <summary>
  /// Discount
  /// </summary>
  [Column("discount")] [Precision(10, 2)]
  public decimal? Discount { get; set; }

  /// <summary>
  /// Status
  /// </summary>
  [Column("status")]
  public int? Status { get; set; }

  /// <summary>
  /// Active
  /// </summary>
  [Column("is_active")]
  public bool? IsActive { get; set; }

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

  [ForeignKey("BrandId")] [InverseProperty("Products")]
  public virtual Brand? Brand { get; set; }

  [ForeignKey("CategoryId")] [InverseProperty("Products")]
  public virtual ProductCategory? Category { get; set; }

  [InverseProperty("Product")]
  public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

  [InverseProperty("Product")]
  public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

  [InverseProperty("Product")]
  public virtual ICollection<ReturnPurchaseItem> ReturnPurchaseItems { get; set; } = new List<ReturnPurchaseItem>();

  [InverseProperty("Product")]
  public virtual ICollection<SaleReturnItem> SaleReturnItems { get; set; } = new List<SaleReturnItem>();

  [ForeignKey("SupplierId")] [InverseProperty("Products")]
  public virtual Supplier? Supplier { get; set; }

  [InverseProperty("Product")]
  public virtual ICollection<TransferItem> TransferItems { get; set; } = new List<TransferItem>();

  [ForeignKey("WarehouseId")] [InverseProperty("Products")]
  public virtual Warehouse? Warehouse { get; set; }

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