using System.Drawing;
using System.Globalization;
using Point = WSCAD.Models.CommonModels.Point;

namespace WSCAD.Business.converter
{
    public static class ExtensionMethods
    {
        public static Point StringToPoint(this string input)
        {
            string[] parts = input.Split(';');

            return new Point()
            {
                X = float.Parse(parts[0], new CultureInfo("de-DE", false)),
                Y = -float.Parse(parts[1], new CultureInfo("de-DE", false)),
            };


        }

        public static Color StringToColor(this string input)
        {
            string[] parts = input.Split(';');            
            return Color.FromArgb(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
        }
    }
}
