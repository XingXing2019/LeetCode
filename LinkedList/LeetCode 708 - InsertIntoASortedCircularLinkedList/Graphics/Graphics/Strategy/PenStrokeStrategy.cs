using System;

namespace Graphics.Strategy
{
    public class PenStrokeStrategy : IStrokeStrategy
    {
        public void Stroke()
        {
            Console.WriteLine("Pen Stroke");
        }
    }
}