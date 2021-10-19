using System;

public class OptimizedBogoSort : ISortAlgorithm
{
    public const string Name = "Optimized BogoSort";
    private const int maxTrials = 1000000;
    private int trials;
    private IntList list;
    private int low;  // Lowest unsorted index
    private int high;  // Highest unsorted index
    public void Sort(IntList list)
    {
        Random rd = new Random(1);
        this.list = list;
        low = 0;
        high = list.Count - 1;
        while (low < high && trials < maxTrials)
        {
            while (low < high && LowIsMin(low, high)) low++;
            while (low < high && HighIsMax(low, high)) high--;
            if (low < high) { BogoSort.Shuffle(list, low, high, rd); trials++; }
        }
    }
    private bool LowIsMin(int low, int high)
    {
        int val = list[low];
        for (int i = low+1; i < high+1; i++)
        {
            if (val > list[i]) return false;
        }
        return true;
    }
    private bool HighIsMax(int low, int high)
    {
        int val = list[high];
        for (int i = low; i < high; i++)
        {
            if (val < list[i]) return false;
        }
        return true;
    }
}
