//思路为利用状态机分别获取两个数的实数和虚数部分，再进行计算，将结果拼接到一起。
using System;

namespace ComplexNumberMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "1+1i";
            string b = "1+1i";
            Console.WriteLine(ComplexNumberMultiply(a, b));
        }
        static string ComplexNumberMultiply(string a, string b)
        {
            string realNumA = "";
            string imaginaryNumA = "";
            string realNumB = "";
            string imaginaryNumB = "";
            const string befPlus = "befPlus";
            const string aftPlus = "aftPlus";
            string state = befPlus;
            for (int i = 0; i < a.Length; i++)
            {
                switch (state)
                {
                    case befPlus:
                        if (a[i] != '+')
                            realNumA += a[i];
                        else
                            state = aftPlus;
                        break;
                    case aftPlus:
                        if (a[i] != 'i')
                            imaginaryNumA += a[i];
                        break;
                }
            }
            state = befPlus;
            for (int i = 0; i < b.Length; i++)
            {
                switch (state)
                {
                    case befPlus:
                        if (b[i] != '+')
                            realNumB += b[i];
                        else
                            state = aftPlus;
                        break;
                    case aftPlus:
                        if (b[i] != 'i')
                            imaginaryNumB += b[i];
                        break;
                }
            }
            int realA = int.Parse(realNumA);
            int realB = int.Parse(realNumB);
            int imgA = int.Parse(imaginaryNumA);
            int imgB = int.Parse(imaginaryNumB);
            return (realA * realB - imgA * imgB) + "+" + (realA * imgB + realB * imgA) + "i";
        }
    }
}
