class Router
{
    private HashSet<long> set;
    private int limit;
    private Queue<int[]> queue;
    private Dictionary<int, List<int>> dest;
    private Dictionary<int, int> start;

    public Router(int memoryLimit)
    {
        set = new HashSet<long>();
        limit = memoryLimit;
        queue = new Queue<int[]>();
        dest = new Dictionary<int, List<int>>();
        start = new Dictionary<int, int>();
    }

    private long Encode(int source, int destination, int timestamp)
    {
        return (long)timestamp * 1_000_000_000 + (long)source * 100_000 + (long)destination;
    }

    public bool AddPacket(int source, int destination, int timestamp)
    {
        var code = Encode(source, destination, timestamp);
        if (set.Contains(code))
            return false;
        set.Add(code);
        queue.Enqueue(new[] { source, destination, timestamp });
        if (!dest.ContainsKey(destination))
        {
            dest[destination] = new List<int>();
            start[destination] = 0;
        }
        dest[destination].Add(timestamp);
        if (queue.Count > limit)
        {
            var packet = queue.Dequeue();
            code = Encode(packet[0], packet[1], packet[2]);
            set.Remove(code);
            start[packet[1]]++;
        }
        return true;
    }

    public int[] ForwardPacket()
    {
        if (queue.Count == 0)
            return new int[0];
        var packet = queue.Dequeue();
        var code = Encode(packet[0], packet[1], packet[2]);
        set.Remove(code);
        start[packet[1]]++;
        return packet;
    }

    public int GetCount(int destination, int startTime, int endTime)
    {
        var li = BinarySearch(destination, startTime, true);
        var hi = BinarySearch(destination, endTime, false);
        return hi - li + 1;
    }

    private int BinarySearch(int destination, int target, bool left)
    {
        var timestamps = dest[destination];
        int li = start[destination], hi = timestamps.Count - 1;
        while (li <= hi)
        {
            var mid = li + (hi - li) / 2;
            if (left)
            {
                if (timestamps[mid] < target)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            else
            {
                if (timestamps[mid] <= target)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
        }
        return left ? li : hi;
    }
}