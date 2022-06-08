int[] inventory = { 3, 5 };
var orders = 6;
Console.WriteLine(MaxProfit(inventory, orders));


int MaxProfit(int[] inventory, int orders)
{
    var groups = inventory.GroupBy(x => x).OrderByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Count());
    var heap = new Queue<int[]>();
    foreach (var key in groups.Keys)
        heap.Enqueue(new []{key, groups[key]});
    long res = 0, mod = 1_000_000_000 + 7;
    while (orders > 0)
    {
        var top = heap.Dequeue();
        var next = heap.Count == 0 ? 0 : heap.Peek()[0];
        var max = (long)top[0];
        if (orders >= (top[0] - next) * top[1])
            res += (max + next + 1) * (max - next) / 2 * top[1];
        else
        {
            var count = orders / top[1];
            var left = orders % top[1];
            res += (max + max - count + 1) * count / 2 * top[1];
            res += (max - count) * left;
        }
        if (heap.Count != 0)
            heap.Peek()[1] += top[1];
        orders -= (top[0] - next) * top[1];
    }
    return (int) (res % mod);
}