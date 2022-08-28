using System;
using System.Text;

namespace RemovingStarsFromAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string RemoveStars(string s)
        {
            var sb = new StringBuilder();
            foreach (var l in s)
            {
                if (l != '*')
                    sb.Append(l);
                else
                {
                    if (sb.Length > 0)
                        sb.Remove(sb.Length - 1, 1);
                    else
                        sb.Append(l);
                }
            }
            return sb.ToString();
        }
    }
}
