int[] BestTower(int[][] towers, int[] center, int radius)
{
    towers = towers.Where(x => Math.Abs(x[0] - center[0]) + Math.Abs(x[1] - center[1]) <= radius).OrderByDescending(x => x[2]).ThenBy(x => (long)x[0] * 100_000 + x[1]).ToArray();
    return towers.Length == 0 ? new[] { -1, -1 } : new []{ towers[0][0], towers[0][1] };
}