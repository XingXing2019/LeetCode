using System.Text;

string ReorganizeString(string s)
{
    var freq = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var max = freq.Max(x => x.Value);
    if (max - 1 > s.Length - max)
        return "";
    var maxLetter = freq.First(x => x.Value == max).Key;
    var res = new StringBuilder[max];
    for (int i = 0; i < max; i++)
        res[i] = new StringBuilder(maxLetter.ToString());
    var left = freq.Where(x => x.Key != maxLetter).Select(x => new int[] { x.Key, x.Value }).ToArray();
    var index = 0;
    for (int i = 0; i < left.Length; i++)
    {
        for (int j = 0; j < left[i][1]; j++)
        {
            res[index % max].Append((char)left[i][0]);
            index++;
        }
    }
    return string.Join("", res.Select(x => x.ToString()));
}

string ReorganizeString_Heap(string s)
{
    var dict = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var heap = new PriorityQueue<int[], int>();
    foreach (var letter in dict.Keys)
        heap.Enqueue(new[] { letter, dict[letter] }, -dict[letter]);
    var res = new StringBuilder();
    while (heap.Count != 0)
    {
        var max = heap.Dequeue();
        if (heap.Count == 0)
        {
            if (max[1] != 1)
                return "";
            res.Append((char)max[0]);
            max[1]--;
            if (max[1] != 0)
                heap.Enqueue(max, -max[1]);
        }
        else
        {
            var secMax = heap.Dequeue();
            res.Append((char)max[0]);
            res.Append((char)secMax[0]);
            max[1]--;
            secMax[1]--;
            if (max[1] != 0)
                heap.Enqueue(max, -max[1]);
            if (secMax[1] != 0)
                heap.Enqueue(secMax, -secMax[1]);
        }
    }
    return res.ToString();
}