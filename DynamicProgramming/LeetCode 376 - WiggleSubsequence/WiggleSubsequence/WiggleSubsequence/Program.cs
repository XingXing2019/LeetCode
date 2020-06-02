//如果数组长度小于2，直接返回数组长度。
//利用状态机编程思想，设立begin，up，down三个状态。将初始状态设为begin。begin状态可以切换成up或down两种状态，up和down只能相互切换。
//从第二个元素开始遍历数组利用switch语句在三种状态间切换。让每个元素与之前一元素比较决定是否切换状态，每当状态切换时maxLen加一。
using System;

namespace WiggleSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 7, 4, 9, 2, 5 };
            Console.WriteLine(WiggleMaxLength(nums));
        }
        static int WiggleMaxLength(int[] nums)
        {
            if (nums.Length < 2)
                return nums.Length;
            const string begin = "begin";
            const string up = "up";
            const string down = "down";
            string state = begin;
            int maxLen = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                switch (state)                              //Line 26 - 54 是使用状态机检查状态是否发生变化。
                {
                    case begin:
                        if (nums[i] > nums[i - 1])
                        {
                            state = up;
                            maxLen++;
                        }
                        else if(nums[i] < nums[i - 1])
                        {
                            state = down;
                            maxLen++;
                        }
                        break;
                    case up:
                        if (nums[i] < nums[i - 1])
                        {
                            state = down;
                            maxLen++;
                        }
                        break;
                    case down:
                        if (nums[i] > nums[i - 1])
                        {
                            state = up;
                            maxLen++;
                        }
                        break;
                }
            }
            return maxLen;
        }
    }
}
