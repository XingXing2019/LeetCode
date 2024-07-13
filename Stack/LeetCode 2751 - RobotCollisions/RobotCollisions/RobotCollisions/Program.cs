int[] positions = { 5, 4, 3, 2, 1 };
int[] healths = { 2, 17, 9, 15, 10 };
var directions = "RRRRR";
Console.WriteLine(SurvivedRobotsHealths(positions, healths, directions));

IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
{
    var robots = new int[positions.Length][];
    for (int i = 0; i < positions.Length; i++)
    {
        var health = directions[i] == 'R' ? healths[i] : -healths[i];
        robots[i] = new[] { positions[i], health, i };
    }
    Array.Sort(robots, (a, b) => a[0] - b[0]);
    var stack = new Stack<int[]>();
    foreach (var r in robots)
    {
        while (r[1] < 0 && stack.Count != 0 && stack.Peek()[1] > 0 && stack.Peek()[1] < -r[1])
        {
            stack.Pop();
            r[1]++;
        }
        if (stack.Count != 0 && stack.Peek()[1] > 0 && r[1] < 0)
        {
            if (stack.Peek()[1] == -r[1])
                stack.Pop();
            else
                stack.Peek()[1]--;
        }
        else
            stack.Push(r);
    }
    var res = stack.OrderBy(x => x[2]).Select(x => Math.Abs(x[1])).ToList();
    return res;
}