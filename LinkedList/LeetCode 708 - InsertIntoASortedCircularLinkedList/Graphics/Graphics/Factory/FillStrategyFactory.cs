using System;
using Graphics.Strategy;

namespace Graphics.Factory
{
    public class FillStrategyFactory
    {
        public static IFillStrategy CreateFillStrategy(FillWith fillWith)
        {
            switch (fillWith)
            {
                case FillWith.Brush:
                    return new BrushFillStrategy();
                case FillWith.Bucket:
                    return new BucketFillStrategy();
                default:
                    throw new NotSupportedException("Not Supported Stroke");
            }
        }
    }
}