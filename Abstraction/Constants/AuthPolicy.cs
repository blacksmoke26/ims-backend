﻿// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Abstraction.Constants;

/// <summary>
/// AuthPolicies represents the JWT role policies
/// </summary>
public static class AuthPolicy {
  /// <summary>Applicable to `Admin` role</summary>
  public const string Admin = "Admin";

  /// <summary>Applicable to `User` role</summary>
  public const string User = "User";

  /// <summary>Applicable to signed-in users</summary>
  public const string Trusted = "Trusted";
}
