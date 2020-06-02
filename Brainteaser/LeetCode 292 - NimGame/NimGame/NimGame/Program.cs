//可以拿到倒数第五块石头的肯定赢。所以只要n比4大就让n一直减4，但这种做法会超时，可以用n % 4代替。
//在n % 4不为0的时候返回true，否则返回false。
using System;

namespace NimGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool CanWinNim(int n)
        {
            return n % 4 != 0;
        }
    }
}
