using System;
using WSCAD.Models.CommonModels;
using WSCAD.Models.Entities;

namespace WSCAD.helpers
{
    public static class SetViewBoxSize
    {
        public static ViewSize SetSize(IBaseShapeEntity entity, ViewSize input)
        {            
            input.MinX = Math.Min(input.MinX, entity.MinX);
            input.MinY = Math.Min(input.MinY, entity.MinY);
            input.MaxX = Math.Max(input.MaxX, entity.MaxX);
            input.MaxY = Math.Max(input.MaxY, entity.MaxY);
            return input;
        }
    }
}
