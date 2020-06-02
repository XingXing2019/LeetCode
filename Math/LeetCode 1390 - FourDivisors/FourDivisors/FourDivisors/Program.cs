using System;

namespace FourDivisors
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {2401};
            Console.WriteLine(SumFourDivisors(nums));
        }
        static int SumFourDivisors(int[] nums)
        {
            int sum = 0;
            foreach (var num in nums)
                sum += GetDvisorSum(num);
            return sum;
        }

        static int GetDvisorSum(int num)
        {
            int sum = num + 1;
            int count = 2;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    if (i == num / i)
                    {
                        sum += i;
                        count += 1;
                    }
                    else
                    {
                        sum += num / i + i;
                        count += 2;
                    }
                }
                if (count > 4)
                    return 0;
            }
            if(count == 4)
                return sum;
            return 0;
        }
    }
}
