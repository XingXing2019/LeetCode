using System;
using Graphics.Strategy;

namespace Graphics.Factory
{
    public class StrokeStrategyFactory
    {
        public static IStrokeStrategy CreateStrokeStrategy(StrokeWith strokeWith)
        {
            switch (strokeWith)
            {
                case StrokeWith.Pen:
                    return new PenStrokeStrategy();
                case StrokeWith.Brush:
                    return new BrushStrokeStrategy();
                default:
                    throw new NotSupportedException("Not Supported Stroke");
            }
        }
    }
}