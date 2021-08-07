using System;
using System.Collections.Generic;

namespace CircularArrayLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -1};
            Console.WriteLine(CircularArrayLoop(nums));

            Console.WriteLine(-7 % 5);
        }
        static bool CircularArrayLoop(int[] nums)
        {
            if (nums.Length == 1) return false;
            for (int i = 0; i < nums.Length; i++)
            {
                var index = new List<int>();
                var set = new HashSet<int>();
                var cur = i;
                var sameDirection = true;
                var found = false;
                while (true)
                {
                    if (set.Contains(cur))
                    {
                        if (cur != index[^1])
                            found = true;
                        break;
                    }
                    index.Add(cur);
                    set.Add(cur);
                    var next = cur + nums[cur];
                    if (next >= nums.Length)
                        next %= nums.Length;
                    else if (next < 0)
                        next = nums.Length - (-next % nums.Length);
                    if (nums[next] * nums[i] <= 0)
                    {
                        sameDirection = false;
                        break;
                    }
                    cur = next;
                }
                if (sameDirection && found) return true;
            }
            return false;
        }
    }
}
