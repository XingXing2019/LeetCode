long MaxScore(int[] prices)
{
    return prices.Select((x, i) => new[] { x, i }).GroupBy(x => x[0] - x[1]).Max(x => x.Sum(y => (long)y[0]));
}