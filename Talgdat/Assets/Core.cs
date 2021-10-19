using System.Collections;
using System.Collections.Generic;
using System;

public class Core
{
    private static List<ISortAlgorithm> _sortAlgorithms = new List<ISortAlgorithm>
    {

    };

    public IntList list { get => _list; }

    private IntList _list;
    private ProblemConfig _config;

    public Core()
    {
        
        
    }
    public void Restart(ProblemConfig config)
    {
        _config = config;
        _list = IntList.GenerateRandom(config.Min, config.Max, config.Count, config.Seed);
        _list.LockInput();
    }
    public void Solve()
    {
        ISortAlgorithm alg = null;
        if (algorithmNameMatches(QuickSort.Name)) alg = new QuickSort();
        else if (algorithmNameMatches(BogoSort.Name)) alg = new BogoSort();
        else if (algorithmNameMatches(HeapSort.Name)) alg = new HeapSort();
        if (alg == null) throw new InvalidOperationException("Found no algoritm with name " + _config.Algorithm);
        alg.Sort(_list);
    }
    public static List<ISortAlgorithm> CopySortAlgorithms()
    {
        List<ISortAlgorithm> result = new List<ISortAlgorithm>();
        foreach (ISortAlgorithm a in _sortAlgorithms)
        {
            result.Add(a);
        }
        return result;
    }
    private bool algorithmNameMatches(string s) => _config.Algorithm.Equals(s);
}
