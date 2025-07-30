// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Context;

public partial class ApplicationDbContext {
  /// <summary>Brands entity object</summary>
  public virtual DbSet<Brand> Brands { get; set; }

  /// <summary>Customers entity object</summary>
  public virtual DbSet<Customer> Customers { get; set; }

  /// <summary>PasswordResetTokens entity object</summary>
  public virtual DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

  /// <summary>Products entity object</summary>
  public virtual DbSet<Product> Products { get; set; }

  /// <summary>ProductCategories entity object</summary>
  public virtual DbSet<ProductCategory> ProductCategories { get; set; }

  /// <summary>ProductImages entity object</summary>
  public virtual DbSet<ProductImage> ProductImages { get; set; }

  /// <summary>Purchases entity object</summary>
  public virtual DbSet<Purchase> Purchases { get; set; }

  /// <summary>PurchaseItems entity object</summary>
  public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }

  /// <summary>ReturnPurchases entity object</summary>
  public virtual DbSet<ReturnPurchase> ReturnPurchases { get; set; }

  /// <summary>ReturnPurchaseItems entity object</summary>
  public virtual DbSet<ReturnPurchaseItem> ReturnPurchaseItems { get; set; }

  /// <summary>Sales entity object</summary>
  public virtual DbSet<Sale> Sales { get; set; }

  /// <summary>SaleItems entity object</summary>
  public virtual DbSet<SaleItem> SaleItems { get; set; }

  /// <summary>SaleReturns entity object</summary>
  public virtual DbSet<SaleReturn> SaleReturns { get; set; }

  /// <summary>SaleReturnItems entity object</summary>
  public virtual DbSet<SaleReturnItem> SaleReturnItems { get; set; }

  /// <summary>Sessions entity object</summary>
  public virtual DbSet<Session> Sessions { get; set; }

  /// <summary>Suppliers entity object</summary>
  public virtual DbSet<Supplier> Suppliers { get; set; }

  /// <summary>Transfers entity object</summary>
  public virtual DbSet<Transfer> Transfers { get; set; }

  /// <summary>TransferItems entity object</summary>
  public virtual DbSet<TransferItem> TransferItems { get; set; }

  /// <summary>Users entity object</summary>
  public virtual DbSet<User> Users { get; set; }

  /// <summary>Warehouses entity object</summary>
  public virtual DbSet<Warehouse> Warehouses { get; set; }
}