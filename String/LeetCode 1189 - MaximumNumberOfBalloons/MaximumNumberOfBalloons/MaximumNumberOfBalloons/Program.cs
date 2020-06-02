//创建字典balloons，遍历字符串将每个字母的个数记录入balloons。
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
            string text = "";
            Console.WriteLine(MaxNumberOfBalloons(text));
        }
        static int MaxNumberOfBalloons(string text)
        {
            Dictionary<char, int> balloons = new Dictionary<char, int>();
            balloons.Add('b', 0);
            balloons.Add('a', 0);
            balloons.Add('l', 0);
            balloons.Add('o', 0);
            balloons.Add('n', 0);
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'b')
                    balloons['b']++;
                else if (text[i] == 'a')
                    balloons['a']++;
                else if (text[i] == 'l')
                    balloons['l']++;
                else if (text[i] == 'o')
                    balloons['o']++;
                else if (text[i] == 'n')
                    balloons['n']++;
            }
            int count = int.MaxValue;
            int num = 0;
            foreach (var keyValuePair in balloons)
            {
                if (keyValuePair.Key == 'l' || keyValuePair.Key == 'o')
                {
                    num = keyValuePair.Value;
                    num /= 2;
                }
                else
                    num = keyValuePair.Value;
                if (num < count)
                    count = num;
            }
            return count;
        }

    }
}
