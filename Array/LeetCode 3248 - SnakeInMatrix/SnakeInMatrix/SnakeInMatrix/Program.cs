int FinalPositionOfSnake(int n, IList<string> commands)
{
    int i = 0, j = 0;
    foreach (var command in commands)
    {
        if (command == "UP") i--;
        else if (command == "RIGHT") j++;
        else if (command == "DOWN") i++;
        else j--;
    }
    return i * n + j;
}