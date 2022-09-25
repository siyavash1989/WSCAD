using GrapeCity.Documents.Svg;
using System;
using WSCAD.Models.CommonModels;
namespace WSCAD.Models.Entities
{
    public class TriangleEntity: IBaseShapeEntity
    {
        private float _minX;
        private float _minY;
        private float _maxX;
        private float _maxY;
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public bool Filled { get; set; }
        public string Type { get; set; }
        public System.Drawing.Color Color { get; set; }
        public float MinX { get { return Math.Min(A.X, Math.Min(B.X, C.X)); } set { _minX = value; } }
        public float MinY { get { return Math.Min(A.Y, Math.Min(B.Y, C.Y)); } set { _minY = value; } }
        public float MaxX { get { return Math.Max(A.X, Math.Max(B.X, C.X)); } set { _maxX = value; } }
        public float MaxY { get { return Math.Max(A.Y, Math.Max(B.Y, C.Y)); } set { _maxY = value; } }
        public void Draw(GcSvgDocument doc)
        {
            var pb = new SvgPathBuilder();

            pb.AddMoveTo(false, A.X, A.Y);
            pb.AddLineTo(false, B.X, B.Y);
            pb.AddLineTo(false, C.X, C.Y);
            pb.AddLineTo(false, A.X, A.Y);
            pb.AddClosePath();

            var handles = new SvgPathElement();
            if (Filled)
            {
                handles = new SvgPathElement()
                {
                    PathData = pb.ToPathData(),
                    Fill = new SvgPaint(Color),
                    FillOpacity = 1,
                    Stroke = new SvgPaint(Color),
                };
            }
            else
            {
                handles = new SvgPathElement()
                {
                    PathData = pb.ToPathData(),
                    FillOpacity = 0,
                    Stroke = new SvgPaint(Color),
                };
            }
            

            doc.RootSvg.Children.Insert(0, handles);

        }

    }
}
