
int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
{
    var map = new int[m][];
    for (int i = 0; i < m; i++)
        map[i] = new int[n];
    foreach (var wall in walls)
        map[wall[0]][wall[1]] = 1;
    foreach (var guard in guards)
        map[guard[0]][guard[1]] = 3;
    int[] dir = { 1, 0, -1, 0, 1 };
    foreach (var guard in guards)
    {
        map[guard[0]][guard[1]] = 3;
        for (int i = 0; i < 4; i++)
        {
            int x = guard[0] + dir[i], y = guard[1] + dir[i + 1];
            while (!(x < 0 || x >= m || y < 0 || y >= n || map[x][y] == 1 || map[x][y] == 3))
            {
                map[x][y] = 2;
                x += dir[i];
                y += dir[i + 1];
            }
        }
    }
    var res = 0;
    foreach (var row in map)
        res += row.Count(x => x == 0);
    return res;
}