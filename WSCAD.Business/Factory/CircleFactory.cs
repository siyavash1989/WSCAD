using WSCAD.Business.mapper;
using WSCAD.Models.Entities;
using WSCAD.Models.Shapes;

namespace WSCAD.Business.Factory
{
    public class CircleFactory : Factory
    {
        public override IBaseShapeEntity MakeShape(BaseShape shape)
        {
            var mapper = new Mapper();
            var circle = new Circle()
            {
                Center = shape.Center,
                Radius = shape.Radius.Value,
                Type = shape.Type,
                Color = shape.Color,
                Filled = shape.Filled.Value,
            };
            var result = mapper.Map(circle);

            return result;
        }
    }
}
