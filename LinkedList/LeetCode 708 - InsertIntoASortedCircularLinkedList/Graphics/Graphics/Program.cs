using System;
using Graphics.Factory;

namespace Graphics
{
    class Program
    {
        static void Main(string[] args)
        {
            var strokeStrategy = StrokeStrategyFactory.CreateStrokeStrategy(StrokeWith.Pen);
            var fillStrategy = FillStrategyFactory.CreateFillStrategy(FillWith.Brush);
            var graphics = new Graphics(strokeStrategy, fillStrategy);

            graphics.Stroke();
            graphics.Fill();

            graphics.SetStrokeStrategy(StrokeStrategyFactory.CreateStrokeStrategy(StrokeWith.Brush));
            graphics.SetFillStrategy(FillStrategyFactory.CreateFillStrategy(FillWith.Bucket));

            graphics.Stroke();
            graphics.Fill();
        }
    }
}
