// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Microsoft.EntityFrameworkCore.Metadata
{
    public class SqlServerKeyAnnotations : RelationalKeyAnnotations, ISqlServerKeyAnnotations
    {
        public SqlServerKeyAnnotations([NotNull] IKey key)
            : base(key)
        {
        }

        protected SqlServerKeyAnnotations([NotNull] RelationalAnnotations annotations)
            : base(annotations)
        {
        }

        public virtual bool? IsClustered
        {
            get => (bool?)Annotations.Metadata[SqlServerAnnotationNames.Clustered];
            set => SetIsClustered(value);
        }

        protected virtual bool SetIsClustered(bool? value)
            => Annotations.SetAnnotation(SqlServerAnnotationNames.Clustered, value);
    }
}