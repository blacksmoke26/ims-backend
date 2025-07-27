// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend


namespace Abstraction.Inputs.Identity;

[Description("Use to signup a new user account")]
public struct SignupInput {
  [Description("The first name of user")]
  public string FirstName { get; init; }

  [Description("The last name of user")]
  public string LastName { get; init; }

  [Description("The email address")]
  public string Email { get; init; }

  [Description("Password with alphanumeric chars along with symbols")]
  public string Password { get; init; }
}