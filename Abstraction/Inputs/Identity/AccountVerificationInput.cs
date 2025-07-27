// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Abstraction.Inputs.Identity;

[Description("Use to fulfill the account verification")]
public struct AccountVerificationInput {
  [Description("The reset code")]
  public string Code { get; init; }

  [Description("The email address")]
  public string Email { get; init; }
}