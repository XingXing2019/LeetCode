using System;

namespace HouseRobberIV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 3, 5, 9 };
            var k = 2;
            Console.WriteLine(MinCapability(nums, k));
        }

        public static int MinCapability(int[] nums, int k)
        {
            int li = int.MaxValue, hi = int.MinValue;
            foreach (var num in nums)
            {
                li = Math.Min(li, num);
                hi = Math.Max(hi, num);
            }
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (!IsPossible(nums, mid, k))
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return li;
        }

        private bool IsPossible(int[] nums, int mid, int k)
        {
            var count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > mid) continue;
                count++;
                if (count >= k) return true;
                i++;
            }
            return count >= k;
        }
    }
}
