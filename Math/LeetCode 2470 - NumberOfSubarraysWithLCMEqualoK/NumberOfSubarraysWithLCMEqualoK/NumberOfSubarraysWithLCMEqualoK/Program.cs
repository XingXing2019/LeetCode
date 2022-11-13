using System;

namespace NumberOfSubarraysWithLCMEqualoK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int SubarrayLCM(int[] nums, int k)
        {
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var lcm = 1;
                for (int j = i; j < nums.Length; j++)
                {
                    lcm = LCM(lcm, nums[j]);
                    if (lcm == k)
                        res++;
                    else if (lcm > k)
                        break;
                }
            }
            return res;
        }

        public int GCD(int num1, int num2)
        {
            return num2 == 0 ? num1 : GCD(num2, num1 % num2);
        }

        public int LCM(int num1, int num2)
        {
            var gcd = GCD(num1, num2);
            return num1 * num2 / gcd;
        }
    }
}
