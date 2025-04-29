int n = 4, maxDiff = 2;
int[] nums = { 2, 5, 6, 8 };
int[][] queries = new[]
{
    new[] { 0, 0 },
    new[] { 0, 1 },
};
Console.WriteLine(PathExistenceQueries(n, nums, maxDiff, queries));

int[] parents;
int[] rank;

bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
{
    parents = new int[n];
    for (int i = 0; i < n; i++)
        parents[i] = i;
    rank = new int[n];
    var segments = new List<int[]>();
    for (int i = 0; i < nums.Length; i++)
    {
        var index = BinarySearch(nums, nums[i] + maxDiff);
        segments.Add(new []{i, index});
    }
    foreach (var segment in segments)
    {
        for (int i = 0; i <= segment.Length; i++)
        {
            Union(segment[0], segment[i]);
        }   
    }
    var res = new bool[queries.Length];
    for (int i = 0; i < queries.Length; i++)
    {
        int x = queries[i][0], y = queries[i][1];
        int rootX = Find(x), rootY = Find(y);
        res[i] = rootX == rootY;
    }
    return res;
}

int BinarySearch(int[] nums, int target)
{
    int li = 0, hi = nums.Length - 1;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (nums[mid] <= target)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return hi;
}

int Find(int x)
{
    if (parents[x] != x)
        parents[x] = Find(parents[x]);
    return parents[x];
}

bool Union(int x, int y)
{
    int rootX = Find(x), rootY = Find(y);
    if (rootX == rootY)
        return false;
    if (rank[rootX] >= rank[rootY])
    {
        parents[rootY] = rootX;
        if (rank[rootX] == rank[rootY])
            rank[rootX]++;
    }
    else
        parents[rootX] = rootY;
    return true;
}