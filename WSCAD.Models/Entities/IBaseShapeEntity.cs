using GrapeCity.Documents.Svg;
using System.Drawing;

namespace WSCAD.Models.Entities
{
    public interface IBaseShapeEntity
    {
        public string Type { get; set; }
        public Color Color { get; set; }

        public void Draw(GcSvgDocument doc);
        public float MinX { get; set; }
        public float MinY { get; set; }
        public float MaxX { get; set; }
        public float MaxY { get; set; }
    }
}
