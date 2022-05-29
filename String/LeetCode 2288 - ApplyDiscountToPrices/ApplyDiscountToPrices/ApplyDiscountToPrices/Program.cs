using System;

namespace ApplyDiscountToPrices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string DiscountPrices(string sentence, int discount)
        {
            var words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                var index = words[i].IndexOf("$");
                if (index == -1 || index != 0)
                    continue;
                var temp = words[i].Substring(1);
                if (!double.TryParse(temp, out var num))
                    continue;
                num *= (100 - (double)discount) / 100;
                words[i] = $"${num:0.00}";
            }
            return string.Join(' ', words);
        }
    }
}
