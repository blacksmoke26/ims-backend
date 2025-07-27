// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using System.Text;
using Abstraction.Constants;
using Application.Config;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Server.Core.Configurators;

public abstract class JwtAuthenticationConfigurator : IApplicationServiceConfigurator {
  /// <summary>
  /// Configures the JWT authentication and authorization to the service collection
  /// </summary>
  /// <inheritdoc/>
  public static void Configure(IServiceCollection services, AppConfiguration config) {
    services.AddAuthentication(x => {
      x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x => {
      x.TokenValidationParameters = new TokenValidationParameters() {
        IssuerSigningKey = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(config.JwtConfig().Key!)
        ),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = config.JwtConfig().Issuer,
        ValidAudience = config.JwtConfig().Audience,
        ValidateIssuer = true,
        ValidateAudience = true
      };
    });

    services.AddAuthorization(x => {
      // Policy Type: Admin
      x.AddPolicy(AuthPolicy.Admin, p
        => p.RequireRole(UserRole.Admin));

      // Policy Type: User
      x.AddPolicy(AuthPolicy.User, p
        => p.RequireRole(UserRole.User));

      // Policy Type: Trusted
      x.AddPolicy(AuthPolicy.Trusted, p
        => p.RequireRole(UserRole.Admin, UserRole.User));
    });

    services.AddSingleton<AuthService>(_ => new AuthService(config.JwtConfig()));
  }

  /// <summary>
  /// Configures the authentication to the web application
  /// </summary>
  /// <inheritdoc/>
  public static void Use(WebApplication app) {
    app.UseAuthentication();
    app.UseAuthorization();
  }
}