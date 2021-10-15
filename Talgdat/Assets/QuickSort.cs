using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSort : ISortAlgorithm
{
    public const string Name = "QuickSort";
    private bool _done;

    public QuickSort()
    {
       
    }
    public void Sort(IntList list)
    {
        Sort(list, 0, list.Count-1);
    }
    public void Sort(IntList list, int low, int high)
    {
        if (low < high)
        {
            int split = Partition(list, low, high);
            Sort(list, low, split-1);
            Sort(list, split+1, high);
        }
    }
    public int Partition(IntList list, int low, int high)
    {  // Split 
        int pivot = list[high];
        int i = low-1;

        for (int j = low; j < high; j++)
        {
            if (list[j] < pivot)
            {
                i++;
                list.Swap(i, j);
            }
        }
        list.Swap(i + 1, high);
        return (i + 1);
    }
}
