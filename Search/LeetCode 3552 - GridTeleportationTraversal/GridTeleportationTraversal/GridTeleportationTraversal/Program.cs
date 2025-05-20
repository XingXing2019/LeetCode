string[] matrix = { ".C", ".." };
Console.WriteLine(MinMoves(matrix));

int MinMoves(string[] matrix)
{
    var dp = new int[matrix.Length][];
    var dict = new Dictionary<char, List<int>>();
    for (int i = 0; i < matrix.Length; i++)
    {
        dp[i] = new int[matrix[0].Length];
        Array.Fill(dp[i], int.MaxValue);
        for (int j = 0; j < matrix[0].Length; j++)
        {
            if (!char.IsLetter(matrix[i][j])) continue;
            if (!dict.ContainsKey(matrix[i][j]))
                dict[matrix[i][j]] = new List<int>();
            dict[matrix[i][j]].Add(i * 1000 + j);
        }
    }
    int[] dir = { 0, 1, 0, -1, 0 };
    var queue = new Queue<int[]>();
    queue.Enqueue(new []{0, 0, 0, 0});
    dp[0][0] = 0;
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int x = cur[0], y = cur[1], step = cur[2], mask = cur[3];
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dir[i], newY = y + dir[i + 1];
            if (newX < 0 || newX >= matrix.Length || newY < 0 || newY >= matrix[0].Length || matrix[newX][newY] == '#') continue;
            if (dp[newX][newY] > step + 1)
            {
                dp[newX][newY] = step + 1;
                queue.Enqueue(new[] { newX, newY, step + 1, mask });
            }
        }
        var letter = matrix[x][y];
        if (!char.IsLetter(letter) || ((mask >> (letter - 'A')) & 1) != 0) continue;
        foreach (var next in dict[letter])
        {
            int newX = next / 1000, newY = next % 1000;
            if (dp[newX][newY] > step)
            {
                dp[newX][newY] = step;
                queue.Enqueue(new []{newX, newY, step, mask + (1 << (letter - 'A'))});
            }
        }
    }
    return dp[^1][^1] == int.MaxValue ? -1 : dp[^1][^1];
}