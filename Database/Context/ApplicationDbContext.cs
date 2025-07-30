// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using System.Globalization;
using Database.Context.EntityConfigurations;
using Database.Seeders;

namespace Database.Context;

public partial class ApplicationDbContext : DbContext {
  /// <summary>The database configuration</summary>
  private readonly DbConfiguration _config;

  /// <summary>
  /// Class constructor
  /// </summary>
  public ApplicationDbContext() {
  }

  /// <summary>
  /// Class constructor
  /// </summary>
  /// <param name="config">Database configuration</param>
  public ApplicationDbContext(DbConfiguration config) {
    _config = config;
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
  }

  /// <summary>
  /// Class constructor
  /// </summary>
  /// <param name="options">Database options</param>
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) {
  }

  /// <summary>Prints the query result to the console</summary>
  /// <param name="message">Message details</param>
  private void LogToConsole(string message) {
    if (_config.LogEnabled) Console.WriteLine(message);
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    optionsBuilder.UseNpgsql(_config.ConnectionString, options =>
        options.ConfigureDataSource(builder => {
          // Parse JSON as dynamic Object
          // See: https://www.npgsql.org/doc/types/json.html?tabs=datasource
          builder
            .EnableDynamicJson()
            .ConfigureJsonOptions(new JsonSerializerOptions(JsonSerializerDefaults.Web));
        }))
      // use snake_care for table and columns name explicitly 
      .UseSnakeCaseNamingConvention(CultureInfo.InvariantCulture)
      .EnableDetailedErrors()
      /*.UseAsyncSeeding((context, _, token)
        => new SeederContext(context).InitializeAsync(token))
      .UseSeeding((_, _) => { })*/
      .LogTo(LogToConsole, _config.LogLevel);
  }

  protected override void OnModelCreating(ModelBuilder builder) {
    builder.ApplyConfiguration(new BrandEntityTypeConfiguration());
    builder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
    builder.ApplyConfiguration(new PasswordResetTokenEntityTypeConfiguration());
    builder.ApplyConfiguration(new ProductCategoryEntityTypeConfiguration());
    builder.ApplyConfiguration(new ProductEntityTypeConfiguration());
    builder.ApplyConfiguration(new ProductImageEntityTypeConfiguration());
    builder.ApplyConfiguration(new PurchaseEntityTypeConfiguration());
    builder.ApplyConfiguration(new PurchaseItemEntityTypeConfiguration());
    builder.ApplyConfiguration(new ReturnPurchaseEntityTypeConfiguration());
    builder.ApplyConfiguration(new ReturnPurchaseItemEntityTypeConfiguration());
    builder.ApplyConfiguration(new SaleEntityTypeConfiguration());
    builder.ApplyConfiguration(new SaleItemEntityTypeConfiguration());
    builder.ApplyConfiguration(new SaleReturnEntityTypeConfiguration());
    builder.ApplyConfiguration(new SaleReturnItemEntityTypeConfiguration());
    builder.ApplyConfiguration(new SessionEntityTypeConfiguration());
    builder.ApplyConfiguration(new SupplierEntityTypeConfiguration());
    builder.ApplyConfiguration(new TransferEntityTypeConfiguration());
    builder.ApplyConfiguration(new TransferItemEntityTypeConfiguration());
    builder.ApplyConfiguration(new UserEntityTypeConfiguration());
    builder.ApplyConfiguration(new WarehouseEntityTypeConfiguration());
    OnModelCreatingPartial(builder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

  /// <inheritdoc/>
  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new()) {
    var modifiedEntities = ChangeTracker.Entries();

    foreach (var entity in modifiedEntities) {
      if (entity.Entity is EntityBase model)
        await model.OnTrackChangesAsync(entity.State, cancellationToken);
    }

    return await base.SaveChangesAsync(cancellationToken);
  }
}