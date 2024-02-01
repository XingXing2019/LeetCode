int FindPattern(InfiniteStream stream, int[] pattern)
{
    var target = string.Join("", pattern);
    var cur = "";
    while (cur.Length < target.Length)
        cur += stream.Next();
    var index = 0;
    while (cur != target)
    {
        cur = cur.Substring(1) + stream.Next();
        index++;
    }
    return index;
}

class InfiniteStream
{
    public InfiniteStream(int[] bits) {};
    public int Next() => 0;
}