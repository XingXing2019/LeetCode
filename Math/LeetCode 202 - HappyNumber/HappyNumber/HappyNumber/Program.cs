//创建GetSquare方法，得到一个数字每位平方之和。
//在主方法中创建noRepeat字典，用于存储出现过得数字。
//循环调用GetSquare方法，创建tem接收计算出的结果，如果tem等于1，则返回true。否则将tem记录入noRepeat字典。如果noRepeat中的数字再次出现，则返回false。
using System;
using System.Collections.Generic;

namespace HappyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 19;
            Console.WriteLine(IsHappy(n));
        }
        static bool IsHappy(int n)
        {
            var noRepeat = new Dictionary<int, int>();
            while (true)
            {
                int tem = GetSquare(n);
                if (tem == 1)
                    return true;
                else
                {
                    if (!noRepeat.ContainsKey(tem))
                        noRepeat[tem] = 1;
                    else
                        return false;
                }
                n = tem;
            }
        }
        static int GetSquare(int n)
        {
            int res = 0;
            while (n != 0)
            {
                int tem = n % 10;
                res += tem * tem;
                n /= 10;
            }
            return res;
        }
        public bool IsHappy_HashSet(int n)
        {
            var set = new HashSet<int>();
            while (set.Add(n))
            {
                var num = 0;
                while (n != 0)
                {
                    int temp = n % 10;
                    num += temp * temp;
                    n /= 10;
                }
                if (num == 1) return true;
                n = num;
            }
            return false;
        }
    }
}
