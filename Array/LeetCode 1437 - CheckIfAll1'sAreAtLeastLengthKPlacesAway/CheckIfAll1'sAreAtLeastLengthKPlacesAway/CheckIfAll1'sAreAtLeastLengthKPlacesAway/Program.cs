using System;
using System.ComponentModel;

namespace CheckIfAll1_sAreAtLeastLengthKPlacesAway
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool KLengthApart(int[] nums, int k)
        {
            int index = 0;
            int space = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    index = i + 1;
                    break;
                }
            }
            while (index < nums.Length)
            {
                if (nums[index] == 0)
                    space++;
                else
                {
                    if (space < k)
                        return false;
                    space = 0;
                }
                index++;
            }
            return true;
        }
    }
}
