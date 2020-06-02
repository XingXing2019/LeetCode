using System;
using System.Linq;

namespace MaximumPointsYouCanObtainFromCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxScore(int[] cardPoints, int k)
        {
            int li = 0, hi = cardPoints.Length - k - 1;
            int totalPoints = cardPoints.Sum(c => c);
            int windowPoints = 0;
            for (int i = 0; i <= hi; i++)
                windowPoints += cardPoints[i];
            int maxPoint = totalPoints - windowPoints;
            int res = maxPoint;
            while (hi < cardPoints.Length - 1)
            {
                maxPoint += cardPoints[li++];
                maxPoint -= cardPoints[++hi];
                res = Math.Max(res, maxPoint);
            }
            return res;
        }
    }
}
