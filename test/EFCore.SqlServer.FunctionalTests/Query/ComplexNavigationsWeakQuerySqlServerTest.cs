// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query
{
    public class ComplexNavigationsWeakQuerySqlServerTest : ComplexNavigationsWeakQueryTestBase<ComplexNavigationsWeakQuerySqlServerFixture>
    {
        public ComplexNavigationsWeakQuerySqlServerTest(
            ComplexNavigationsWeakQuerySqlServerFixture fixture, ITestOutputHelper testOutputHelper)
            : base(fixture)
        {
            Fixture.TestSqlLoggerFactory.Clear();
            //Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
        }

        public override async Task Simple_owned_level1(bool isAsync)
        {
            await base.Simple_owned_level1(isAsync);

            AssertSql(
                @"SELECT [l1].[Id], [l1].[Date], [l1].[Name], [l1].[Id], [l1].[OneToOne_Required_PK_Date], [l1].[Level1_Optional_Id], [l1].[Level1_Required_Id], [l1].[Level2_Name], [l1].[OneToMany_Optional_Inverse2Id], [l1].[OneToMany_Required_Inverse2Id], [l1].[OneToOne_Optional_PK_Inverse2Id]
FROM [Level1] AS [l1]");
        }

        public override async Task Simple_owned_level1_convention(bool isAsync)
        {
            await base.Simple_owned_level1_convention(isAsync);

            AssertSql(
                @"SELECT [l].[Id], [l].[Date], [l].[Name]
FROM [Level1] AS [l]");
        }

        public override async Task Simple_owned_level1_level2(bool isAsync)
        {
            await base.Simple_owned_level1_level2(isAsync);

            AssertSql(
                @"SELECT [l1].[Id], [l1].[Date], [l1].[Name], [l1].[Id], [l1].[OneToOne_Required_PK_Date], [l1].[Level1_Optional_Id], [l1].[Level1_Required_Id], [l1].[Level2_Name], [l1].[OneToMany_Optional_Inverse2Id], [l1].[OneToMany_Required_Inverse2Id], [l1].[OneToOne_Optional_PK_Inverse2Id], [l1].[Id], [l1].[Level2_Optional_Id], [l1].[Level2_Required_Id], [l1].[Level3_Name], [l1].[OneToMany_Optional_Inverse3Id], [l1].[OneToMany_Required_Inverse3Id], [l1].[OneToOne_Optional_PK_Inverse3Id]
FROM [Level1] AS [l1]");
        }

        public override async Task Simple_owned_level1_level2_GroupBy_Count(bool isAsync)
        {
            await base.Simple_owned_level1_level2_GroupBy_Count(isAsync);

            AssertSql(
                @"SELECT COUNT(*)
FROM [Level1] AS [l1]
GROUP BY [l1].[Level3_Name]");
        }

        public override async Task Simple_owned_level1_level2_GroupBy_Having_Count(bool isAsync)
        {
            await base.Simple_owned_level1_level2_GroupBy_Having_Count(isAsync);

            AssertSql(
                @"SELECT COUNT(*)
FROM [Level1] AS [l1]
GROUP BY [l1].[Level3_Name]
HAVING MIN(COALESCE([l1].[Id], 0)) > 0");
        }

        public override async Task Simple_owned_level1_level2_level3(bool isAsync)
        {
            await base.Simple_owned_level1_level2_level3(isAsync);

            AssertSql(
                @"SELECT [l1].[Id], [l1].[Date], [l1].[Name], [l1].[Id], [l1].[OneToOne_Required_PK_Date], [l1].[Level1_Optional_Id], [l1].[Level1_Required_Id], [l1].[Level2_Name], [l1].[OneToMany_Optional_Inverse2Id], [l1].[OneToMany_Required_Inverse2Id], [l1].[OneToOne_Optional_PK_Inverse2Id], [l1].[Id], [l1].[Level2_Optional_Id], [l1].[Level2_Required_Id], [l1].[Level3_Name], [l1].[OneToMany_Optional_Inverse3Id], [l1].[OneToMany_Required_Inverse3Id], [l1].[OneToOne_Optional_PK_Inverse3Id], [l1].[Id], [l1].[Level3_Optional_Id], [l1].[Level3_Required_Id], [l1].[Level4_Name], [l1].[OneToMany_Optional_Inverse4Id], [l1].[OneToMany_Required_Inverse4Id], [l1].[OneToOne_Optional_PK_Inverse4Id]
FROM [Level1] AS [l1]");
        }

        public override async Task Nested_group_join_with_take(bool isAsync)
        {
            await base.Nested_group_join_with_take(isAsync);

            AssertSql(
                @"@__p_0='2'

SELECT [t3].[Level2_Name]
FROM (
    SELECT TOP(@__p_0) [t0].*
    FROM [Level1] AS [l1_inner]
    LEFT JOIN (
        SELECT [t].[Id], [t].[OneToOne_Required_PK_Date], [t].[Level1_Optional_Id], [t].[Level1_Required_Id], [t].[Level2_Name], [t].[OneToMany_Optional_Inverse2Id], [t].[OneToMany_Required_Inverse2Id], [t].[OneToOne_Optional_PK_Inverse2Id]
        FROM [Level1] AS [t]
        WHERE [t].[Id] IS NOT NULL
    ) AS [t0] ON [l1_inner].[Id] = [t0].[Level1_Optional_Id]
    ORDER BY [l1_inner].[Id]
) AS [t1]
LEFT JOIN (
    SELECT [t2].*
    FROM [Level1] AS [t2]
    WHERE [t2].[Id] IS NOT NULL
) AS [t3] ON [t1].[Id] = [t3].[Level1_Optional_Id]");
        }

        public override async Task Explicit_GroupJoin_in_subquery_with_unrelated_projection2(bool isAsync)
        {
            await base.Explicit_GroupJoin_in_subquery_with_unrelated_projection2(isAsync);

            AssertSql(
                @"SELECT [t1].[Id]
FROM (
    SELECT DISTINCT [l1].*
    FROM [Level1] AS [l1]
    LEFT JOIN (
        SELECT [t].*
        FROM [Level1] AS [t]
        WHERE [t].[Id] IS NOT NULL
    ) AS [t0] ON [l1].[Id] = [t0].[Level1_Optional_Id]
    WHERE ([t0].[Level2_Name] <> N'Foo') OR [t0].[Level2_Name] IS NULL
) AS [t1]");
        }

        public override async Task Result_operator_nav_prop_reference_optional_via_DefaultIfEmpty(bool isAsync)
        {
            await base.Result_operator_nav_prop_reference_optional_via_DefaultIfEmpty(isAsync);

            AssertSql(
                @"SELECT SUM(CASE
    WHEN [t0].[Id] IS NULL
    THEN 0 ELSE [t0].[Level1_Required_Id]
END)
FROM [Level1] AS [l1]
LEFT JOIN (
    SELECT [t].*
    FROM [Level1] AS [t]
    WHERE [t].[Id] IS NOT NULL
) AS [t0] ON [l1].[Id] = [t0].[Level1_Optional_Id]");
        }

        public override async Task SelectMany_with_Include1(bool isAsync)
        {
            await base.SelectMany_with_Include1(isAsync);

            AssertSql(
                @"SELECT [l1.OneToMany_Optional1].[Id], [l1.OneToMany_Optional1].[OneToOne_Required_PK_Date], [l1.OneToMany_Optional1].[Level1_Optional_Id], [l1.OneToMany_Optional1].[Level1_Required_Id], [l1.OneToMany_Optional1].[Level2_Name], [l1.OneToMany_Optional1].[OneToMany_Optional_Inverse2Id], [l1.OneToMany_Optional1].[OneToMany_Required_Inverse2Id], [l1.OneToMany_Optional1].[OneToOne_Optional_PK_Inverse2Id]
FROM [Level1] AS [l1]
INNER JOIN [Level1] AS [l1.OneToMany_Optional1] ON [l1].[Id] = [l1.OneToMany_Optional1].[OneToMany_Optional_Inverse2Id]
ORDER BY [l1.OneToMany_Optional1].[Id]",
                //
                @"SELECT [l1.OneToMany_Optional1.OneToMany_Optional2].[Id], [l1.OneToMany_Optional1.OneToMany_Optional2].[Level2_Optional_Id], [l1.OneToMany_Optional1.OneToMany_Optional2].[Level2_Required_Id], [l1.OneToMany_Optional1.OneToMany_Optional2].[Level3_Name], [l1.OneToMany_Optional1.OneToMany_Optional2].[OneToMany_Optional_Inverse3Id], [l1.OneToMany_Optional1.OneToMany_Optional2].[OneToMany_Required_Inverse3Id], [l1.OneToMany_Optional1.OneToMany_Optional2].[OneToOne_Optional_PK_Inverse3Id]
FROM [Level1] AS [l1.OneToMany_Optional1.OneToMany_Optional2]
INNER JOIN (
    SELECT DISTINCT [l1.OneToMany_Optional10].[Id]
    FROM [Level1] AS [l10]
    INNER JOIN [Level1] AS [l1.OneToMany_Optional10] ON [l10].[Id] = [l1.OneToMany_Optional10].[OneToMany_Optional_Inverse2Id]
) AS [t] ON [l1.OneToMany_Optional1.OneToMany_Optional2].[OneToMany_Optional_Inverse3Id] = [t].[Id]
ORDER BY [t].[Id]");
        }

        public override Task Key_equality_two_conditions_on_same_navigation2(bool isAsync)
        {
            return base.Key_equality_two_conditions_on_same_navigation2(isAsync);
        }

        public override Task Fubarbaz(bool isAsync)
        {
            return base.Fubarbaz(isAsync);
        }

        private void AssertSql(params string[] expected)
            => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

        private void AssertContainsSql(params string[] expected)
            => Fixture.TestSqlLoggerFactory.AssertBaseline(expected, assertOrder: false);
    }
}
