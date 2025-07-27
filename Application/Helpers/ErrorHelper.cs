﻿// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend
// Reference: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis
// Guide: https://endjin.com/blog/2020/08/dotnet-csharp-8-nullable-references-when-methods-dont-return
// Article: https://pvs-studio.com/en/blog/posts/csharp/1017/
// Article: https://www.meziantou.net/csharp-8-nullable-reference-types.htm

using System.Diagnostics.CodeAnalysis;
using FluentValidation;

namespace Application.Helpers;

public enum ErrorCodes {
  UnknownError = 0,
  NotFound = 1,
  BadRequest = 2,
  Unauthorized = 3,
  Forbidden = 4,
  Unavailable = 5,
  Unprocessable = 6,
  ProcessFailed = 7,
  DuplicateEntry = 8,
  AccessDenied = 9,
  AccessRevoked = 10,
}

public static class ErrorHelper {
  /// <summary>
  /// Returns the string error code against the `ErrorCode` type
  /// </summary>
  /// <param name="code">The error code</param>
  /// <returns>The string presentations of error code</returns>
  public static string GetErrorCode(ErrorCodes code) {
    return code switch {
      ErrorCodes.UnknownError => "UNKNOWN_ERROR",
      ErrorCodes.NotFound => "NOT_FOUND",
      ErrorCodes.BadRequest => "BAD_REQUEST",
      ErrorCodes.Unauthorized => "UNAUTHORIZED",
      ErrorCodes.Forbidden => "FORBIDDEN",
      ErrorCodes.Unavailable => "UNAVAILABLE",
      ErrorCodes.Unprocessable => "UNPROCESSABLE_ENTITY",
      ErrorCodes.ProcessFailed => "PROCESS_FAILED",
      ErrorCodes.DuplicateEntry => "DUPLICATE_ENTRY",
      ErrorCodes.AccessDenied => "ACCESS_DENIED",
      ErrorCodes.AccessRevoked => "ACCESS_REVOKED",
      _ => "BAD_REQUEST"
    };
  }

  /// <summary>
  /// Returns the string error message against the `ErrorCode` type
  /// </summary>
  /// <param name="code">The error code</param>
  /// <returns>The error message</returns>
  public static string GetErrorMessage(ErrorCodes code) {
    return code switch {
      ErrorCodes.UnknownError => "UNKNOWN_ERROR",
      ErrorCodes.NotFound => "Not found",
      ErrorCodes.BadRequest => "Bad request",
      ErrorCodes.Unauthorized => "Unauthorized",
      ErrorCodes.Forbidden => "Forbidden",
      ErrorCodes.Unavailable => "Unavailable",
      ErrorCodes.Unprocessable => "Unprocessable entity",
      ErrorCodes.ProcessFailed => "Process failed",
      ErrorCodes.DuplicateEntry => "Duplicate entry",
      ErrorCodes.AccessDenied => "Access denied",
      ErrorCodes.AccessRevoked => "ACCESS_REVOKED",
      _ => "Bad request"
    };
  }

  /// <summary>
  /// Returns the HTTP status code against the `ErrorCode` type
  /// </summary>
  /// <param name="code">The error code</param>
  /// <returns>The HTTP status code</returns>
  public static int GetStatusCode(ErrorCodes code) {
    return code switch {
      ErrorCodes.UnknownError
        or ErrorCodes.BadRequest
        or ErrorCodes.ProcessFailed
        or ErrorCodes.DuplicateEntry => 400,
      ErrorCodes.NotFound => 404,
      ErrorCodes.Unauthorized
        or ErrorCodes.AccessDenied => 401,
      ErrorCodes.Forbidden
        or ErrorCodes.AccessRevoked=> 403,
      ErrorCodes.Unavailable => 410,
      ErrorCodes.Unprocessable => 422,
      _ => 400
    };
  }

