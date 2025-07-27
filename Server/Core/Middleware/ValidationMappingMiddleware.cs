﻿// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using System.Net;
using Application.Helpers;
using CaseConverter;
using FluentValidation;

namespace Server.Core.Middleware;

/// <summary>
/// Server middleware to normalize the validation errors caused by FluentValidation
/// </summary>
/// <param name="next">The middleware delegate</param>
public class ValidationMappingMiddleware(RequestDelegate next) {
  public async Task InvokeAsync(HttpContext context) {
    try {
      await next(context);
    }
    catch (ValidationException ex) {
      context.Response.StatusCode =
        (int)(ex.Data[ValidationHelper.StatusCodeKey] ?? HttpStatusCode.UnprocessableEntity);

      ValidationFailureResponse validationFailureResponse = new() {
        Message = ex.Message,
        ErrorCode = (string?)(ex.Data[ValidationHelper.ErrorCodeKey] ?? null),
        Errors = ex.Errors.Select(x => new ValidationResponse {
          PropertyName = x.PropertyName.ToCamelCase(),
          Message = x.ErrorMessage,
          ErrorCode = x.ErrorCode,
        })
      };

      await context.Response.WriteAsJsonAsync(validationFailureResponse.ToJson());
    }
  }
}