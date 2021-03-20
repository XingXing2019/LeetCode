//创建动态数组res记录结果，长度为num + 1。将res[1]设为1。
//遍历数组，如果i为偶数，该位置数字1的数量应该和当前i一半的位置的数字1的数量一样。
//如果i为奇数，该位置数字1的数量应该为前一个位置数字1的数量加一。
//最后返回res。
using System;

namespace CountingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] CountBits(int num)
        {
            var res = new int[num + 1];
            if (num == 0) return res;
            res[1] = 1;
            for (int i = 2; i < res.Length; i++)
                res[i] = i % 2 == 0 ? res[i / 2] : res[i - 1] + 1;
            return res;
        }
    }
}
