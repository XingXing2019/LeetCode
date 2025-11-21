int LateFee(int[] daysLate)
{
    return daysLate.Sum(x => x == 1 ? 1 : x > 5 ? x * 3 : x * 2);
}