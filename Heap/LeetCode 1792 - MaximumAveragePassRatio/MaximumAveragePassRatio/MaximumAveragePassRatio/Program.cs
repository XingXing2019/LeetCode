int[][] classes = new int[][]
{
    new[] { 2, 4 },
    new[] { 3, 9 },
    new[] { 2, 10 },
};
var extraStudents = 2;
Console.WriteLine(MaxAverageRatio(classes, extraStudents));

double MaxAverageRatio(int[][] classes, int extraStudents)
{
    var queue = new PriorityQueue<int[], double>();
    foreach (var c in classes)
        queue.Enqueue(c, (double)c[0] / c[1] - (double)(c[0] + 1) / (c[1] + 1));
    for (int i = 0; i < extraStudents; i++)
    {
        var c = queue.Dequeue();
        c[0]++;
        c[1]++;
        queue.Enqueue(c, (double)c[0] / c[1] - (double)(c[0] + 1) / (c[1] + 1));
    }
    var total = 0d;
    while (queue.Count != 0)
    {
        var c = queue.Dequeue();
        total += (double)c[0] / c[1];
    }
    return total / classes.Length;
}