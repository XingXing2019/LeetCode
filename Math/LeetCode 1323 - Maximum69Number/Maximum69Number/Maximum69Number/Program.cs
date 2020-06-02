using System;

namespace Maximum69Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 6666;
            Console.WriteLine(Maximum69Number(num));
        }
        static int Maximum69Number(int num)
        {
            string strNum = num.ToString();
            string strRes = "";
            int i = 0;
            for (; i < strNum.Length; i++)
            {
                strRes += '9';
                if (strNum[i] == '6')
                    break;
            }
            if (i < strNum.Length - 1)
                strRes += strNum.Substring(i + 1);
            return int.Parse(strRes);
        }
    }
}
