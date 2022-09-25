using WSCAD.Business.mapper;
using WSCAD.Models.Entities;
using WSCAD.Models.Shapes;

namespace WSCAD.Business.Factory
{
    public class TriangleFactory : Factory
    {
        public override IBaseShapeEntity MakeShape(BaseShape shape)
        {
            var mapper = new Mapper();
            var trinagle = new Triangle()
            {
                A = shape.A,
                B = shape.B,
                C = shape.C,
                Type = shape.Type,
                Color = shape.Color,
                Filled = shape.Filled.Value,
            };
            var result = mapper.Map(trinagle);
            
            return result;
        }
    }
}
