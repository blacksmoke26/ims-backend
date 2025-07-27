// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

using Server.Core.Extensions;
using Server.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InitBootstrapper(builder.Configuration);

var app = builder.Build();

app.CreateApiVersionSet(); 
app.UseBootstrapper();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  //app.UseHttpsRedirection();
}

app.MapApiEndpoints();

app.Run();