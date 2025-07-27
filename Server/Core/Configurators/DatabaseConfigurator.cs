// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Application;
using Application.Config;

namespace Server.Core.Configurators;

public abstract class DatabaseConfigurator : IServiceConfigurator {
  /// <summary>
  /// Configures the database to the service collection
  /// </summary>
  /// <inheritdoc/>
  public static void Configure(IServiceCollection services, AppConfiguration config) {
    services.AddDatabase(config);
  }
}