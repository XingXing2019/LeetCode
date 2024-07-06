int[] enemyEnergies = { 3, 2, 2 };
var currentEnergy = 2;
Console.WriteLine(MaximumPoints(enemyEnergies, currentEnergy));
long MaximumPoints(int[] enemyEnergies, int currentEnergy)
{
    var res = 0L;
    var index = enemyEnergies.Length - 1;
    Array.Sort(enemyEnergies);
    while (index >= 0 && currentEnergy >= enemyEnergies[0])
    {
        var count = currentEnergy / enemyEnergies[0];
        res += count;
        currentEnergy -= count * enemyEnergies[0];
        currentEnergy += enemyEnergies[index--];
    }
    return res;
}