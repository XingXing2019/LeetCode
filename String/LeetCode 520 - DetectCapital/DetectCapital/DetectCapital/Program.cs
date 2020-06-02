//遍历单词，按照要求检查字母大小写即可。
using System;

namespace DetectCapital
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "USA";
        }
        static bool DetectCapitalUse(string word)
        {
            if (word.Length == 1)
                return true;
            if(word[0] >= 97 && word[0] <= 122)
            {
                for (int i = 1; i < word.Length; i++)
                {
                    if (word[i] >= 65 && word[i] <= 90)
                        return false;
                }
            }
            else
            {
                if(word[1] >= 97 && word[1] <= 122)
                {
                    for (int i = 2; i < word.Length; i++)
                    {
                        if (word[i] >= 65 && word[i] <= 90)
                            return false;
                    }
                }
                else
                {
                    for (int i = 2; i < word.Length; i++)
                    {
                        if (word[i] >= 97 && word[i] <= 122)
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
