using System.Drawing;

namespace WSCAD.Models.Entities
{
    public static class ExtensionMethod
    {
        public static string ColorToColorString(this Color input)
        {
            return "rgba(" + input.R + "," + input.G + "," + input.B + "," + input.A + ")";
        }
    }
}
