//思路为从0开始，遇到I就增大，遇到D就减小。但是对于已经记录过得数字需要调过，所有需要记录当前遇到过的最大值和最小值。在他们的基础上增加或减少1.
//创建res数组记录结果，长度为S长度加一。创建min和max记录当前记录过数字的最大值和最小值。初始自设为0.
//从第二位开始遍历res。同时检测当前指针在S中的值，遇到I则在max的基础上加一记入res，同时将max更新为res[i]。遇到D时则在min的基础上减一记入res，同时更新min为res[i]。
//遍历结束后再遍历一遍res，将所有值都加上min的负值。
using System;
using System.Collections.Generic;

namespace DIStringMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "IDID";
            Console.WriteLine(DiStringMatch(S));
        }
        static int[] DiStringMatch(string S)
        {
            int max = 0;
            int min = 0;
            int[] res = new int[S.Length + 1];
            for (int i = 1; i < res.Length; i++)
            {
                if(S[i - 1] == 'I')
                {
                    res[i] = max + 1;
                    max = res[i];
                }
                else
                {
                    res[i] = min - 1;
                    min = res[i];
                }       
            }
            for (int i = 0; i < res.Length; i++)
                res[i] += -min;
            return res;
        }
    }
}
