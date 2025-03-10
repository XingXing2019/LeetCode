int[] fruits = { 4, 2, 5 };
int[] baskets = { 3, 5, 4 };
Console.WriteLine(NumOfUnplacedFruits(fruits, baskets));

int NumOfUnplacedFruits(int[] fruits, int[] baskets)
{
    var res = 0;
    var used = new HashSet<int>();
    foreach (var f in fruits)
    {
        bool found = false;
        for (int i = 0; i < baskets.Length; i++)
        {
            if (baskets[i] >= f && used.Add(i))
            {
                found = true;
                break;
            }
        }
        if (!found)
            res++;
    }
    return res;
}