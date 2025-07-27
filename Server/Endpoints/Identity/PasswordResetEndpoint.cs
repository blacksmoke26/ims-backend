// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Application.Domain.Body.Validators.Identity;
using Application.Helpers;
using Application.Requests.Payload.Identity;
using Application.Services;
using Database.Repositories;
using FluentValidation;
using Server.Core.Extensions;

namespace Server.Endpoints.Identity;

public static class PasswordResetEndpoint {
  public const string Name = "PasswordResetIdentity";

  public static IEndpointRouteBuilder MapPasswordResetIdentity(this IEndpointRouteBuilder app) {
    app.MapPost(ApiEndpoints.Identity.PasswordReset, async (PasswordResetPayload body,
        PasswordResetValidator passwordResetValidator,
        UserService userService,
        UserRepository userRepo,
        CancellationToken token
      ) => {
        await passwordResetValidator.ValidateAndThrowAsync(body, token);

        var user = await userRepo.GetByEmailAndResetCodeAsync(body.Email, body.ResetCode, token);

        ErrorHelper.ThrowIfNull(user,
          "Email address or reset code not found", ErrorCodes.NotFound);

        ErrorHelper.ThrowWhenTrue(user.Metadata.Password.IsResetCodeExpired(),
          "The reset code has been expired", ErrorCodes.BadRequest);

        ErrorHelper.ThrowWhenFalse(await userService.ResetPassword(user, body.NewPassword, token),
          "Process failed due to the unknown error", ErrorCodes.ProcessFailed);

        return TypedResults.Ok(ResponseHelper.SuccessOnly());
      })
      .WithName(Name)
      .WithSummary("Reset password")
      .WithDescription("Change account password using the Reset Code")
      .WithTags("Identity")
      .WithVersioning(ApiVersions.V10)
      .Produces<SuccessWithMessageResponse>()
      .Produces<OperationFailureResponse>(StatusCodes.Status400BadRequest)
      .Produces<OperationFailureResponse>(StatusCodes.Status404NotFound)
      .Produces<ValidationFailureResponse>(StatusCodes.Status422UnprocessableEntity);

    return app;
  }
}