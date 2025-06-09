string[] classroom = { "LS", "L." };
var energy = 3;
Console.WriteLine(MinMoves(classroom, energy));

int MinMoves(string[] classroom, int energy)
{
    var count = 0;
    var start = new int[2];
    for (int i = 0; i < classroom.Length; i++)
    {
        for (int j = 0; j < classroom[0].Length; j++)
        {
            if (classroom[i][j] == 'L')
                count++;
            else if (classroom[i][j] == 'S')
                start = new[] { i, j };
        }
    }
    var res = int.MaxValue;
    DFS(classroom, start[0], start[1], energy, energy, count, 0, new HashSet<int> { start[0] * 20 + start[1] }, ref res);
    return res == int.MaxValue ? -1 : res;
}

void DFS(string[] classroom, int x, int y, int e, int energy, int litter, int step, HashSet<int> visited, ref int res)
{
    if (x < 0 || x >= classroom.Length || y < 0 || y >= classroom[0].Length || classroom[x][y] == 'X' || e < 0)
        return;
    if (classroom[x][y] == 'L') litter--;
    if (classroom[x][y] == 'R') e = energy;
    if (litter == 0)
    {
        res = Math.Min(res, step);
        return;
    }
    int[] dir = { 1, 0, -1, 0, 1 };
    for (int i = 0; i < 4; i++)
    {
        int newX = x + dir[i], newY = y + dir[i + 1];
        if (!visited.Add(newX * 20 + newY)) continue;
        DFS(classroom, newX, newY, e - 1, energy, litter, step + 1, visited, ref res);
        visited.Remove(newX * 20 + newY);
    }
}