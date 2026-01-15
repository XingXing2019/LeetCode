int n = 2, m = 3;
int[] hBars = { 2, 3 };
int[] vBars = { 2, 4 };
Console.WriteLine(MaximizeSquareHoleArea(n, m, hBars, vBars));

int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars)
{
    var l = Math.Min(GetMaxGap(hBars), GetMaxGap(vBars));
    return l * l;
}

int GetMaxGap(int[] bars)
{
    Array.Sort(bars);
    int res = 1, dis = 1;
    for (int i = 1; i < bars.Length; i++)
    {
        if (bars[i] - bars[i - 1] == 1)
            dis++;
        else
            dis = 1;
        res = Math.Max(res, dis + 1);
    }
    return Math.Max(res, dis + 1);
}