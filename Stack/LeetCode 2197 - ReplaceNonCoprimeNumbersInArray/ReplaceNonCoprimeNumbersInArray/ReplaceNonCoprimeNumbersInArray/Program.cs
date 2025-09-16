IList<int> ReplaceNonCoprimes(int[] nums)
{

}

int GCD(int a, int b)
{
    if (a % b == 0)
        return b;
    return GCD(b, a % b);
}