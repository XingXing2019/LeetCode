using System.Text;

var s = "(())";
var k = 1;
Console.WriteLine(RemoveSubstring(s, k));

string RemoveSubstring(string s, int k)
{
    var res = new List<char>();
    foreach (var l in s)
    {
        res.Add(l);
        if (res.Count < 2 * k) continue;
        var isValid = true;
        for (int i = 0; i < k; i++)
        {
            if (res[res.Count - 2 * k + i] != '(')
            {
                isValid = false;
                break;
            }
            if (res[^(i + 1)] != ')')
            {
                isValid = false;
                break;
            }
        }
        if (!isValid) continue;
        res = res.Take(res.Count - 2 * k).ToList();
    }
    return string.Join("", res);
}