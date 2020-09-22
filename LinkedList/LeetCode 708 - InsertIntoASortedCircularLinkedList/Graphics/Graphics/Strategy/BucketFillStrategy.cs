using System;

namespace Graphics.Strategy
{
    public class BucketFillStrategy : IFillStrategy
    {
        public void Fill()
        {
            Console.WriteLine("Bucket Fill");
        }
    }
}