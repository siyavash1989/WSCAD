using Newtonsoft.Json;
using System.Collections.Generic;
using WSCAD.Models.Shapes;

namespace WSCAD.helpers.converter
{
    internal class JsonConverter : IDataConverter
    {
        public List<BaseShape> ConvertToShape(string data)
        {
            if(data == null)
                return new List<BaseShape>();
            return JsonConvert.DeserializeObject<List<BaseShape>>(data);
        }
    }
}
