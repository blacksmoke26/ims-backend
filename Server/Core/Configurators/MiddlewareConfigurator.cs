﻿// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Application.Config;
using Server.Core.Middleware;

namespace Server.Core.Configurators;

public abstract class MiddlewareConfigurator : IApplicationServiceConfigurator {
  /// <summary>
  /// Configures the middleware to the service collection
  /// </summary>
  /// <inheritdoc/>
  public static void Configure(IServiceCollection services, AppConfiguration config) {
    services.AddHttpContextAccessor();
  }

  /// <summary>
  /// Configures the middleware to the web application
  /// </summary>
  /// <inheritdoc/>
  public static void Use(WebApplication app) {
    app.UseMiddleware<ValidationMappingMiddleware>();
    app.UseMiddleware<AuthValidationMiddleware>();
  }
}