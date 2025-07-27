﻿// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Application.Extensions;
using Application.Requests.Payload.User;
using Database.Core.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.Domain.Body.Validators.User;

/// <summary>
/// Validator for change password request.
/// </summary>
/// <remarks>
/// This validator ensures that the password reset payload meets the required criteria:
/// - Current password is valid and not empty
/// - New password is valid and not empty
/// </remarks>
public class ChangePasswordValidator : AbstractValidator<ChangePasswordPayload> {
  public ChangePasswordValidator(IHttpContextAccessor context) {
    RuleFor(x => x.CurrentPassword)
      .MinimumLength(6)
      .MaximumLength(20)
      .Must(value => context.HttpContext!.GetIdentity().User.ValidatePassword(value ?? string.Empty))
      .WithMessage("The current password is not valid")
      .NotEmpty();

    RuleFor(x => x.NewPassword)
      .MinimumLength(8)
      .MaximumLength(20)
      .Must((payload, value) => payload.CurrentPassword != (value ?? string.Empty))
      .WithMessage("The new password should be different")
      .NotEmpty();
  }
}