  /// <summary>Creates a custom HTTP error</summary>
  /// <param name="errorCode">The error code</param>
  /// <returns>The ValidationException instance</returns>
  public static ValidationException CustomError(
    ErrorCodes errorCode = ErrorCodes.BadRequest) {
    return CustomError(GetErrorMessage(errorCode), GetStatusCode(errorCode), GetErrorCode(errorCode));
  }

  /// <summary>Creates a custom HTTP error</summary>
  /// <param name="message">Error message</param>
  /// <param name="errorCode">The error code</param>
  /// <returns>The ValidationException instance</returns>
  public static ValidationException CustomError(
    string message, ErrorCodes errorCode = ErrorCodes.BadRequest) {
    return CustomError(message, GetStatusCode(errorCode), GetErrorCode(errorCode));
  }

  /// <summary>Creates a custom HTTP error</summary>
  /// <param name="message">Error message</param>
  /// <param name="statusCode">HTTP Status code (e.g., 400)</param>
  /// <param name="errorCode">The error code (e.g., "BAD_REQUEST")</param>
  /// <returns>The ValidationException instance</returns>
  public static ValidationException CustomError(
    string message, int statusCode = 400, ErrorCodes errorCode = ErrorCodes.BadRequest) {
    return CustomError(message, statusCode, GetErrorCode(errorCode));
  }

  /// <summary>Creates a custom HTTP error</summary>
  /// <param name="message">Error message</param>
  /// <param name="statusCode">HTTP Status code (e.g., 400)</param>
  /// <param name="errorCode">The error code (e.g., "BAD_REQUEST")</param>
  /// <returns>The ValidationException instance</returns>
  public static ValidationException CustomError(
    string message, int statusCode = 400, string errorCode = "BAD_REQUEST") {
    return ValidationHelper.Create([
      new() { ErrorMessage = message }
    ], statusCode, errorCode);
  }

  /// <summary>
  /// Throw an HTTP error with error message and error code
  /// </summary>
  /// <param name="message">The error message</param>
  /// <param name="errorCode">The error code</param>
  /// <exception cref="ValidationException"></exception>
  [DoesNotReturn]
  public static void ThrowError(
    string? message, ErrorCodes errorCode = ErrorCodes.BadRequest) {
    throw CustomError(message ?? GetErrorMessage(errorCode), GetStatusCode(errorCode), errorCode);
  }

  /// <summary>
  /// Throw an HTTP error message with the status code and custom error code
  /// </summary>
  /// <param name="message">The error message</param>
  /// <param name="statusCode">The HTTP status code</param>
  /// <param name="errorCode">The error code</param>
  /// <exception cref="ValidationException"></exception>
  [DoesNotReturn]
  public static void ThrowError(
    string message = "An unknown error occurred", int statusCode = 400, string errorCode = "BAD_REQUEST") {
    throw CustomError(message, statusCode, errorCode);
  }

  /// <summary>
  /// Throw an HTTP error if the given condition is null
  /// </summary>
  /// <param name="input">The nullable condition to verify</param>
  /// <param name="errorCode">The error code</param>
  /// <exception cref="ValidationException"></exception>
  public static void ThrowIfNull(
    [NotNull] object? input, ErrorCodes errorCode = ErrorCodes.BadRequest) {
    if (input is null) ThrowError(GetErrorMessage(errorCode), errorCode);
  }

  /// <summary>
  /// Throw an HTTP error if the given input is null
  /// </summary>
  /// <param name="input">The nullable input to verify</param>
  /// <param name="message">The error message</param>
  /// <param name="errorCode">The error code</param>
  /// <exception cref="ValidationException"></exception>
  public static void ThrowIfNull(
    [NotNull] object? input, string? message, ErrorCodes errorCode = ErrorCodes.BadRequest) {
    if (input is null) ThrowError(message, errorCode);
  }

