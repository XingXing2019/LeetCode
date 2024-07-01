int MaxHeightOfTriangle(int red, int blue)
{
    var op1 = GetHeight(red, blue);
    var op2 = GetHeight(blue, red);
    return Math.Max(op1, op2);
}

int GetHeight(int balls1, int balls2)
{
    var h1 = (int)Math.Sqrt(balls1);
    var h2 = (int)((Math.Sqrt(1 + 4 * balls2) - 1) / 2);
    return h1 <= h2 ? 2 * h1 : 2 * h2 + 1;
}