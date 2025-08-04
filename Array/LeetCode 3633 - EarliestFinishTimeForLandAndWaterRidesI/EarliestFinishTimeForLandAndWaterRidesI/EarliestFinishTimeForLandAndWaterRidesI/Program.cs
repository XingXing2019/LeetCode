int[] landStartTime = { 2, 8 };
int[] landDuration = { 4, 1 };
int[] waterStartTime = { 6 };
int[] waterDuration = { 3 };

Console.WriteLine(EarliestFinishTime(landStartTime, landDuration, waterStartTime, waterDuration));

int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
{
    var res = int.MaxValue;
    for (int i = 0; i < landStartTime.Length; i++)
    {
        int landStart = landStartTime[i], landEnd = landStart + landDuration[i];
        for (int j = 0; j < waterStartTime.Length; j++)
        {
            int waterStart = waterStartTime[j], waterEnd = waterStart + waterDuration[j];
            res = Math.Min(res, Math.Max(landEnd, waterStart) + waterDuration[j]);
            res = Math.Min(res, Math.Max(waterEnd, landStart) + landDuration[i]);
        }
    }
    return res;
}