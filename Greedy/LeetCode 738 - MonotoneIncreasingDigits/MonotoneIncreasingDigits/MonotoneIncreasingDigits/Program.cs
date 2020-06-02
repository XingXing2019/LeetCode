//创建一个列表nums，将N每一位上的数字加入列表中。创建mark指针，初始值设为-1，用于辅助标记翻转点。
//从右向左遍历列表寻找最左端的翻转点。如果发现当前元素比他左边的元素小，则将mark设为当前i，并将mark左边的元素减一。遍历结束后，mark所标记的点即为最左端的翻转点。
//如果此时mark不为-1，证明存在翻转点，则将mark以及mark右边的所有元素设为9.
//创建res代表结果，遍历现在的nums，将所有数字存入res。
using System;
using System.Collections.Generic;

namespace MonotoneIncreasingDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            Console.WriteLine(MonotoneIncreasingDigits(N));
        }
        static int MonotoneIncreasingDigits(int N)
        {
            List<int> nums = new List<int>();
            while (N != 0)
            {
                int num = N % 10;
                nums.Add(num);
                N /= 10;
            }
            nums.Reverse();
            int mark = -1;
            for (int i = nums.Count - 1; i > 0; i--)
            {
                if (nums[i] < nums[i - 1])
                {
                    mark = i;
                    nums[mark - 1]--;
                }  
            }
            int res = 0;
            if (mark != -1)
            {
                for (int i = mark; i < nums.Count; i++)
                    nums[i] = 9;
            }
            for (int i = 0; i < nums.Count; i++)
                res = res * 10 + nums[i];
            return res;
        }
    }
}
