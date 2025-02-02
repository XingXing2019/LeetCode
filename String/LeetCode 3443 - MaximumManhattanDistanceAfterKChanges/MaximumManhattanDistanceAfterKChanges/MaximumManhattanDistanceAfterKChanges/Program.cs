using System.Text;

var s = "NWSE";
var k = 1;
Console.WriteLine(MaxDistance(s, k));

int MaxDistance(string s, int k)
{
    string[] dirs = { "NE", "NW", "SE", "SW" };
    var res = 0;
    foreach (var dir in dirs)
    {
        var copy = new StringBuilder(s);
        var count = k;
        for (int i = 0; i < copy.Length; i++)
        {
            if (!dir.Contains(copy[i]) && count != 0)
            {
                count--;
                copy[i] = dir[0];
            }
        }
        res = Math.Max(res, GetDistance(copy));
    }
    return res;
}

int GetDistance(StringBuilder s)
{
    int x = 0, y = 0;
    foreach (var l in s.ToString())
    {
        if (l == 'N')
            x--;
        else if (l == 'S')
            x++;
        else if (l == 'W')
            y--;
        else
            y++;
    }
    return Math.Abs(x) + Math.Abs(y);
}