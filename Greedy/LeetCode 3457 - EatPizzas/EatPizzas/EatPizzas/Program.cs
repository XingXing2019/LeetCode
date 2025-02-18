int[] pizzas = { 5, 2, 2, 4, 3, 3, 1, 3, 2, 5, 4, 2 };
Console.WriteLine(MaxWeight(pizzas));

long MaxWeight(int[] pizzas)
{
    Array.Sort(pizzas);
    int li = 0, hi = pizzas.Length - 1;
    int days = pizzas.Length / 4, even = days / 2, odd = days - even;
    var res = 0L;
    for (int i = 0; i < odd; i++)
    {
        res += pizzas[hi--];
        li += 3;
    }
    for (int i = 0; i < even; i++)
    {
        res += pizzas[--hi];
        hi--;
        li += 2;
    }
    return res;
}