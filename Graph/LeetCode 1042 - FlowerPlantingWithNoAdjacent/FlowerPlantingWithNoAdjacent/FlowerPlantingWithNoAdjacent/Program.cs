//创建Garden类，属性包括GardenNo，Flowers代表现有能种的花，Adjacent代表互通的Garden。
//创建graph为一个长度为N的Garden数组。根据graph将与当前Garden相连的Garden加入Adjacent。
//遍历res，将res[i]设为当前garden第一个能种的花，并将这种花从当前garden相邻garden的flower列表中删去。
using System;
using System.Collections.Generic;

namespace FlowerPlantingWithNoAdjacent
{
    class Garden
    {
        public int GardenNo;
        public List<Garden> Adjacent;
        public List<int> Flowers;
        public Garden(int x)
        {
            GardenNo = x;
            Adjacent = new List<Garden>();
            Flowers = new List<int> { 1, 2, 3, 4 };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int N = 3;
            int[][] paths = new int[3][]
            {
                new int[]{1, 2},
                new int[]{2, 3},
                new int[]{3, 1}
            };

            Console.WriteLine(GardenNoAdj(N, paths));
        }
        static int[] GardenNoAdj(int N, int[][] paths)
        {
            var graph = new Garden[N];
            var res = new int[N];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new Garden(i);
            foreach (var path in paths)
            {
                var garden1 = graph[path[0] - 1];
                var garden2 = graph[path[1] - 1];
                garden1.Adjacent.Add(garden2);
                garden2.Adjacent.Add(garden1);
            }
            for (int i = 0; i < res.Length; i++)
            {
                var flower = graph[i].Flowers[0];
                res[i] = flower;
                foreach (var garden in graph[i].Adjacent)
                    garden.Flowers.Remove(flower);
            }
            return res;
        }
    }
}
