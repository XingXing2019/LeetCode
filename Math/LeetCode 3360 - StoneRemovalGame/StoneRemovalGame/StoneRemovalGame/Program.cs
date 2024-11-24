bool CanAliceWin(int n)
{
    var last = Math.Ceiling((Math.Sqrt(439 - 8 * n) + 1) / 2);
    return last % 2 == 0;
}