  /// <summary>
  /// Throw an HTTP error if the given input is null
  /// </summary>
  /// <param name="input">The nullable input to verify</param>
  /// <param name="message">The error message</param>
  /// <param name="statusCode">HTTP Status code (e.g., 400)</param>
  /// <param name="errorCode">The error code (e.g., "BAD_REQUEST")</param>
  /// <exception cref="ValidationException"></exception>
  public static void ThrowIfNull(
    [NotNull] object? input, string message, int statusCode = 400, string errorCode = "BAD_REQUEST") {
    if (input is null) ThrowError(message, statusCode, errorCode);
  }

  /// <summary>
  /// Throw an HTTP error if the given condition is falsy
  /// </summary>
  /// <param name="condition">The nullable condition to verify</param>
  /// <param name="errorCode">The error code</param>
  /// <exception cref="ValidationException"></exception>
  public static void ThrowWhenFalse(
    [DoesNotReturnIf(false)] bool condition, ErrorCodes errorCode) {
    ThrowWhenFalse(condition, GetErrorMessage(errorCode), errorCode);
  }

  /// <summary>
  /// Throw an HTTP error if the given condition is falsy
  /// </summary>
  /// <param name="condition">The nullable condition to verify</param>
  /// <param name="message">The error message</param>
  /// <param name="errorCode">The error code (e.g., "BAD_REQUEST")</param>
  /// <exception cref="ValidationException"></exception>
  public static void ThrowWhenFalse(
    [DoesNotReturnIf(false)] bool condition, string message, ErrorCodes errorCode = ErrorCodes.BadRequest) {
    if (!condition) ThrowError(message, errorCode);
  }

  /// <summary>
  /// Throw an HTTP error if the given condition is falsy
  /// </summary>
  /// <param name="condition">The nullable condition to verify</param>
  /// <param name="message">The error message</param>
  /// <param name="statusCode">HTTP Status code (e.g., 400)</param>
  /// <param name="errorCode">The error code (e.g., "BAD_REQUEST")</param>
  /// <exception cref="ValidationException"></exception>
  public static void ThrowWhenFalse(
    [DoesNotReturnIf(false)] bool condition, string message, int statusCode = 400, string errorCode = "BAD_REQUEST") {
    if (!condition) ThrowError(message, statusCode, errorCode);
  }

  /// <summary>
  /// Throw an HTTP error if the given condition is falsy
  /// </summary>
  /// <param name="condition">The nullable condition to verify</param>
  /// <param name="errorCode">The error code</param>
  /// <exception cref="ValidationException"></exception>
  public static void ThrowWhenTrue(
    [DoesNotReturnIf(true)]bool condition, ErrorCodes errorCode = ErrorCodes.BadRequest) {
    if (condition) ThrowError(null, errorCode);
  }

  /// <summary>
  /// Throw an HTTP error if the given condition is falsy
  /// </summary>
  /// <param name="condition">The nullable condition to verify</param>
  /// <param name="message">The error message</param>
  /// <param name="errorCode">The error code</param>
  /// <exception cref="ValidationException"></exception>
  public static void ThrowWhenTrue(
    [DoesNotReturnIf(true)] bool condition, string message, ErrorCodes errorCode = ErrorCodes.BadRequest) {
    if (condition) ThrowError(message, errorCode);
  }

  /// <summary>
  /// Throw an HTTP error if the given condition is falsy
  /// </summary>
  /// <param name="condition">The nullable condition to verify</param>
  /// <param name="message">The error message</param>
  /// <param name="statusCode">HTTP Status code (e.g., 400)</param>
  /// <param name="errorCode">The error code (e.g., "BAD_REQUEST")</param>
  /// <exception cref="ValidationException"></exception>
  public static void ThrowWhenTrue(
    [DoesNotReturnIf(true)] bool condition, string message, int statusCode = 400, string errorCode = "BAD_REQUEST") {
    if (condition) ThrowError(message, statusCode, errorCode);
  }
}