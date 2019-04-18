using System.IO;

namespace Wkx
{
    internal class SpatialiteReader : SpatialiteWkbReader
    {
        internal SpatialiteReader(Stream stream)
            : base(stream)
        {
        }


        
        protected override GeometryType ReadGeometryType(uint type)
        {
            return (GeometryType)(type & 0XFF);
        }

        protected override Dimension ReadDimension(uint type)
        {
            if ((type & SpatialiteFlags.HasZ) == SpatialiteFlags.HasZ && (type & SpatialiteFlags.HasM) == SpatialiteFlags.HasM)
                return Dimension.Xyzm;
            else if ((type & SpatialiteFlags.HasZ) == SpatialiteFlags.HasZ)
                return Dimension.Xyz;
            else if ((type & SpatialiteFlags.HasM) == SpatialiteFlags.HasM)
                return Dimension.Xym;

            return Dimension.Xy;
        }

        protected override int? ReadSrid(uint type)
        {
            if ((type & SpatialiteFlags.HasSrid) == SpatialiteFlags.HasSrid)
                return spatialiteWkbReader.ReadInt32();

            return null;
        }
    }
}
