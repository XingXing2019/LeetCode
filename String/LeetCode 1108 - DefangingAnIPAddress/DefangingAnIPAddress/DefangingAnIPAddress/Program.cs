//遍历字符串，如果发现.则用[.]替换。
using System;

namespace DefangingAnIPAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string DefangIPaddr(string address)
        {
            string res = "";
            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] == '.')
                    res += "[.]";
                else
                    res += address[i];
            }
            return res;
        }
    }
}
