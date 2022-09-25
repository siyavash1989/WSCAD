using WSCAD.Business.converter;
using WSCAD.Models.Entities;
using WSCAD.Models.Shapes;

namespace WSCAD.Business.mapper
{
    public class Mapper : IMapper
    {
        public CircleEntity Map(Circle shape)
        {
            return new CircleEntity()
            {
                Center = shape.Center.StringToPoint(),
                Color = shape.Color.StringToColor(),
                Filled = shape.Filled,
                Radius = shape.Radius,
                Type = shape.Type,
            };
        }

        public TriangleEntity Map(Triangle shape)
        {
            return new TriangleEntity()
            {
                A = shape.A.StringToPoint(),
                B = shape.B.StringToPoint(),
                C = shape.C.StringToPoint(),
                Type = shape.Type,
                Filled = shape.Filled,
                Color = shape.Color.StringToColor(),
            };
        }

        public LineEntity Map(Line shape)
        {
            return new LineEntity()
            {
                Color = shape.Color.StringToColor(),
                Type = shape.Type,
                A = shape.A.StringToPoint(),
                B = shape.B.StringToPoint(),
            };
        }
    }
}
