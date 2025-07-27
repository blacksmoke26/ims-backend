// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Abstraction.Inputs.Identity;

[Description("Use to reset the account password")]
public struct ResetPasswordInput {
  [Description("The reset code")]
  public string ResetCode { get; init; }

  [Description("The email address")]
  public string Email { get; init; }

  [Description("The new password")]
  public string NewPassword { get; init; }
}