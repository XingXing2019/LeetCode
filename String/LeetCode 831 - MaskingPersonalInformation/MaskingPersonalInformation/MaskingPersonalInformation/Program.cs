//创建MaskEmail方法，按照要求处理邮箱，可以使用Split函数简化过程。
//创建MaskPhone方法，按照要求处理电话号码，可以使用列表记录数字。
//在主方法中判断如果S包含@，则按MaskEmail处理，否则按MaskPhone处理。
using System;
using System.Collections.Generic;

namespace MaskingPersonalInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "1(234)567-890";
            Console.WriteLine(MaskPII(S));
        }
        static string MaskPII(string S)
        {
            if (S.Contains('@'))
                return MaskEmail(S);
            else
                return MaskPhone(S);
                
        }
        static string MaskEmail(string S)
        {
            string[] names = S.Split('@', '.');
            string tem = names[0].ToLower();
            string name1 = tem[0] + "*****" + tem[tem.Length - 1];
            string name2 = names[1].ToLower();
            string name3 = names[2].ToLower();
            return name1 + "@" + name2 + "." + name3;
        }
        static string MaskPhone(string S)
        {
            string res = "";
            List<int> record = new List<int>();
            for (int i = 0; i < S.Length; i++)
                if (S[i] >= 48 && S[i] <= 57)
                    record.Add(S[i] - '0');
            if (record.Count > 10)
            {
                record.Reverse();
                for (int i = 0; i < 4; i++)
                    res = record[i] + res;
                res = "-***-***-" + res;
                for (int i = 0; i < record.Count - 10; i++)
                    res = "*" + res;
                res = "+" + res;
            }
            else
            {
                res += "***-***-";
                for (int i = 6; i < 10; i++)
                    res += record[i];
            }
            return res;
        }
    }
}
