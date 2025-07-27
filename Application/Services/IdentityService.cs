// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Abstraction.Constants;
using Application.Config;
using Application.Helpers;
using Application.Requests.Payload;
using Database.Context;
using Database.Core.Extensions;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class IdentityService(
  UserRepository userRepository,
  IConfiguration config,
  ApplicationDbContext context
) : ServiceBase {
  /// <summary>HTTPContext items identity key name</summary>
  public const string IdentityKey = "%UserIdentity%";

  /// <summary>Logins the user by email and password</summary>
  /// <param name="input">The user DTO object</param>
  /// <param name="options">Additional login options</param>
  /// <param name="token">The cancellation token</param>
  /// <returns>The created user / null when failed</returns>
  public async Task<User?> LoginAsync(
    UserLoginCredentialPayload input, LoginOptions? options = null,
    CancellationToken token = default
  ) {
    var user = await userRepository.GetByEmailAsync(input.Email, token);

    if (user is null || !user.ValidatePassword(input.Password))
      ErrorHelper.ThrowError("Incorrect email address or password", ErrorCodes.AccessDenied);

    if (user.Status != UserStatus.Active)
      ThrowBadStatusException(user.Status);

    user.OnLogin(options?.IpAddress);
    
    await userRepository.UpdateAsync(user, token);
    return user;
  }

  /// <summary>User account status verification excluding "active"</summary>
  /// <param name="status">The status to verify</param>
  /// <exception cref="Exception">Throws when abnormal status detected</exception>
  private static void ThrowBadStatusException(UserStatus status) {
    if (status == UserStatus.Inactive)
      throw new Exception("Cannot signed in due to the pending account verification.");

    throw new Exception($"Your account has been ${status.ToString().ToLower()}");
  }

  /// <summary>Login the user as current identity against given JWT claims</summary>
  /// <param name="payload">The login claims object</param>
  /// <param name="options">Additional login options</param>
  /// <param name="token">The cancellation token</param>
  /// <returns>The created user / null when failed</returns>
  public async Task<User?> LoginWithClaimAsync(
    UserLoginClaimPayload payload, LoginOptions? options = null, CancellationToken token = default
  ) {
    var user = await userRepository.GetByAuthKeyAsync(payload.Jti, token);

    // The missing user, which means the auth-key is no longer valid
    ErrorHelper.ThrowIfNull(user,
      "Token may invalidated or user not found", 401, "TOKEN_INVALIDATED");

    // Either a user is unverified or insufficient status
    if (user.Status != UserStatus.Active)
      ThrowBadStatusException(user.Status);

    // Forcefully logged-out user globally
    ErrorHelper.ThrowWhenTrue(user.Metadata.Security.TokenInvalidate is true,
      "The token is either disabled or revoked. Please sign in again.",
      ErrorCodes.AccessRevoked);

    // Role mismatched. Tempered JWT "role" claim?
    ErrorHelper.ThrowWhenTrue(user.Role != payload.Role,
      "Ineligible authorization role", 403, "INELIGIBLE_ROLE");

    return user;
  }

  /// <summary>Creates a user</summary>
  /// <param name="user">The user instance</param>
  /// <param name="token">The cancellation token</param>
  /// <returns>The created user / null when failed</returns>
  public async Task<bool> LogoutAsync(User user, CancellationToken token = default) {
    var authConfig = config.GetSection("Authentication").Get<AuthenticationConfiguration>();

    if (authConfig.RefreshAuthKeyAfterLogout) {
      user.GenerateAuthKey();
    }

    user.OnLogout();

    return await userRepository.UpdateAsync(user, token) > 0;
  }
}