using System;

namespace MinimumNumberOfBuckets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var street = "H.H.H..H";
            Console.WriteLine(MinimumBuckets(street));
        }

        public static int MinimumBuckets(string street)
        {
            var covered = new bool[street.Length];
            var res = 0;
            for (int i = 0; i < street.Length; i++)
            {
                if (street[i] == 'H')
                {
                    var before = i != 0 && street[i - 1] == '.';
                    var after = i != street.Length - 1 && street[i + 1] == '.';
                    if (!before && !after)
                        return -1;
                }
                else
                {
                    if (i == 0 || i == street.Length - 1) continue;
                    if (street[i - 1] == 'H' && !covered[i - 1] && street[i + 1] == 'H' && !covered[i + 1])
                    {
                        res++;
                        covered[i - 1] = true;
                        covered[i + 1] = true;
                    }
                }
            }
            for (int i = 0; i < street.Length; i++)
            {
                if (street[i] == 'H') continue;
                if (i != 0 && street[i - 1] == 'H' && !covered[i - 1])
                {
                    res++;
                    covered[i - 1] = true;
                }
                if (i != street.Length - 1 && street[i + 1] == 'H' && !covered[i + 1])
                {
                    res++;
                    covered[i + 1] = true;
                }
            }
            return res;
        }
    }
}
