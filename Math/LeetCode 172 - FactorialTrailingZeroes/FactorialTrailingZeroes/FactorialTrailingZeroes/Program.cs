//本质是找到结成中有多少个10会出现。10可以由2乘以5获得，因为数字中2出现的概率远远超过5(所有偶数能可以看成存在2)。
//所以就转化为找到小于等于n的数字中有多少个5存在。需要注意5的幂的数字存在多于一个5.所以除了找到有多少个5，还要找到有多少个5的幂(25, 125...).
//创建一个数字tem初始值设为5。在n小于等于这个数字的条件下，让结果加上n除以tem，并且让tem乘等于5。这样算法的时间复杂度就是对数级别的。
//但需要注意要将tem设置成long型，否则会存在tem溢出导致错误结果。
using System;

namespace FactorialTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1808548329;
            Console.WriteLine(TrailingZeroes(n));
        }
        static int TrailingZeroes(int n)
        {
            int res = 0, num = 5;
            while (n >= num)
            {
                res += n / num;
                num *= 5;
            }
            return res;
        }
    }
}
