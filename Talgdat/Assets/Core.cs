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
        
        
    }
    public void Restart()
    {
        _list = IntList.GenerateRandom(1, 1100, 1900);
    }
    public void Solve()
    {
        QuickSort sort = new QuickSort();
        sort.Sort(_list);
    }
}
