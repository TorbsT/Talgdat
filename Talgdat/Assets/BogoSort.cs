using System;

public class BogoSort
{
    private static int maxTrials = 10000;
    private int trials;
    private Random rd;
    private IntList list;
    public BogoSort(IntList list)
    {
        this.list = list;
        
    }

    public void Sort()
    {
        while (!isSorted(list) && trials < maxTrials)
        {
            shuffle(list);
            trials++;
        }
    }
    private void shuffle(IntList list)
    {
        for (int i = 0; i < list.Count-1; i++)
        {
            int j = rd.Next(i, list.Count);
            if (i != j) list.Swap(i, j);
        }
    }
    private bool isSorted(IntList list)
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
