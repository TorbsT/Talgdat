using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;

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
        _list = IntList.GenerateRandom(1, 10, 7);
    }
    public void Solve()
    {
        BogoSort sort = new BogoSort(_list);
        Debug.Log(_list);
        sort.Sort();
        Debug.Log(_list);
    }
}
