﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query
{
#if !Test21
    [SpatialiteRequired]
    public class SpatialQuerySqliteTest : SpatialQueryTestBase<SpatialQuerySqliteFixture>
    {
        public SpatialQuerySqliteTest(SpatialQuerySqliteFixture fixture, ITestOutputHelper testOutputHelper)
            : base(fixture)
        {
            Fixture.TestSqlLoggerFactory.Clear();
            //Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
        }

        public override async Task Area(bool isAsync)
        {
            await base.Area(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", Area(""e"".""Polygon"") AS ""Area""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task AsBinary(bool isAsync)
        {
            await base.AsBinary(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", AsBinary(""e"".""Point"") AS ""Binary""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task AsText(bool isAsync)
        {
            await base.AsText(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", AsText(""e"".""Point"") AS ""Text""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task Boundary(bool isAsync)
        {
            await base.Boundary(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", Boundary(""e"".""Polygon"") AS ""Boundary""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Buffer(bool isAsync)
        {
            await base.Buffer(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", Buffer(""e"".""Polygon"", 1.0) AS ""Buffer""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Buffer_quadrantSegments(bool isAsync)
        {
            await base.Buffer_quadrantSegments(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", Buffer(""e"".""Polygon"", 1.0, 8) AS ""Buffer""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Centroid(bool isAsync)
        {
            await base.Centroid(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", Centroid(""e"".""Polygon"") AS ""Centroid""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Contains(bool isAsync)
        {
            await base.Contains(isAsync);

            AssertSql(
                @"@__point_0='0x000100000000000000000000E03F000000000000D03F000000000000E03F0000...' (Size = 60) (DbType = String)

SELECT ""e"".""Id"", Contains(""e"".""Polygon"", @__point_0) AS ""Contains""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task ConvexHull(bool isAsync)
        {
            await base.ConvexHull(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", ConvexHull(""e"".""Polygon"") AS ""ConvexHull""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task IGeometryCollection_Count(bool isAsync)
        {
            await base.IGeometryCollection_Count(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", NumGeometries(""e"".""MultiLineString"") AS ""Count""
FROM ""MultiLineStringEntity"" AS ""e""");
        }

        public override async Task LineString_Count(bool isAsync)
        {
            await base.LineString_Count(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", NumPoints(""e"".""LineString"") AS ""Count""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task CoveredBy(bool isAsync)
        {
            await base.CoveredBy(isAsync);

            AssertSql(
                @"@__polygon_0='0x000100000000000000000000F0BF000000000000F0BF00000000000000400000...' (Size = 132) (DbType = String)

SELECT ""e"".""Id"", CoveredBy(""e"".""Point"", @__polygon_0) AS ""CoveredBy""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task Covers(bool isAsync)
        {
            await base.Covers(isAsync);

            AssertSql(
                @"@__point_0='0x000100000000000000000000E03F000000000000D03F000000000000E03F0000...' (Size = 60) (DbType = String)

SELECT ""e"".""Id"", Covers(""e"".""Polygon"", @__point_0) AS ""Covers""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Crosses(bool isAsync)
        {
            await base.Crosses(isAsync);

            AssertSql(
                @"@__lineString_0='0x000100000000000000000000E03F000000000000E0BF000000000000E03F0000...' (Size = 80) (DbType = String)

SELECT ""e"".""Id"", Crosses(""e"".""LineString"", @__lineString_0) AS ""Crosses""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task Difference(bool isAsync)
        {
            await base.Difference(isAsync);

            AssertSql(
                @"@__polygon_0='0x00010000000000000000000000000000000000000000000000000000F03F0000...' (Size = 116) (DbType = String)

SELECT ""e"".""Id"", Difference(""e"".""Polygon"", @__polygon_0) AS ""Difference""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Dimension(bool isAsync)
        {
            await base.Dimension(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", Dimension(""e"".""Point"") AS ""Dimension""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task Disjoint(bool isAsync)
        {
            await base.Disjoint(isAsync);

            AssertSql(
                @"@__point_0='0x000100000000000000000000F03F0000000000000000000000000000F03F0000...' (Size = 60) (DbType = String)

SELECT ""e"".""Id"", Disjoint(""e"".""Polygon"", @__point_0) AS ""Disjoint""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Distance(bool isAsync)
        {
            await base.Distance(isAsync);

            AssertSql(
                @"@__point_0='0x0001000000000000000000000000000000000000F03F00000000000000000000...' (Size = 60) (DbType = String)

SELECT ""e"".""Id"", Distance(""e"".""Point"", @__point_0) AS ""Distance""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task EndPoint(bool isAsync)
        {
            await base.EndPoint(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", EndPoint(""e"".""LineString"") AS ""EndPoint""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task Envelope(bool isAsync)
        {
            await base.Envelope(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", Envelope(""e"".""Polygon"") AS ""Envelope""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task EqualsTopologically(bool isAsync)
        {
            await base.EqualsTopologically(isAsync);

            AssertSql(
                @"@__point_0='0x0001000000000000000000000000000000000000000000000000000000000000...' (Size = 60) (DbType = String)

SELECT ""e"".""Id"", Equals(""e"".""Point"", @__point_0) AS ""EqualsTopologically""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task ExteriorRing(bool isAsync)
        {
            await base.ExteriorRing(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", ExteriorRing(""e"".""Polygon"") AS ""ExteriorRing""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task GetGeometryN(bool isAsync)
        {
            await base.GetGeometryN(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", GeometryN(""e"".""MultiLineString"", 0 + 1) AS ""Geometry0""
FROM ""MultiLineStringEntity"" AS ""e""");
        }

        public override async Task GetInteriorRingN(bool isAsync)
        {
            await base.GetInteriorRingN(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", InteriorRingN(""e"".""Polygon"", 0 + 1) AS ""InteriorRing0""
FROM ""PolygonEntity"" AS ""e""
WHERE NumInteriorRing(""e"".""Polygon"") > 0");
        }

        public override async Task GetPointN(bool isAsync)
        {
            await base.GetPointN(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", PointN(""e"".""LineString"", 0 + 1) AS ""Point0""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task Intersection(bool isAsync)
        {
            await base.Intersection(isAsync);

            AssertSql(
                @"@__polygon_0='0x00010000000000000000000000000000000000000000000000000000F03F0000...' (Size = 116) (DbType = String)

SELECT ""e"".""Id"", Intersection(""e"".""Polygon"", @__polygon_0) AS ""Intersection""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Intersects(bool isAsync)
        {
            await base.Intersects(isAsync);

            AssertSql(
                @"@__lineString_0='0x000100000000000000000000E03F000000000000E0BF000000000000E03F0000...' (Size = 80) (DbType = String)

SELECT ""e"".""Id"", Intersects(""e"".""LineString"", @__lineString_0) AS ""Intersects""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task ICurve_IsClosed(bool isAsync)
        {
            await base.ICurve_IsClosed(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", IsClosed(""e"".""LineString"") AS ""IsClosed""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task IMultiCurve_IsClosed(bool isAsync)
        {
            await base.IMultiCurve_IsClosed(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", IsClosed(""e"".""MultiLineString"") AS ""IsClosed""
FROM ""MultiLineStringEntity"" AS ""e""");
        }

        public override async Task IsEmpty(bool isAsync)
        {
            await base.IsEmpty(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", IsEmpty(""e"".""MultiLineString"") AS ""IsEmpty""
FROM ""MultiLineStringEntity"" AS ""e""");
        }

        public override async Task IsRing(bool isAsync)
        {
            await base.IsRing(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", IsRing(""e"".""LineString"") AS ""IsRing""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task IsSimple(bool isAsync)
        {
            await base.IsSimple(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", IsSimple(""e"".""LineString"") AS ""IsSimple""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task IsValid(bool isAsync)
        {
            await base.IsValid(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", IsValid(""e"".""Point"") AS ""IsValid""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task Item(bool isAsync)
        {
            await base.Item(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", GeometryN(""e"".""MultiLineString"", 0 + 1) AS ""Item0""
FROM ""MultiLineStringEntity"" AS ""e""");
        }

        public override async Task Length(bool isAsync)
        {
            await base.Length(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", GLength(""e"".""LineString"") AS ""Length""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task M(bool isAsync)
        {
            await base.M(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", M(""e"".""Point"") AS ""M""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task NumGeometries(bool isAsync)
        {
            await base.NumGeometries(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", NumGeometries(""e"".""MultiLineString"") AS ""NumGeometries""
FROM ""MultiLineStringEntity"" AS ""e""");
        }

        public override async Task NumInteriorRings(bool isAsync)
        {
            await base.NumInteriorRings(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", NumInteriorRing(""e"".""Polygon"") AS ""NumInteriorRings""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task NumPoints(bool isAsync)
        {
            await base.NumPoints(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", NumPoints(""e"".""LineString"") AS ""NumPoints""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task Overlaps(bool isAsync)
        {
            await base.Overlaps(isAsync);

            AssertSql(
                @"@__polygon_0='0x00010000000000000000000000000000000000000000000000000000F03F0000...' (Size = 116) (DbType = String)

SELECT ""e"".""Id"", Overlaps(""e"".""Polygon"", @__polygon_0) AS ""Overlaps""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task PointOnSurface(bool isAsync)
        {
            await base.PointOnSurface(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", PointOnSurface(""e"".""Polygon"") AS ""PointOnSurface"", ""e"".""Polygon""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Relate(bool isAsync)
        {
            await base.Relate(isAsync);

            AssertSql(
                @"@__polygon_0='0x00010000000000000000000000000000000000000000000000000000F03F0000...' (Size = 116) (DbType = String)

SELECT ""e"".""Id"", Relate(""e"".""Polygon"", @__polygon_0, '212111212') AS ""Relate""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Reverse(bool isAsync)
        {
            await base.Reverse(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", ST_Reverse(""e"".""LineString"") AS ""Reverse""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task SRID(bool isAsync)
        {
            await base.SRID(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", SRID(""e"".""Point"") AS ""SRID""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task StartPoint(bool isAsync)
        {
            await base.StartPoint(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", StartPoint(""e"".""LineString"") AS ""StartPoint""
FROM ""LineStringEntity"" AS ""e""");
        }

        public override async Task SymmetricDifference(bool isAsync)
        {
            await base.SymmetricDifference(isAsync);

            AssertSql(
                @"@__polygon_0='0x00010000000000000000000000000000000000000000000000000000F03F0000...' (Size = 116) (DbType = String)

SELECT ""e"".""Id"", SymDifference(""e"".""Polygon"", @__polygon_0) AS ""SymmetricDifference""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task ToBinary(bool isAsync)
        {
            await base.ToBinary(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", AsBinary(""e"".""Point"") AS ""Binary""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task ToText(bool isAsync)
        {
            await base.ToText(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", AsText(""e"".""Point"") AS ""Text""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task Touches(bool isAsync)
        {
            await base.Touches(isAsync);

            AssertSql(
                @"@__polygon_0='0x00010000000000000000000000000000000000000000000000000000F03F0000...' (Size = 116) (DbType = String)

SELECT ""e"".""Id"", Touches(""e"".""Polygon"", @__polygon_0) AS ""Touches""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Union(bool isAsync)
        {
            await base.Union(isAsync);

            AssertSql(
                @"@__polygon_0='0x00010000000000000000000000000000000000000000000000000000F03F0000...' (Size = 116) (DbType = String)

SELECT ""e"".""Id"", GUnion(""e"".""Polygon"", @__polygon_0) AS ""Union""
FROM ""PolygonEntity"" AS ""e""");
        }

        public override async Task Within(bool isAsync)
        {
            await base.Within(isAsync);

            AssertSql(
                @"@__polygon_0='0x000100000000000000000000F0BF000000000000F0BF00000000000000400000...' (Size = 132) (DbType = String)

SELECT ""e"".""Id"", Within(""e"".""Point"", @__polygon_0) AS ""Within""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task X(bool isAsync)
        {
            await base.X(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", X(""e"".""Point"") AS ""X""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task Y(bool isAsync)
        {
            await base.Y(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", Y(""e"".""Point"") AS ""Y""
FROM ""PointEntity"" AS ""e""");
        }

        public override async Task Z(bool isAsync)
        {
            await base.Z(isAsync);

            AssertSql(
                @"SELECT ""e"".""Id"", Z(""e"".""Point"") AS ""Z""
FROM ""PointEntity"" AS ""e""");
        }

        private void AssertSql(params string[] expected)
            => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
    }
#endif
}
