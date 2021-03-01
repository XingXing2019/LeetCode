//利用数组记录keyboard中每个字母的位置。
//遍历word计算times
using System;

namespace SingleRowKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int CalculateTime(string keyboard, string word)
        {
            int times = 0, pos = 0;
            var index = new int[26];
            for (int i = 0; i < keyboard.Length; i++)
                index[keyboard[i] - 'a'] = i;
            foreach (var letter in word)
            {
                times += Math.Abs(index[letter - 'a'] - pos);
                pos = index[letter - 'a'];
            }
            return times;
        }
    }
}
