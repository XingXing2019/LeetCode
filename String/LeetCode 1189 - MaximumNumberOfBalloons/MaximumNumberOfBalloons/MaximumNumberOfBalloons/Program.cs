//创建数组balloons，遍历字符串将每个字母的个数记录入balloons。
//遍历字典中的每个键值对。如果key为'l'或'o'，则用num记录该字母的个数，并对其整除2(因为每个balloon单词需要两个'l'和'o')。
//遍历过程中记录最小的num，并在遍历结束后返回。
using System;
using System.Collections.Generic;

namespace MaximumNumberOfBalloons
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "nlaebolko";
            Console.WriteLine(MaxNumberOfBalloons(text));
        }
        static int MaxNumberOfBalloons(string text)
        {
            var balloons = new int[26];
            foreach (var letter in text)
                balloons[letter - 'a']++;
            int count = int.MaxValue;
            for (int i = 0; i < balloons.Length; i++)
            {
                if (i == 'l' - 'a' || i == 'o' - 'a')
                    count = Math.Min(count, balloons[i] / 2);
                else if (i == 'a' - 'a' || i == 'b' - 'a' || i == 'n' - 'a')
                    count = Math.Min(count, balloons[i]);
            }
            return count;
        }
    }
}
