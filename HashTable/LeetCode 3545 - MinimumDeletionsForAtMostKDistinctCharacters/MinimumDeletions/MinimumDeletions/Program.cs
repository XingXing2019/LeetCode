int MinDeletion(string s, int k)
{
    var freq = new int[26];
    foreach (var l in s)
        freq[l - 'a']++;
    var heap = new PriorityQueue<int, int>();
    var res = 0;
    foreach (var f in freq)
    {
        if (f == 0) continue;
        heap.Enqueue(f, f);
        if (heap.Count > k)
            res += heap.Dequeue();
    }
    return res;
}