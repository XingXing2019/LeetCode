//创建一个数组rem记录在每一个station加油后再行驶到下一个station油箱净剩油量。
//创建一个totalRem记录行驶全程后油箱的总剩余量
//遍历数组，计算在每一个station油箱净剩油量rem[i] = gas[i] - cost[i]，和totalRem。
//如果totalRem小于0，证明不能行驶一圈，
//否则设置start代表开始的station代号，初始值设为0。tank代表当前油箱油量，初始值设为0。
//遍历rem数组，将每个station的净剩油量加到tank中。如果tank小于0，证明在该station不能继续向前行驶。
//此时将tank归零，并将start设为i+1，代表下一站点。
using System;

namespace GasStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            var gasRemain = new int[gas.Length];
            int totalRemain = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                gasRemain[i] = gas[i] - cost[i];
                totalRemain += gasRemain[i];
            }
            if (totalRemain < 0)
                return -1;
            int tank = 0, start = 0;
            for (int i = 0; i < gasRemain.Length; i++)
            {
                tank += gasRemain[i];
                if (tank < 0)
                {
                    start = i + 1;
                    tank = 0;
                }
            }
            return start;
        }
    }
}
