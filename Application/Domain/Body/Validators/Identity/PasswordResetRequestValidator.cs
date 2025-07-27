﻿// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Application.Requests.Payload.Identity;
using FluentValidation;

namespace Application.Domain.Body.Validators.Identity;

/// <summary>
/// Validator for password reset request.
/// </summary>
/// <remarks>
/// This validator ensures that the password reset payload meets the required criteria:
/// - Email is a valid email address and not empty
/// </remarks>
public class PasswordResetRequestPayloadValidator : AbstractValidator<PasswordResetRequestPayload> {
  public PasswordResetRequestPayloadValidator() {
    RuleFor(x => x.Email)
      .EmailAddress()
      .NotEmpty();
  }
}