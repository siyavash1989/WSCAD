using System.Collections.Generic;
using WSCAD.Models.Shapes;

namespace WSCAD.helpers.converter
{
    internal interface IDataConverter
    {
        List<BaseShape> ConvertToShape(string data); 
    }
}
