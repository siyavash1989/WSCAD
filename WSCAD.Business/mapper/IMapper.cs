using WSCAD.Models.Entities;
using WSCAD.Models.Shapes;

namespace WSCAD.Business.mapper
{
    public interface IMapper
    {
        CircleEntity Map(Circle shape);
        TriangleEntity Map(Triangle shape);
        LineEntity Map(Line shape);
    }
}
