using System.Text;

IList<string> PartitionString(string s)
{
    var res = new HashSet<string>();
    var index = 0;
    while (index < s.Length)
    {
        var sb = new StringBuilder();
        while (sb.Length == 0 || (res.Contains(sb.ToString()) && index < s.Length))
            sb.Append(s[index++]);
        res.Add(sb.ToString());
    }
    return res.ToList();
}