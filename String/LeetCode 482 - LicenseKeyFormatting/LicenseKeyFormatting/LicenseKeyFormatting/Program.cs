using System;
using System.Text;

namespace LicenseKeyFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "5F3Z-2e-9-w";
            int K = 4;
            Console.WriteLine(LicenseKeyFormatting1(S, K));
        }
        static string LicenseKeyFormatting1(string S, int K)
        {
            StringBuilder sb = new StringBuilder();
            int charLen = 0;
            for (int i = S.Length - 1; i >= 0; i--)
            {
                if (S[i] != '-')
                {
                    if (charLen > 0 && charLen % K == 0)
                        sb.Append('-');
                    sb.Append(Char.ToUpper(S[i]));
                    charLen++;
                }
            }
            char[] chars = sb.ToString().ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        static string LicenseKeyFormatting2(string S, int K)
        {
            string[] tem = S.Split('-');
            string sWithoutDash = "";
            foreach (var s in tem)
                sWithoutDash += s;
            string res = "";
            int count = 0;
            for (int i = sWithoutDash.Length - 1; i >= 0; i--)
            {
                res = sWithoutDash[i] + res;
                count++;
                if (i == 0)
                    break;
                if(count % K == 0)
                    res = '-' + res;
            }
            return res.ToUpper();
        }
    }
}
