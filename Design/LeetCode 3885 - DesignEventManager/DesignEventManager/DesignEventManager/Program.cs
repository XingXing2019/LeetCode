int[][] events = new[]
{
    new[] { 5, 7 },
    new[] { 2, 7 },
    new[] { 9, 4 },
};
var manager = new EventManager(events);
Console.WriteLine(manager.PollHighest());
manager.UpdatePriority(9, 7);
Console.WriteLine(manager.PollHighest());

class EventManager
{
    class Event : IComparable<Event>
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public int CompareTo(Event? other)
        {
            if (this.Priority == other.Priority)
                return other.Id - this.Id;
            return this.Priority - other.Priority;
        }
    }

    private SortedSet<Event> set;
    private Dictionary<int, Event> dict;

    public EventManager(int[][] events)
    {
        set = new SortedSet<Event>();
        dict = new Dictionary<int, Event>();
        foreach (var e in events)
        {
            var item = new Event { Id = e[0], Priority = e[1] };
            set.Add(item);
            dict[e[0]] = item;
        }
    }

    public void UpdatePriority(int eventId, int newPriority)
    {
        var item = dict[eventId];
        set.Remove(item);
        item.Priority = newPriority;
        set.Add(item);
    }

    public int PollHighest()
    {
        if (set.Count == 0) return -1;
        var item = set.Max;
        set.Remove(item);
        return item.Id;
    }
}