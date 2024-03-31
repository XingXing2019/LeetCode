int numBottles = 13, numExchange = 6;
Console.WriteLine(MaxBottlesDrunk(numBottles, numExchange));

int MaxBottlesDrunk(int numBottles, int numExchange)
{
    int res = 0, empty = 0;
    while (numBottles != 0)
    {
        res += numBottles;
        empty += numBottles;
        numBottles = 0;
        while (empty >= numExchange)
        {
            empty -= numExchange;
            numBottles++;
            numExchange++;
        }
    }
    return res;
}