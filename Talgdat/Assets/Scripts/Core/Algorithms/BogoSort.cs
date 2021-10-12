using System;

/*
public class BogoSort<Element, Func> : ComparisonBasedSortAlgorithm<Element, Func, TList<Element>> where Element : ComparableElement where Func : CompareFunction<Element>

{
    private static int maxTrials = 10000;
    private int trials;
    private Random rd;
    private Algorithm problem;
    private IntList list;
    public BogoSort(Algorithm problem, IntList list)
    {
        this.list = problem.CopyInput();
        rd = new Random(problem.config.seed);
    }

    public bool Sort()
    {
        while (!isSorted(list))
        {
            if (trials > maxTrials) return false;
            shuffle(list);
            trials++;
        }
        return true;
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
*/