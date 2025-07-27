// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Abstraction.Payloads.Account;

namespace Abstraction.Payloads.Auth;

public struct AuthLoginPayload {
  [JsonPropertyName("auth")]
  public AuthTokenResult Auth { get; init; }

  [JsonPropertyName("user")]
  public MePayload User { get; init; }
}

public struct AuthTokenResult {
  [JsonPropertyName("token")]
  public string Token { get; init; }

  [JsonPropertyName("issuedAt")]
  public DateTime IssuedAt { get; init; }

  [JsonPropertyName("expires")]
  public DateTime Expires { get; init; }
}