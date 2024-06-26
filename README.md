wkx-sharp 
========

A WKT/WKB/EWKT/EWKB parser and serializer with support for

- Point
- LineString
- Polygon
- MultiPoint
- MultiLineString
- MultiPolygon
- GeometryCollection
- CircularString
- CompoundCurve
- CurvePolygon
- MultiCurve
- MultiSurface
- PolyhedralSurface
- TIN
- Triangle


This project is forked from [cschwarz/wkx-sharp](https://github.com/cschwarz/wkx-sharp) and adds read/write support for Spatialite geometries.

Note: 
Spatialite only supports geometries as far as GeometryCollection in the list above.

Tests have been added for Spatialite geometries

Shapefile supports Point, Line and Poly and the multi versions. It does not support attributes, and cannot read/write SRID. SRID can be added to the Wkx geometry if known

To use it with Spatialite or Shapefile geometry go to the AdditionalFormats branch (not currently merged)
