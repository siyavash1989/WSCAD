using GrapeCity.Documents.Svg;
using WSCAD.Models.Entities;
using WSCAD.Models.Shapes;

namespace WSCAD.Business.Factory
{
    public abstract class Factory
    {
        public abstract IBaseShapeEntity MakeShape(BaseShape shape);

        public void Draw(BaseShape entity, GcSvgDocument doc)
        {
            var shape = MakeShape(entity);
             shape.Draw(doc);
        }
    }
}
