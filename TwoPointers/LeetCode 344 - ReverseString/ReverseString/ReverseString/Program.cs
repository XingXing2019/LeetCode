//思路就是随便做做就行，太简单。
//两头一起向中间扫，每次交换两头的元素，用tem作为辅助。
using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] s = null;
        }
        static void ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                char tem = s[left];
                s[left] = s[right];
                s[right] = tem;
                left++;
                right--;
            }
        }
    }
}
