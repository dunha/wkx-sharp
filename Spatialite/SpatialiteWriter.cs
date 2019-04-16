namespace Wkx
{
    internal class SpatialiteWriter : WkbWriter
    {
        protected override void WriteWkbType(GeometryType geometryType, Dimension dimension, int? srid)
        {
            uint dimensionType = 0;

            switch (dimension)
            {
                case Dimension.Xyz: dimensionType = SpatialiteFlags.HasZ; break;
                case Dimension.Xym: dimensionType = SpatialiteFlags.HasM; break;
                case Dimension.Xyzm: dimensionType = SpatialiteFlags.HasZ | SpatialiteFlags.HasM; break;
            }

            if (srid.HasValue)
            {
                wkbWriter.Write(SpatialiteFlags.HasSrid + dimensionType + (uint)geometryType);
                wkbWriter.Write(srid.Value);
            }
            else
            {
                wkbWriter.Write(dimensionType + (uint)geometryType);
            }
        }
    }
}
