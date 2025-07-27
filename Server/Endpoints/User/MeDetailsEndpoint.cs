// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Application.Domain.Extensions;
using Application.Helpers;
using Server.Core.Extensions;

namespace Server.Endpoints.User;

public static class MeDetailsEndpoint {
  public const string Name = "MeDetails";

  public static IEndpointRouteBuilder MapMeDetails(this IEndpointRouteBuilder app) {
    app.MapGet(ApiEndpoints.User.Me, (
        HttpContext context) => {
        var meDetails = context.GetIdentity().User.ToMeDetails();
        return TypedResults.Ok(ResponseHelper.SuccessWithData(meDetails));
      })
      .WithName(Name)
      .WithSummary("Me")
      .WithDescription("Fetch the account information")
      .WithTags("User")
      .WithAuthorization()
      .WithVersioning(ApiVersions.V10)
      .Produces<SuccessResponse<UserMeResponse>>();

    return app;
  }
}