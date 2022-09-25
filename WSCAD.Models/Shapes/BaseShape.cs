﻿namespace WSCAD.Models.Shapes
{
    public class BaseShape
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public string? Center { get; set; }
        public float? Radius { get; set; }
        public bool? Filled { get; set; }
        public string? A { get; set; }
        public string? B { get; set; }
        public string? C { get; set; }

    }
}
