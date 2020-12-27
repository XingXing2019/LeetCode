using System;
using System.Linq;

namespace MaximumBinaryStringAfterChange
{
    class Program
    {
        static void Main(string[] args)
        {
            var binary = "1011";
            Console.WriteLine(MaximumBinaryString(binary));
        }
        static string MaximumBinaryString(string binary)
        {
            int zero = 0, one = 0, index = 0;
            while (index < binary.Length && binary[index] == '1')
                index++;
            var front = new string('1', index);
            while (index < binary.Length)
            {
                if (binary[index] == '0')
                    zero++;
                else
                    one++;
                index++;
            }
            if (zero == 0) return binary;
            return front + new string('1', zero - 1) + "0" + new string('1', one);
        }
    }
}
