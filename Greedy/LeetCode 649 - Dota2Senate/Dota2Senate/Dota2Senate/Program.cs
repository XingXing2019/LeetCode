//思路为贪心算法，每个成员要禁言其后面第一个对方的成员。
//创建rPos和dPos列表用于存储R和D的位置，遍历字符串将R和D相应的位置存入相应的列表。
//创建爱你indexR和indexD指针，指向两个列表第一个元素。这两个指针都不用动，之后会移动列表中元素的位置，来实现遍历。
//在两个列表都不为空的条件下遍历。如果indexR指向数字小于indexD指向数字，则将indexD指向的数字从dPos中去除，并将indexR指向数字加上一个sentate长度，并放到列表尾。
//如果indexR指向数字da于indexD指向数字，则做之前相反操作。
//最后看那个列表中还有元素。
using System;
using System.Collections.Generic;

namespace Dota2Senate
{
    class Program
    {
        static void Main(string[] args)
        {
            string senate = "DRRDRDRDRDDRDRDR";
            Console.WriteLine(PredictPartyVictory(senate));
        }
        static string PredictPartyVictory(string senate)
        {
            List<int> rPos = new List<int>();
            List<int> dPos = new List<int>();
            for (int i = 0; i < senate.Length; i++)
            {
                if (senate[i] == 'R')
                    rPos.Add(i);
                else
                    dPos.Add(i);
            }
            int indexR = 0;
            int indexD = 0;
            while (rPos.Count != 0 && dPos.Count != 0)
            {
                if (rPos[indexR] > dPos[indexD])
                {
                    rPos.Remove(rPos[indexR]);
                    dPos.Add(dPos[indexD] + senate.Length);
                    dPos.Remove(dPos[indexD]);
                }
                else if(rPos[indexR] < dPos[indexD])
                {
                    dPos.Remove(dPos[indexD]);
                    rPos.Add(rPos[indexR] + senate.Length);
                    rPos.Remove(rPos[indexR]);
                }
            }
            return dPos.Count == 0 ? "Radiant" : "Dire";
        }
    }
}
