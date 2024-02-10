﻿using System.IO;

namespace Wkx
{
    public class SpatialiteSerializer : IGeometrySerializer
    {
        public Geometry Deserialize(Stream stream)
        {
            return new SpatialiteReader(stream).Read();
        }

        public void Serialize(Geometry geometry, Stream stream)
        {
            if (!geometry.Srid.HasValue)
                geometry.Srid = 0;
            byte[] buffer = new SpatialiteWriter().Write(geometry);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
