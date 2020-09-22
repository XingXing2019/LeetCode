using System;

namespace Graphics.Strategy
{
    public class BrushStrokeStrategy : IStrokeStrategy
    {
        public void Stroke()
        {
            Console.WriteLine("Brush Stroke");
        }
    }
}