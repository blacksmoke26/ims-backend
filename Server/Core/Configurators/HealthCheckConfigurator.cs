﻿// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Application.Config;
using Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Server.Core.Configurators;

public abstract class HealthCheckConfigurator : IApplicationServiceConfigurator {
  /// <summary>
  /// Configures the health-check to the services collection
  /// </summary>
  /// <inheritdoc/>
  public static void Configure(IServiceCollection services, AppConfiguration _) {
    services.AddHealthChecks()
      .AddCheck<DatabaseHealthCheck>(DatabaseHealthCheck.Name);
  }

  /// <summary>
  /// Configures the health-check to the web application
  /// </summary>
  /// <inheritdoc/>
  public static void Use(WebApplication app) {
    app.MapHealthChecks("health-check");
  }
}

public class DatabaseHealthCheck(
  ApplicationDbContext dbContext,
  ILogger<DatabaseHealthCheck> logger
) : IHealthCheck {
  public const string Name = "Database";
  public const string Message = "Database is unhealthy";

  public async Task<HealthCheckResult> CheckHealthAsync(
    HealthCheckContext context, CancellationToken token = new()) {
    try {
      _ = await dbContext.Database.ExecuteSqlAsync($"SELECT 1", token);
      return HealthCheckResult.Healthy();
    }
    catch (Exception e) {
      logger.LogError(e, Message);
      return HealthCheckResult.Unhealthy(Message, e);
    }
  }
}