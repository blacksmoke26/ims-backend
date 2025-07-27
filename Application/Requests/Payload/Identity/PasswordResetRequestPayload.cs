﻿// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.Requests.Payload.Identity;

[Description("Use to send a request for a password reset")]
public struct PasswordResetRequestPayload {
  [Required, JsonPropertyName("email"), Description("The email address")]
  [property: MaxLength(255)]
  public string Email { get; init; }
}