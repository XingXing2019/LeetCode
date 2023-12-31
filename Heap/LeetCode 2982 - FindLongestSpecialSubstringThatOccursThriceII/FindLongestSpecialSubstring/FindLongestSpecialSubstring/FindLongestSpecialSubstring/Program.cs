var s = "aaaa";
Console.WriteLine(MaximumLength(s));

int MaximumLength(string s)
{
    var res = -1;
    var len = new int[s.Length];
    len[0] = 1;
    for (int i = 1; i < s.Length; i++)
        len[i] = s[i] == s[i - 1] ? len[i - 1] + 1 : 1;
    var dict = new Dictionary<int, PriorityQueue<int, int>>();
    for (int i = 0; i < s.Length; i++)
    {
        if (!dict.ContainsKey(s[i] - 'a'))
            dict[s[i] - 'a'] = new PriorityQueue<int, int>();
        var queue = dict[s[i] - 'a'];
        queue.Enqueue(len[i], len[i]);
        if (queue.Count > 3)
            queue.Dequeue();
        if (queue.Count == 3)
            res = Math.Max(res, queue.Peek());
    }
    return res;
}