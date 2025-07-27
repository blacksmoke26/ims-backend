// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Microsoft.Extensions.DependencyInjection;
using Application.Config;

namespace Application.Core.Interfaces;

public interface IServiceConfigurator {
  /// <param name="services">The ServiceCollection instance</param>
  /// <param name="config">The AppConfiguration instance</param>
  public static abstract void Configure(IServiceCollection services, AppConfiguration config);
}