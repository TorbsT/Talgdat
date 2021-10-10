using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core
{
    public IntList list { get => _list; }

    public const int Seed = 123;
    private IntList _list;

    public Core()
    {
        _list = IntList.GenerateRandom(1, 11, 19);
        QuickSort sort = new QuickSort();
        Debug.Log(_list);
        sort.Sort(_list);
        Debug.Log(_list);
    }
}
