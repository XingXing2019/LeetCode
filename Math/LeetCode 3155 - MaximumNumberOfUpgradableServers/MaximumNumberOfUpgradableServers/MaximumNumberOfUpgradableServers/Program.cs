int[] MaxUpgrades(int[] count, int[] upgrade, int[] sell, int[] money)
{
    var res = new int[count.Length];
    for (int i = 0; i < res.Length; i++)
        res[i] = Math.Min(count[i], (int)((money[i] + (long)count[i] * sell[i]) / (upgrade[i] + sell[i])));
    return res;
}