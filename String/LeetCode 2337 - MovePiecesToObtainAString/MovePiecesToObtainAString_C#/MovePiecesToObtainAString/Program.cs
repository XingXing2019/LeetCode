using System;
using System.Collections.Generic;

namespace MovePiecesToObtainAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool CanChange(string start, string target),
        {
            var trimStart = start.Replace("_", "");
            var trimTarget = target.Replace("_", "");
            if (trimStart != trimTarget)
                return false;
            var startLeft = new List<int>();
            var startRight = new List<int>();
            var targetLeft = new List<int>();
            var targetRight = new List<int>();
            for (int i = 0; i < start.Length; i++)
            {
                if (start[i] == 'L') 
                    startLeft.Add(i);
                else if (start[i] == 'R')
                    startRight.Add(i);
                if (target[i] == 'L')
                    targetLeft.Add(i);
                else if (target[i] == 'R')
                    targetRight.Add(i);
            }
            for (int i = 0; i < startLeft.Count; i++)
            {
                if (startLeft[i] < targetLeft[i])
                    return false;
            }
            for (int i = 0; i < startRight.Count; i++)
            {
                if (startRight[i] > targetRight[i])
                    return false;
            }
            return true;
        }
    }
}
