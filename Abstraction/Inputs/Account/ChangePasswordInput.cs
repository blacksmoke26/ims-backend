// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Abstraction.Inputs.Account;

[Description("Use to change the account password")]
public struct ChangePasswordInput {
  [Description("The current password")] [property: Range(8, 20)]
  public string CurrentPassword { get; init; }

  [Description("The new password to update")] [property: Range(8, 20)]
  public string NewPassword { get; init; }
}