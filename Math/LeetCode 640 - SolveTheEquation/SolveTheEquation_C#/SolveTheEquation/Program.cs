//应用状态机原理在beforeEqual和afterEqual之间切换逻辑。创建两个常befEqual和aftEqual代表等号前后两个状态，state代表当前状态。
//创建val，xNum和tem，分别代表数值的总和以及x的个数，tem记录系数，将他们初始值设为0。sign代表当前符号，初始值设为'+'。
//先人为判断字符串第一个元素如果是x，则xNum加一。如果是'-'，则sign标记为'-'。如果是数字，则用tem记录。
//从第二个元素开始遍历字符串。如果当前元素为'x'，其前一元素为'0'，则根据当前sign的符号决定xNum加或者减tem和1之间较大的值。如果其前一元素不为'0'，则根据sign的符号决定xNum加或者减tem。
//如果当前元素为'+'或'-'，则根据情况决定val加或者减tem， 同时标记sign为相应符号。如果当前元素为'='，则变换状态为aftEqual，并将sign设为'+'。
//如果当前元素为数字，当tem为'0'时，将数字计入tem。当tem不为'0'时，tem = tem * 10 + 当前数字。这样用于表达位数大于1的数字。
//在aftEqual状态下，使用与上述相反的逻辑。
using System;

namespace SolveTheEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            string equation = "0x=0";
            Console.WriteLine(SolveEquation(equation));
        }
        static string SolveEquation(string equation)
        {
            const string befEqual = "beforeEqual";
            const string aftEqual = "afterEqual";
            string state = befEqual;
            int val = 0;
            int xNum = 0;
            char sign = '+';
            int tem = 0;
            if (equation[0] == 'x')
                xNum++;
            else if (equation[0] == '-')
                sign = '-';
            else if (equation[0] != 'x' && equation[0] != '=' && equation[0] != '-' && equation[0] != '=')
                tem = equation[0] - '0';
            for (int i = 1; i < equation.Length; i++)
            {
                switch (state)
                {
                    case befEqual:
                        if (equation[i] == 'x')
                        {
                            if (sign == '+')
                                if (equation[i - 1] != '0')
                                    xNum += Math.Max(tem, 1);
                                else
                                    xNum += tem;
                            else if (sign == '-')
                                if (equation[i - 1] != '0')
                                    xNum -= Math.Max(tem, 1);
                                else
                                    xNum -= tem;
                            tem = 0;
                        }
                        else if (equation[i] == '-' || equation[i] == '+' || equation[i] == '=')
                        {
                            if (sign == '+')
                                val -= tem;
                            else if (sign == '-')
                                val += tem;
                            tem = 0;
                            if (equation[i] == '+' || equation[i] == '-')
                                sign = equation[i];
                            else if (equation[i] == '=')
                            {
                                state = aftEqual;
                                sign = '+';
                            }
                        }
                        else if (equation[i] != 'x' && equation[i] != '=' && equation[i] != '-' && equation[i] != '=')
                        {
                            if (tem == 0)
                                tem = equation[i] - '0';
                            else
                                tem = tem * 10 + equation[i] - '0';
                        }
                        break;
                    case aftEqual:
                        if (equation[i] == 'x')
                        {
                            if (sign == '+')
                                if (equation[i - 1] != '0')
                                    xNum -= Math.Max(tem, 1);
                                else
                                    xNum -= tem;
                            else if (sign == '-')
                                if (equation[i - 1] != '0')
                                    xNum += Math.Max(tem, 1);
                                else
                                    xNum += tem;
                            tem = 0;
                        }
                        else if (equation[i] == '-' || equation[i] == '+')
                        {
                            if (sign == '+')
                                val += tem;
                            else if (sign == '-')
                                val -= tem;
                            tem = 0;
                            sign = equation[i];
                        }
                        else if (equation[i] != 'x' && equation[i] != '=' && equation[i] != '-' && equation[i] != '=')
                        {
                            if (tem == 0)
                                tem = equation[i] - '0';
                            else
                                tem = tem * 10 + equation[i] - '0';
                        }
                        break;
                }
            }
            if (sign == '-')
                val -= tem;
            else if (sign == '+')
                val += tem;
            if (xNum == 0 && val != 0)
                return "No solution";
            else if (xNum == 0 && val == 0)
                return "Infinite solutions";
            else
                return "x=" + (val / xNum);
        }
    }
}
