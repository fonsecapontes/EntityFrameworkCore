﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Cosmos.Sql.Storage.Internal;
using Microsoft.EntityFrameworkCore.Query;

namespace Microsoft.EntityFrameworkCore.Cosmos.Sql.Query.Internal
{
    public class CosmosSqlQueryContextFactory : QueryContextFactory
    {
        private readonly CosmosClient _cosmosClient;

        public CosmosSqlQueryContextFactory(
            [NotNull] QueryContextDependencies dependencies,
            [NotNull] CosmosClient cosmosClient)
               : base(dependencies)
        {
            _cosmosClient = cosmosClient;
        }

        public override QueryContext Create()
            => new CosmosSqlQueryContext(Dependencies, CreateQueryBuffer, _cosmosClient);
    }
}
