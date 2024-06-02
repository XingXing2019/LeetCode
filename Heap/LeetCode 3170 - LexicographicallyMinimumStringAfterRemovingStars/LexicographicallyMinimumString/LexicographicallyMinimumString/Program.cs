using System.Text;

string ClearStars(string s)
{
    var delete = new HashSet<int>();
    var heap = new PriorityQueue<int, int>();
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] != '*')
            heap.Enqueue(i, s[i] * s.Length - i);
        else
        {
            delete.Add(i);
            delete.Add(heap.Dequeue());
        }
    }
    var res = new StringBuilder();
    for (int i = 0; i < s.Length; i++)
    {
        if (delete.Contains(i)) continue;
        res.Append(s[i]);
    }
    return res.ToString();
}