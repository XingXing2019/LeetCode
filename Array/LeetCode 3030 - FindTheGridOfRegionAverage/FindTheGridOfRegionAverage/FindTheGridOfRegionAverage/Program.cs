int[][] image = new[]
{
    new[] { 1, 1, 4, 1 },
    new[] { 10, 8, 13, 17 },
    new[] { 2, 12, 1, 16 }
};
var threshold = 14;
Console.WriteLine(ResultGrid(image, threshold));

int[][] ResultGrid(int[][] image, int threshold)
{
    var dict = new Dictionary<string, List<int>>();
    var res = new int[image.Length][];
    for (int i = 0; i < image.Length; i++)
        res[i] = new int[image[0].Length];
    for (int x = 0; x <= image.Length - 3; x++)
    {
        res[x] = new int[image[0].Length];
        for (int y = 0; y <= image[0].Length - 3; y++)
        {
            var avg = GetAvgerage(image, x, y, threshold);
            if (avg == -1) continue;
            PopulateDict(dict, x, y, avg);
        }
    }
    for (int x = 0; x < res.Length; x++)
    {
        for (int y = 0; y < image[0].Length; y++)
        {
            res[x][y] = dict.ContainsKey($"{x}:{y}") ? dict[$"{x}:{y}"].Sum() / dict[$"{x}:{y}"].Count : image[x][y];
        }
    }
    return res;
}



int GetAvgerage(int[][] image, int ox, int oy, int threshold)
{
    int[] dx = { 0, 0, -1, 1 }, dy = { -1, 1, 0, 0 };
    var sum = 0;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            int x = ox + i, y = oy + j;
            for (int k = 0; k < 4; k++)
            {
                int newX = x + dx[k], newY = y + dy[k];
                if (newX < ox || newX >= Math.Min(image.Length, ox + 3) || newY < oy || newY >= Math.Min(image[0].Length, oy + 3))
                    continue;
                if (Math.Abs(image[x][y] - image[newX][newY]) > threshold)
                    return -1;
            }
            sum += image[x][y];
        }
    }
    return sum / 9;
}

void PopulateDict(Dictionary<string, List<int>> dict, int ox, int oy, int avg)
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            int x = ox + i, y = oy + j;
            if (!dict.ContainsKey($"{x}:{y}"))
                dict[$"{x}:{y}"] = new List<int>();
            dict[$"{x}:{y}"].Add(avg);
        }
    }
}