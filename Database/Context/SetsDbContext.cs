// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Context;

public partial class ApplicationDbContext {
  /// <summary>Users entity object</summary>
  public virtual DbSet<User> Users { get; set; }
}