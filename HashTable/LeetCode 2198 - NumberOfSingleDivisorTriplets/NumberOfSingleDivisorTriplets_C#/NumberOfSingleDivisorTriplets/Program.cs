using System;
using System.Linq;

namespace NumberOfSingleDivisorTriplets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 2, 1 };
            Console.WriteLine(SingleDivisorTriplet(nums));
        }

        public static long SingleDivisorTriplet(int[] nums)
        {
            var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var numbers = freq.Select(x => x.Key).ToArray();
            long res = 0, sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (freq[numbers[i]] > 1)
                    {
                        sum = 2 * numbers[i] + numbers[j];
                        if (sum % numbers[i] != 0 && sum % numbers[j] == 0)
                            res += (long)freq[numbers[i]] * (freq[numbers[i]] - 1) * freq[numbers[j]] * 3;
                    }
                    if (freq[numbers[j]] > 1)
                    {
                        sum = numbers[i] + 2 * numbers[j];
                        if (sum % numbers[i] == 0 && sum % numbers[j] != 0)
                            res += (long)freq[numbers[i]] * freq[numbers[j]] * (freq[numbers[j]] - 1) * 3;
                    }
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        sum = numbers[i] + numbers[j] + numbers[k];
                        if (sum % numbers[i] == 0 && sum % numbers[j] != 0 && sum % numbers[k] != 0 ||
                            sum % numbers[i] != 0 && sum % numbers[j] == 0 && sum % numbers[k] != 0 ||
                            sum % numbers[i] != 0 && sum % numbers[j] != 0 && sum % numbers[k] == 0)
                            res += (long)freq[numbers[i]] * freq[numbers[j]] * freq[numbers[k]] * 6;
                    }
                }
            }
            return res;
        }
    }
}
