using System;

namespace MaximumValueOfAStringInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaximumValue(string[] strs)
        {
            var res = 0;
            foreach (var str in strs)
            {
                var len = int.TryParse(str, out var temp) ? temp : str.Length;
                res = Math.Max(res, len);
            }
            return res;
        }
    }
}
