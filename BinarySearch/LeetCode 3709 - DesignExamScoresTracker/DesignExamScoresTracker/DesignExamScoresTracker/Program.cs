var tracker = new ExamTracker();
tracker.Record(2, 2);
Console.WriteLine(tracker.TotalScore(1, 1));
Console.WriteLine(tracker.TotalScore(1, 2));
Console.WriteLine(tracker.TotalScore(2, 2));

public class ExamTracker
{
    private List<int[]> record;
    private List<long> prefix;
    public ExamTracker()
    {
        record = new List<int[]>();
        prefix = new List<long>();
    }

    public void Record(int time, int score)
    {
        record.Add(new[] { time, score });
        prefix.Add(prefix.Count == 0 ? score : prefix[^1] + score);
    }

    public long TotalScore(int startTime, int endTime)
    {
        int li = BinarySearch(startTime, false), hi = BinarySearch(endTime, true);
        return li <= hi ? li == 0 ? prefix[hi] : prefix[hi] - prefix[li - 1] : 0;
    }

    public int BinarySearch(int target, bool isEnd)
    {
        int li = 0, hi = record.Count - 1;
        while (li <= hi)
        {
            var mid = li + (hi - li) / 2;
            if (record[mid][0] == target)
                return mid;
            if (record[mid][0] < target)
                li = mid + 1;
            else
                hi = mid - 1;
        }
        return isEnd ? hi : li;
    }
}