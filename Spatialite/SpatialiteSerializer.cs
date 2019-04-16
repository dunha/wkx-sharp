using System.IO;

namespace Wkx
{
    public class SpatialiteSerializer : IGeometrySerializer
    {
        public Geometry Deserialize(Stream stream)
        {
            return new SpatialiteWkbReader(stream).Read();
        }

        public void Serialize(Geometry geometry, Stream stream)
        {
            byte[] buffer = new Wkx.WkbWriter().Write(geometry);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
