var s = "aaaa";
var k = 2;
Console.WriteLine(MergeCharacters(s, k));

string MergeCharacters(string s, int k)
{
    var indexes = new int[26];
    Array.Fill(indexes, -s.Length - 1);
    var remove = 0;
    var stack = new Stack<char>();
    for (int i = 0; i < s.Length; i++)
    {
        var index = i - remove;
        if (index - indexes[s[i] - 'a'] <= k)
        {
            remove++;
        }
        else
        {
            indexes[s[i] - 'a'] = index;
            stack.Push(s[i]);
        }
    }
    return string.Join("", stack.Reverse());
}