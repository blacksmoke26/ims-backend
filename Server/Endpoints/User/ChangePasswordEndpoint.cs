// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Application.Domain.Body.Validators.User;
using Application.Helpers;
using Application.Requests.Payload.User;
using Application.Services;
using FluentValidation;
using Server.Core.Extensions;

namespace Server.Endpoints.User;

public static class ChangePasswordEndpoint {
  public const string Name = "ChangePassword";

  public static IEndpointRouteBuilder MapChangePassword(this IEndpointRouteBuilder app) {
    app.MapPost(ApiEndpoints.User.ChangePassword, async (
        ChangePasswordPayload body,
        UserService userService, HttpContext context,
        ChangePasswordValidator changePasswordValidator,
        CancellationToken token) => {
        await changePasswordValidator.ValidateAndThrowAsync(body, token);

        var isChanged = await userService.ChangePasswordAsync(
          context.GetIdentity().User, body.NewPassword, token);
        ErrorHelper.ThrowWhenFalse(isChanged,
          "Failed to change the password", ErrorCodes.ProcessFailed);

        return TypedResults.Ok(ResponseHelper.SuccessOnly());
      })
      .WithName(Name)
      .WithSummary("Change password")
      .WithDescription("Change the account password")
      .WithTags("User")
      .WithAuthorization()
      .WithVersioning(ApiVersions.V10)
      .Produces<SuccessOnlyResponse>()
      .Produces<OperationFailureResponse>(StatusCodes.Status400BadRequest)
      .Produces<ValidationFailureResponse>(StatusCodes.Status422UnprocessableEntity);

    return app;
  }
}