int n = 28, m = 81;
Console.WriteLine(MinOperations(n, m));

int MinOperations(int n, int m)
{
    int[] pows = { 1, 10, 100, 1000, 10000 };
    var primes = GetPrimes(100002);
    if (primes.Contains(n) || primes.Contains(m))
        return -1;
    var dp = new int[100002];
    Array.Fill(dp, int.MaxValue);
    dp[n] = n;
    var queue = new PriorityQueue<int[], int>();
    queue.Enqueue(new[] { n, n }, n);
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        var num = cur[0].ToString();
        if (cur[0] == m)
            return cur[1];
        for (int i = num.Length - 1; i >= 0; i--)
        {
            var pow = pows[num.Length - i - 1];
            if (num[i] - '0' != 0)
            {
                var next = (int)(cur[0] - pow);
                if (!primes.Contains(next) && dp[next] > cur[1] + next && next.ToString().Length == m.ToString().Length)
                {
                    queue.Enqueue(new[] { next, cur[1] + next }, cur[1] + next);
                    dp[next] = cur[1] + next;
                }
            }
            if (num[i] - '0' != 9)
            {
                var next = (int)(cur[0] + pow);
                if (!primes.Contains(next) && dp[next] > cur[1] + next && next.ToString().Length == m.ToString().Length)
                {
                    queue.Enqueue(new[] { next, cur[1] + next }, cur[1] + next);
                    dp[next] = cur[1] + next;
                }
            }
        }
    }
    return dp[m] == int.MaxValue ? -1 : dp[m];
}



HashSet<int> GetPrimes(int n)
{
    var res = new HashSet<int>();
    var dp = new bool[n + 1];
    Array.Fill(dp, true);
    for (int i = 2; i < dp.Length; i++)
    {
        if (!dp[i]) continue;
        for (int j = 2; i * j < dp.Length; j++)
            dp[i * j] = false;
    }
    for (int i = 2; i < dp.Length; i++)
    {
        if (!dp[i]) continue;
        res.Add(i);
    }
    return res;
}