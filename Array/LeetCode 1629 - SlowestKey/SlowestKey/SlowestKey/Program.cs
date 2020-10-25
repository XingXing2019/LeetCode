using System;

namespace SlowestKey
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] releaseTimes = {9, 29, 49, 50};
            var keyPressed = "cbcd";
            Console.WriteLine(SlowestKey(releaseTimes, keyPressed));
        }
        static char SlowestKey(int[] releaseTimes, string keysPressed)
        {
            var res = keysPressed[0];
            var max = releaseTimes[0];
            for (int i = 1; i < releaseTimes.Length; i++)
            {
                if (releaseTimes[i] - releaseTimes[i - 1] > max)
                {
                    max = releaseTimes[i] - releaseTimes[i - 1];
                    res = keysPressed[i];
                }
                else if(releaseTimes[i] - releaseTimes[i - 1] == max && keysPressed[i] > res)
                    res = keysPressed[i];
            }
            return res;
        }
    }
}
