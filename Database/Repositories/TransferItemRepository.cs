﻿// Licensed to the end users under one or more agreements.
// Copyright (c) 2025 Junaid Atari, and contributors
// Repository: https://github.com/blacksmoke26/ims-backend

namespace Database.Repositories;

public sealed class TransferItemRepository(ApplicationDbContext context) : RepositoryBase<TransferItem>(context) {
}