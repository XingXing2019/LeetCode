using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdditiveNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num = "1124";
            Console.WriteLine(IsAdditiveNumber(num));
        }

        public static bool IsAdditiveNumber(string num)
        {
            for (int i = 1; i < num.Length; i++)
            {
                var num1 = num.Substring(0, i);
                for (int j = 1; j <= num.Length - i; j++)
                {
                    var num2 = num.Substring(i, j);
                    if (DFS(num.Substring(i + j), num1, num2))
                        return true;
                }
            }
            return false;
        }

        public static bool DFS(string num, string num1, string num2)
        {
            if (num1.Length > 1 && num1[0] == '0' || num2.Length > 1 && num2[0] == '0')
                return false;
            var sum = Add(num1, num2);
            if (sum == num)
                return true;
            if (num.Length < sum.Length || num.Substring(0, sum.Length) != sum)
                return false;
            return DFS(num.Substring(sum.Length), num2, sum);
        }

        public static string Add(string num1, string num2)
        {
            if (num1.Length == 0) return num2;
            int cur = 0, car = 0, p1 = num1.Length - 1, p2 = num2.Length - 1;
            var num = new StringBuilder();
            while (p1 >= 0 && p2 >= 0)
            {
                cur = (num1[p1] - '0' + num2[p2] - '0' + car) % 10;
                car = (num1[p1--] - '0' + num2[p2--] - '0' + car) / 10;
                num.Append(cur);
            }
            while (p1 >= 0)
            {
                cur = (num1[p1] - '0' + car) % 10;
                car = (num1[p1--] - '0' + car) / 10;
                num.Append(cur);
            }
            while (p2 >= 0)
            {
                cur = (num2[p2] - '0' + car) % 10;
                car = (num2[p2--] - '0' + car) / 10;
                num.Append(cur);
            }
            if (car == 1) num.Append(car);
            var res = new StringBuilder();
            for (int i = num.Length - 1; i >= 0; i--)
                res.Append(num[i]);
            return res.ToString();
        }
    }
}
