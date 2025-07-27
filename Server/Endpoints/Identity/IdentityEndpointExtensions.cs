﻿// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Server.Endpoints.Identity;

namespace Server.Endpoints.Identity;

public static class IdentityEndpointExtensions {
  public static IEndpointRouteBuilder MapIdentityEndpoints(this IEndpointRouteBuilder app) {
    app.MapSignupIdentity();
    app.MapPasswordResetRequestIdentity();
    app.MapPasswordResetIdentity();
    return app;
  }
}