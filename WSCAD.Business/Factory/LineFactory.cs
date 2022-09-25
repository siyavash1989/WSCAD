using WSCAD.Business.mapper;
using WSCAD.Models.Entities;
using WSCAD.Models.Shapes;

namespace WSCAD.Business.Factory
{
    public class LineFactory : Factory
    {
        public override IBaseShapeEntity MakeShape(BaseShape shape)
        {
            var mapper = new Mapper();
            var line = new Line()
            {
                A = shape.A,
                B = shape.B,
                Type = shape.Type,
                Color = shape.Color,
            };
            var result = mapper.Map(line);

            return result;
        }
    }
}
