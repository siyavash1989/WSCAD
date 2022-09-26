using GrapeCity.Documents.Svg;
using System.Collections.Generic;
using System.Drawing;

namespace WSCAD.Models.Entities
{
    public class CircleEntity: IBaseShapeEntity
    {
        private float _minX;
        private float _minY;
        private float _maxX;
        private float _maxY;
        public CommonModels.Point Center { get; set; }
        public float Radius { get; set; }
        public bool Filled { get; set; }
        public string Type { get; set; }
        public Color Color { get; set; }
        public float MinX { get { return Center.X - Radius; } set { _minX = value; } }
        public float MinY { get { return Center.Y - Radius; } set { _minY = value; } }
        public float MaxX { get { return Center.X + Radius; } set { _maxX = value; } }
        public float MaxY { get { return Center.Y + Radius; } set { _maxY = value; } }

        public void Draw(GcSvgDocument doc)
        {
            var innerCircle = new SvgCircleElement();
            
            if (Filled)
            {
                var attrs = new List<SvgCustomAttribute>();
                attrs.Add(new SvgCustomAttribute("style","fill:"+ Color.ColorToColorString() + ";stroke:" + Color.ColorToColorString()));
                innerCircle = new SvgCircleElement()
                {
                    CenterX = new SvgLength(Center.X, SvgLengthUnits.Pixels),
                    CenterY = new SvgLength(Center.Y, SvgLengthUnits.Pixels),
                    Radius = new SvgLength(Radius, SvgLengthUnits.Pixels),
                    CustomAttributes = attrs
                };
            }
            else
            {
                var attrs = new List<SvgCustomAttribute>();
                attrs.Add(new SvgCustomAttribute("style", "fill:rgba(0,0,0,0);stroke:" + Color.ColorToColorString()));

                innerCircle = new SvgCircleElement()
                {
                    CenterX = new SvgLength(Center.X, SvgLengthUnits.Pixels),
                    CenterY = new SvgLength(Center.Y, SvgLengthUnits.Pixels),
                    Radius = new SvgLength(Radius, SvgLengthUnits.Pixels),
                    CustomAttributes = attrs
                };
            }


            doc.RootSvg.Children.Insert(0, innerCircle);
        }

      
    }
}
