int[][] rectangles = new[]
{
	new [] {1, 0, 5, 2},
	new [] {0, 2, 2, 4},
	new [] {3, 2, 5, 3},
	new [] {0, 4, 4, 5},
};
var n = 5;
Console.WriteLine(CheckValidCuts(n, rectangles));

bool CheckValidCuts(int n, int[][] rectangles)
{
	var h = Count(rectangles.Select(x => new [] { x[1], x[3] }).ToArray());
	var v = Count(rectangles.Select(x => new [] { x[0], x[2] }).ToArray());
	return h >= 3 || v >= 3;
}

int Count(int[][] intervals)
{
	intervals = intervals.OrderBy(x => x[0]).ToArray();
    int li = intervals[0][0], hi = intervals[0][1], count = 1;
	for (int i = 1; i < intervals.Length; i++)
	{
		var interval = intervals[i];
		if (interval[0] < hi)
			hi = Math.Max(hi, interval[1]);
		else
		{
			count++;
			li = interval[0];
			hi = interval[1];
		}
	}
	return count;
}