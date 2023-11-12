int n = 5, limit = 2;
Console.WriteLine(DistributeCandies(n, limit));

int DistributeCandies(int n, int limit)
{
    var res = 0;
    for (int i = 0; i <= Math.Min(n, limit); i++)
    {
        for (int j = 0; j <= Math.Min(n - i, limit); j++)
        {
            for (int k = 0; k <= Math.Min(n - i - j, limit); k++)
            {
                if (i + j + k != n) continue;
                res++;
            }
        }
    }
    return res;
}