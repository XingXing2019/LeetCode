using System.Text;

string ConvertNumber(string s)
{
    var dict = new Dictionary<string, int>
    {
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
    };
    var res = new StringBuilder();
    var index = 0;
    while (index < s.Length)
    {
        var found = false;
        foreach (var num in dict.Keys)
        {
            if (s.Length - index < num.Length || s.Substring(index, num.Length) != num) continue;
            res.Append(dict[num]);
            index += num.Length;
            found = true;
            break;
        }
        if (!found) index++;
    }
    return res.ToString();
}