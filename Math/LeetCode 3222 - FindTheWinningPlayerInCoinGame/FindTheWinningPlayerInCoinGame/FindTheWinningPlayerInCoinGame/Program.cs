string LosingPlayer(int x, int y)
{
    y /= 4;
    if (x > y)
        return y % 2 != 0 ? "Alice" : "Bob";
    return x % 2 != 0 ? "Alice" : "Bob";
}