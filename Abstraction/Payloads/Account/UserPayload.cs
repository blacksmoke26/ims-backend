// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Abstraction.Payloads.Account;

[Description("The authenticated user details")]
public struct UserPayload {
  [Description("The unique identifier")]
  public long Id { get; set; }

  [Description("The user's first name")]
  public string FirstName { get; init; }

  [Description("The user's last name")]
  public string LastName { get; init; }
}