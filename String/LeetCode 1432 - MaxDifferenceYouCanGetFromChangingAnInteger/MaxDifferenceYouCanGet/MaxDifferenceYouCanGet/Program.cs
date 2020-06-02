using System;

namespace MaxDifferenceYouCanGet
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 1154;
            Console.WriteLine(MaxDiff(num));
        }
        static int MaxDiff(int num)
        {
            string strNum = num.ToString();
            string num1 = "";
            string num2 = "";
            bool isChanged = false;
            char digit1 = 'a';
            char digit2 = 'a';
            for (int i = 0; i < strNum.Length; i++)
            {
                if (!isChanged)
                {
                    if (strNum[i] == '9')
                        num1 += strNum[i];
                    else
                    {
                        num1 += '9';
                        digit1 = strNum[i];
                        isChanged = true;
                    }
                }
                else
                    num1 += strNum[i] == digit1 ? '9' : strNum[i];
            }
            int index2 = 0;
            if (strNum[0] == '1')
            {
                while (index2 < strNum.Length)
                {
                    if (strNum[index2] == '1' || strNum[index2] == '0')
                        num2 += strNum[index2];
                    else
                    {
                        num2 += '0';
                        digit2 = strNum[index2];
                        index2++;
                        break;
                    }
                    index2++;
                }
                while (index2 < strNum.Length)
                {
                    num2 += strNum[index2] == digit2 ? '0' : strNum[index2];
                    index2++;
                }
            }
            else
            {
                digit2 = strNum[0];
                for (int i = 0; i < strNum.Length; i++)
                    num2 += strNum[i] == digit2 ? '1' : strNum[i];
            }
            return int.Parse(num1) - int.Parse(num2);
        }
    }

}
