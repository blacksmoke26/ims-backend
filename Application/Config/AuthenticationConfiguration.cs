// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend
// See also https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/examples
// See also https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments

namespace Application.Config;

/// <summary>
/// AuthenticationConfiguration presents the options required by the `Authentication` process
/// <p>Check <see cref="DatabaseConfiguration"/> class for usage.</p>
/// </summary>
public struct AuthenticationConfiguration {
  /// <summary>Expires token and regenerates the authentication key after logout</summary>
  public bool RefreshAuthKeyAfterLogout { get; init; }
}
