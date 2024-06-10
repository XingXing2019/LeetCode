int[] skills = { 2, 5, 4 };
var k = 3;
Console.WriteLine(FindWinningPlayer(skills, k));
int FindWinningPlayer(int[] skills, int k)
{
    var queue = new Queue<int[]>();
    var max = skills.Max();
    for (int i = 0; i < skills.Length; i++)
        queue.Enqueue(new[] { skills[i], i, 0 });
    var stack = new Stack<int[]>();
    while (queue.Peek()[2] != k)
    {
        var skill = queue.Dequeue();
        while (stack.Count != 0 && skill[0] > stack.Peek()[0])
        {
            skill[2]++;
            if (skill[2] == k) return skill[1];
            queue.Enqueue(stack.Pop());
        }
        if (stack.Count != 0)
        {
            stack.Peek()[2]++;
            if (stack.Peek()[2] == k) return stack.Peek()[1];
            queue.Enqueue(skill);
        }
        else
            stack.Push(skill);
        if (stack.Peek()[0] == max) return stack.Peek()[1];
    }
    return -1;
}