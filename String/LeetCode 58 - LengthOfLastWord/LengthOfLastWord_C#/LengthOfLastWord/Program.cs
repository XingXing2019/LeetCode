//先使用Trim()将字符串头尾的空格去掉。将结果存入trimedStr。创建len记录单词长度，初始值设为0。
//从后向前遍历trimedStr，当前字符不为空格时len加一。否则(遇到空格时)停止遍历。
//最后返回len。
using System;

namespace LengthOfLastWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = " Hello World ";
            Console.WriteLine(LengthOfLastWord(s));
        }
        static int LengthOfLastWord(string s)
        {
            string trimedStr = s.Trim();
            int len = 0;
            for (int i = trimedStr.Length - 1; i >= 0; i--)
            {
                if (trimedStr[i] != ' ')
                    len++;
                else
                    break;
            }
            return len;
        }

        static int LengthOfLastWord_BuildingIn(string s)
        {
            var words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return words.Length > 0 ? words[words.Length - 1].Length : 0;
        }
    }
}
