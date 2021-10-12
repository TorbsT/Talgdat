using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;

public class Core
{
    public IntList list { get => _list; }

    private IntList _list;

    public Core()
    {
        
        
    }
    public void Restart()
    {
        ProblemConfig config = Talgdat.ProblemConfig;
        _list = IntList.GenerateRandom(config.Min, config.Max, config.Count, config.Seed);
    }
    public void Solve()
    {
        QuickSort sort = new QuickSort();
        Debug.Log(_list);
        sort.Sort(_list);
        Debug.Log(_list);
    }
}
