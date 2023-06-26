int[] costs = { 57, 33, 26, 76, 14, 67, 24, 90, 72, 37, 30 };
int k = 11, candidates = 2;

Console.WriteLine(TotalCost(costs, k, candidates));

long TotalCost(int[] costs, int k, int candidates)
{
    var front = new PriorityQueue<int, int>();
    var back = new PriorityQueue<int, int>();
    int li = 0, hi = costs.Length - 1;
    long res = 0;
    while (li <= hi && front.Count < candidates && back.Count < candidates)
    {
        front.Enqueue(costs[li], costs[li++]);
        if (li > hi) break;
        back.Enqueue(costs[hi], costs[hi--]);
    }
    for (int i = 0; i < k; i++)
    {
        var takeFront = false;
        if (front.Count == 0) takeFront = false;
        else if (back.Count == 0) takeFront = true;
        else if (front.Peek() <= back.Peek()) takeFront = true;
        else if (front.Peek() > back.Peek()) takeFront = false;
        res += takeFront ? front.Dequeue() : back.Dequeue();
        if (li > hi) continue;
        if (takeFront)
            front.Enqueue(costs[li], costs[li++]);
        else
            back.Enqueue(costs[hi], costs[hi--]);
    }
    return res;
}