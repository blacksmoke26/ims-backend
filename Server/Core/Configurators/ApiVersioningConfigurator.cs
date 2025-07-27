﻿// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend
// Guide: https://github.com/dotnet/aspnet-api-versioning/wiki/Versioning-via-the-URL-Path
// Example: https://github.com/dotnet/aspnet-api-versioning/blob/main/examples/AspNetCore/WebApi/BasicExample
// Wiki: https://github.com/dotnet/aspnet-api-versioning/wiki/API-Version-Selector

using Asp.Versioning;
using Application.Config;

namespace Server.Core.Configurators;

/// <summary>
/// Provides the extensions methods to support API Versioning for the minimal api
/// <p>Read more about
/// <see href="https://github.com/dotnet/aspnet-api-versioning/wiki/API-Versioning-Options">API Versioning Options</see></p>
/// </summary>
internal abstract class ApiVersioningConfigurator : IServiceConfigurator {
  /// <summary>
  /// Configures the api-versioning to the service collection
  /// </summary>
  /// <inheritdoc/>
  public static void Configure(IServiceCollection services, AppConfiguration config) {
    services.AddApiVersioning(x => {
      // The default API version applied to services that do not have explicit versions
      x.DefaultApiVersion = new ApiVersion(ApiVersions.V10);
      // Indicating whether a default version is assumed when a client does not provide an API version.
      x.AssumeDefaultVersionWhenUnspecified = true;
      // Indicating whether requests report the API version compatibility information in responses.
      x.ReportApiVersions = true;
      // The HTTP status code used for unsupported versions of an API.
      x.UnsupportedApiVersionStatusCode = 501;
      // The name associated with the API version route constrain
      //x.RouteConstraintName = "version";
    });
  }
}