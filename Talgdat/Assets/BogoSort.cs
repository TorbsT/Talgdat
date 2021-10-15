using System;

public class BogoSort : ISortAlgorithm
{
    public const string Name = "BogoSort";
    private static int maxTrials = 10000;
    private int trials;
    private Random rd;
    private IntList list;
    public BogoSort()
    {
        
    }

    public void Sort(IntList list)
    {
        this.list = list;
        rd = new Random(1);
        while (!isSorted() && trials < maxTrials)
        {
            shuffle();
            trials++;
        }
    }
    private void shuffle()
    {
        for (int i = 0; i < list.Count-1; i++)
        {
            int j = rd.Next(i, list.Count);
            if (i != j) list.Swap(i, j);
        }
    }
    private bool isSorted()
    {
        int prevValue = list[0];
        for (int i = 1; i < list.Count; i++)
        {
            int value = list[i];
            if (value < prevValue) return false;
            prevValue = value;
        }
        return true;
    }
}
