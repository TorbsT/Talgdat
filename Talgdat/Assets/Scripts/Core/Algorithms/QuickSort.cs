using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuickSort<Element, Func> : ComparisonBasedSortAlgorithm<Element, Func, TList<Element>> where Element : ComparableElement where Func : CompareFunction<Element>
{
    // Collection is TList
    private TList<Element> list;
    private Func function;

    public QuickSort(TList<Element> list, Func function, ProblemConfig config) : base(config)
    {
        this.function = function;
        this.list = list;
    }

    protected override bool _Solve()
    {
        Sort(0, list.Count-1);
        return true;
    }
    public void Sort(int low, int high)
    {
        if (low < high)
        {
            int split = Partition(low, high);
            Sort(low, split-1);
            Sort(split+1, high);
        }
    }
    public int Partition(int low, int high)
    {  // Split 
        Element pivot = list[high];
        int i = low-1;

        for (int j = low; j < high; j++)
        {
            if (function.LessThan(list[j], pivot))
            {
                i++;
                list.Swap(i, j);
            }
        }
        list.Swap(i + 1, high);
        return (i + 1);
    }

    public override TList<Element> CopyInput()
    {
        return input.Copy();
    }
    public override TList<Element> CopyOutput()
    {
        return output.Copy();
    }
}
