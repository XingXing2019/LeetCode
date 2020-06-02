//获取数组的总和sum，如果sum不能被3整除，则直接返回false。
//否则创建subSume等于sum/3，count记录满足要求的数组的个数。遍历A统计count的个数，返回count==3.
using System;

namespace PartitionArrayIntoThreeParts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool CanThreePartsEqualSum(int[] A)
        {
            int sum = 0;
            foreach (var num in A)
                sum += num;
            if (sum % 3 != 0)
                return false;
            int subSum = sum / 3;
            int index = 0;
            int count = 0;
            while (index < A.Length)
            {
                subSum -= A[index];
                if(subSum == 0)
                {
                    count++;
                    subSum = sum / 3;
                }
                index++;
            }
            return count == 3;
        }
    }
}
