using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core
{
    public const int Seed = 123;
    private IntList list;

    public Core()
    {
        list = IntList.GenerateRandom(1, 100, 1000);
        QuickSort sort = new QuickSort();
        Debug.Log(list);
        sort.Sort(list);
        Debug.Log(list);
    }
}
