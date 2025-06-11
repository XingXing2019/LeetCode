int CountPermutations(int[] complexity)
{
    var sorted = complexity.OrderBy(x => x).ToArray();
    if (sorted[0] != complexity[0] || sorted[0] == sorted[1]) return 0;
    long res = 1, mod = 1_000_000_000 + 7;
    for (int i = 1; i < sorted.Length; i++)
        res = res * i % mod;
    return (int)res;
}