int[][] tasks = new int[][]
{
    new[] { 1, 2 },
    new[] { 2, 4 },
    new[] { 3, 2 },
    new[] { 4, 1 },
};
Console.WriteLine(GetOrder(tasks));

int[] GetOrder(int[][] tasks)
{
    var taskPool = new List<Task>();
    var res = new int[tasks.Length];
    int p1 = 0, p2 = 0;
    for (var i = 0; i < tasks.Length; i++)
        taskPool.Add(new Task(i, tasks[i][0], tasks[i][1]));
    taskPool = taskPool.OrderBy(x => x.enqueueTime).ThenBy(x => x.processTime).ToList();
    var minHeap = new PriorityQueue<Task, Task>();
    while (p1 < taskPool.Count)
    {
        var cur = taskPool[p1].enqueueTime;
        while (p1 < taskPool.Count && taskPool[p1].enqueueTime <= cur)
            minHeap.Enqueue(taskPool[p1], taskPool[p1++]);
        while (minHeap.Count != 0)
        {
            var task = minHeap.Dequeue();
            res[p2++] = task.id;
            cur += task.processTime;
            while (p1 < taskPool.Count && taskPool[p1].enqueueTime <= cur)
                minHeap.Enqueue(taskPool[p1], taskPool[p1++]);
        }
    }
    while (minHeap.Count != 0)
        res[p2++] = minHeap.Dequeue().id;
    return res;
}

class Task : IComparable
{
    public int id;
    public int enqueueTime;
    public int processTime;

    public Task(int id, int enqueueTime, int processTime)
    {
        this.id = id;
        this.enqueueTime = enqueueTime;
        this.processTime = processTime;
    }

    public int CompareTo(object? obj)
    {
        var that = (Task)obj;
        if (this.processTime > that.processTime)
            return 1;
        if (this.processTime < that.processTime)
            return -1;
        return this.id > that.id ? 1 : -1;
    }
}