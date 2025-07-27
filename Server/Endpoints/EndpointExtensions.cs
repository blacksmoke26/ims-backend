// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Server.Endpoints.Auth;
using Server.Endpoints.Identity;
using Server.Endpoints.User;

namespace Server.Endpoints;

public static class EndpointExtensions {
  public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app) {
    app.MapAuthEndpoints();
    app.MapUserEndpoints();
    app.MapIdentityEndpoints();

    return app;
  }
}