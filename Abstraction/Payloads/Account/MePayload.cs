// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Abstraction.Payloads.Account;

[Description("This class formats the successful user details response")]
public struct MePayload {
  [Description("The unique identifier")]
  public long Id { get; set; }

  [Description("The user's first name")]
  public string FirstName { get; init; }

  [Description("The user's last name")]
  public string LastName { get; init; }

  [Description("The email address")]
  public string Email { get; init; }

  [Description("The role name")]
  public RoleType Role { get; init; }

  [Description("Status")]
  public UserStatus Status { get; set; }

  [Description("Creation date")]
  public DateTime? CreatedAt { get; set; }
}