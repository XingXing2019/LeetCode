var summary = new SummaryRanges();
summary.AddNum(1);
summary.GetIntervals();
summary.AddNum(3);
summary.GetIntervals();
summary.AddNum(7);
summary.GetIntervals();
summary.AddNum(2);
summary.GetIntervals();
summary.AddNum(6);
summary.GetIntervals();

public class SummaryRanges
{
    private SortedSet<int> stream;
    public SummaryRanges()
    {
        stream = new SortedSet<int>();
    }

    public void AddNum(int value)
    {
        stream.Add(value);
    }

    public int[][] GetIntervals()
    {
        var res = new List<int[]>();
        int start = -2, end = start;
        var inserted = false;
        foreach (var num in stream)
        {
            if (num != end + 1)
            {
                if (!inserted)
                    inserted = true;
                else
                    res.Add(new[] { start, end });
                start = num;
            }
            end = num;
        }
        res.Add(new[] { start, end });
        return res.ToArray();
    }
}
