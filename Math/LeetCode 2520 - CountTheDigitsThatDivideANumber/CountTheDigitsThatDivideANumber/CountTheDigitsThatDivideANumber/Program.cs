int CountDigits(int num)
{
    int copy = num, res = 0;
    while (copy != 0)
    {
        var digit = copy % 10;
        if (num % digit == 0)
            res++;
        copy /= 10;
    }
    return res;
}