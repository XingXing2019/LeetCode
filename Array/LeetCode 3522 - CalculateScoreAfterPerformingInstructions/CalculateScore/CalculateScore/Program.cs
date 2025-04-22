string[] instructions = { "jump", "add", "add", "jump", "add", "jump" };
int[] values = { 2, 1, 3, 1, -2, -3 };
Console.WriteLine(CalculateScore(instructions, values));

long CalculateScore(string[] instructions, int[] values)
{
    var res = 0L;
    var index = 0;
    var visited = new HashSet<int>();
    while (index >= 0 && index < instructions.Length && visited.Add(index))
    {
        if (instructions[index] == "add")
            res += values[index++];
        else
            index += values[index];
    }
    return res;
}