// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Server.Endpoints;

public static class ApiEndpoints {
  public const string ApiBase = "api/v{version:apiVersion}";

  public static class Auth {
    public const string Base = $"{ApiBase}/auth";
    public const string Login = $"{Base}/login";
    public const string Logout = $"{Base}/logout";
  }

  public static class Identity {
    public const string Base = $"{ApiBase}/identity";
    public const string Signup = $"{Base}/signup";
    public const string PasswordResetRequest = $"{Base}/password-reset-request";
    public const string PasswordReset = $"{Base}/password-reset";
  }

  public static class User {
    public const string Base = $"{ApiBase}/user";
    public const string Me = $"{Base}/me";
    public const string ChangePassword = $"{Base}/change-password";
  }
}