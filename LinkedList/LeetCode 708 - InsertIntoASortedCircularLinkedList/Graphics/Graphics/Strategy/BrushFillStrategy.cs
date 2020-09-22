using System;

namespace Graphics.Strategy
{
    public class BrushFillStrategy : IFillStrategy
    {
        public void Fill()
        {
            Console.WriteLine("Brush Fill");
        }
    }
}