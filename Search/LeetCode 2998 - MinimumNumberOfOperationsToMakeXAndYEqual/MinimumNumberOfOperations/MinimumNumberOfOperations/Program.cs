int MinimumOperationsToMakeEqual(int x, int y)
{
    var queue = new Queue<int>();
    queue.Enqueue(x);
    var visited = new HashSet<int> { x };
    var res = 0;
    while (queue.Count != 0)
    {
        var count = queue.Count;
        for (int i = 0; i < count; i++)
        {
            var cur = queue.Dequeue();
            if (cur == y)
                return res;
            if (cur % 11 == 0 && visited.Add(cur / 11))
                queue.Enqueue(cur / 11);
            if (cur % 5 == 0 && visited.Add(cur / 5))
                queue.Enqueue(cur / 5);
            if (visited.Add(cur - 1))
                queue.Enqueue(cur - 1);
            if (visited.Add(cur + 1))
                queue.Enqueue(cur + 1);
        }
        res++;
    }
    return res;
}