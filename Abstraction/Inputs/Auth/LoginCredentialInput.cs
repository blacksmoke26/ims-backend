// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Abstraction.Inputs.Auth;

[Description("Use to login the existing user with credentials")]
public struct LoginCredentialInput {
  [Description("The email address")]
  public string Email { get; init; }

  [Description("The password")]
  public string Password { get; init; }
}

public struct UserLoginClaimPayload {
  public string Jti { get; init; }
  public string Role { get; init; }
}