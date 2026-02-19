int TotalDistance(string s)
{
    var keyboard = new[] { "qwertyuiop", "asdfghjkl", "zxcvbnm" };
    var dict = new Dictionary<char, int[]>();
    for (int i = 0; i < keyboard.Length; i++)
    {
        for (int j = 0; j < keyboard[i].Length; j++)
        {
            dict[keyboard[i][j]] = new int[] { i, j };
        }
    }
    int x = 1, y = 0, res = 0;
    foreach (var l in s)
    {
        var pos = dict[l];
        res += Math.Abs(pos[0] - x) + Math.Abs(pos[1] - y);
        x = pos[0];
        y = pos[1];
    }
    return res;
}