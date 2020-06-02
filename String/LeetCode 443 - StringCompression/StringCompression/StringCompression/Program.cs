//创建point指针指向数组头，创建count计数器，初始值设为1。创建tem用于存储将count转化为string后的值。
//从第二个元素开始遍历字符串，如果当前元素与前前一元素相等，则使count加一。否则当count等于1时，将当前point所指向元素更新为当前i指针所指向元素的前一元素，并将point向前移动一位。
//如果当前count不为1，则先将当前point所指向元素更新为当前i所指向元素的前一元素，并将point向前移动一位。将tem设置为count.ToString。
//遍历tem，用point指针将每一位加到chars数组中。最后将count重新设为1。
//在遍历完chars字符数组后，将最后一次拿到的字符及其个数加入chars数组。
using System;

namespace StringCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] chars = { 'a', 'b', 'c' };
            Console.WriteLine(Compress(chars));
        }
        static int Compress(char[] chars)
        {
            if (chars.Length <= 1)
                return chars.Length;
            int point = 0;
            int count = 1;
            string tem;
            for (int i = 1; i < chars.Length; i++)
            {
                if (chars[i] == chars[i - 1])
                    count++;
                else
                {
                    if (count == 1)
                        chars[point++] = chars[i - 1];
                    else
                    {
                        chars[point++] = chars[i - 1];
                        tem = count.ToString();
                        for (int j = 0; j < tem.Length; j++)
                            chars[point++] = tem[j];
                    }
                    count = 1;
                }
            }
            if (count == 1)
                chars[point++] = chars[chars.Length - 1];
            else
            {
                chars[point++] = chars[chars.Length - 1];
                tem = count.ToString();
                for (int i = 0; i < tem.Length; i++)
                    chars[point++] = tem[i];
            }
            return point;
        }
    }
}
