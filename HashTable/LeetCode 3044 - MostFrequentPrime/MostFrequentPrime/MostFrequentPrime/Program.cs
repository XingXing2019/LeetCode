int[][] mat = new[]
{
    new[] { 1, 1 },
    new[] { 9, 9 },
    new[] { 1, 1 },
};
Console.WriteLine(MostFrequentPrime(mat));

int MostFrequentPrime(int[][] mat)
{
    var freq = new Dictionary<int, int>();
    var primes = GetPrimes(mat.Length, mat[0].Length);
    var max = 0;
    for (int x = 0; x < mat.Length; x++)
    {
        for (int y = 0; y < mat[0].Length; y++)
        {
            Travel(mat, x, y, primes, freq, ref max);
        }
    }
    return freq.Count == 0 ? -1 : freq.Where(x => x.Value == max).Max(x => x.Key);
}

HashSet<int> GetPrimes(int m, int n)
{
    var limit = (int)Math.Pow(10, Math.Max(m, n));
    var dp = new bool[limit + 1];
    Array.Fill(dp, true);
    for (int i = 2; i < dp.Length; i++)
    {
        for (int j = 2; i * j < dp.Length; j++)
        {
            dp[i * j] = false;
        }
    }
    var res = new HashSet<int>();
    for (int i = 2; i < dp.Length; i++)
    {
        if (!dp[i]) continue;
        res.Add(i);
    }
    return res;
}

void Travel(int[][] mat, int x, int y, HashSet<int> primes, Dictionary<int, int> freq, ref int max)
{
    int[] dx = { -1, 1, 0, 0, -1, 1, -1, 1 };
    int[] dy = { 0, 0, -1, 1, -1, -1, 1, 1 };
    int m = mat.Length, n = mat[0].Length;
    for (int i = 0; i < 8; i++)
    {
        var num = 0;
        for (int j = 0; j < Math.Max(m, n); j++)
        {
            int newX = x + dx[i] * j, newY = y + dy[i] * j;
            if (newX < 0 || newX >= m || newY < 0 || newY >= n)
                break;
            num = num * 10 + mat[newX][newY];
            if (num <= 10 || !primes.Contains(num))
                continue;
            if (!freq.ContainsKey(num))
                freq[num] = 0;
            freq[num]++;
            max = Math.Max(max, freq[num]);
        }
    }
}