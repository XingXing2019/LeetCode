//思路为先假设所有人都前往A市，然后计算由A市给为B市能省下的开销，将能省下开销最多的一半人改为B市。
//创建一个数组costGap记录前往B市与前往A市cost的差值。创立minCost代表最少花销。
//遍历costs数组，将B市话费减去A市话费的值存入costGap数组。同时假设所有人都前往A市，将所有前往A市话费累加入minCost。
//为costGap数组排序，越靠前的元素代表将该人由A市改成B市能省下越多的花销。
//遍历costGap数组的一半，将他们由A市改成B市。
using System;
using System.Collections.Generic;

namespace TwoCityScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
       
        static int TwoCitySchedCost(int[][] costs)
        {
            int[] costGap = new int[costs.Length];
            int minCost = 0;
            for (int i = 0; i < costs.Length; i++)
            {
                costGap[i] = costs[i][1] - costs[i][0];
                minCost += costs[i][0];
            }
            Array.Sort(costGap);
            for (int i = 0; i < costGap.Length / 2; i++)
                minCost += costGap[i];
            return minCost;
        }
    }
}
