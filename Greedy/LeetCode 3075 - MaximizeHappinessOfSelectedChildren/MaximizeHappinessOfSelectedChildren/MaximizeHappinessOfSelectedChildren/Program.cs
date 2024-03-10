long MaximumHappinessSum(int[] happiness, int k)
{
    var decrease = 0;
    Array.Sort(happiness, (a, b) => b - a);
    long res = 0;
    for (int i = 0; i < k; i++)
    {
        res += Math.Max(0, happiness[i] -  decrease);
        decrease++;
    }
    return res;
}