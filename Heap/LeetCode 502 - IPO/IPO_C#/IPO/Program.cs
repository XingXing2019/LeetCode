int k = 1, w = 2;
int[] profits = { 1, 2, 3 };
int[] capital = { 1, 1, 2 };
Console.WriteLine(FindMaximizedCapital(k, w, profits, capital));

int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
{
    var projects = new List<int[]>();
    var maxProfits = new PriorityQueue<int, int>();
    for (int i = 0; i < profits.Length; i++)
        projects.Add(new[] { capital[i], profits[i] });
    projects = projects.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToList();
    var index = 0;
    for (int i = 0; i < Math.Min(k, profits.Length); i++)
    {
        while (index < projects.Count && projects[index][0] <= w)
        {
            maxProfits.Enqueue(projects[index][1], -projects[index][1]);
            index++;
        }
        if (maxProfits.Count == 0)
            return w;
        var profit = maxProfits.Dequeue();
        w += profit;
    }
    return w;
}