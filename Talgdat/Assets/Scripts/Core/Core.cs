using System.Collections;
using System.Collections.Generic;
using System;
using Unity.Jobs;

public class Core
{
    public SortAlgorithm<IntElement, CompareFunction<IntElement>, IntList> Algorithm { get => _algorithm; }
    private SortAlgorithm<IntElement, CompareFunction<IntElement>, IntList> _algorithm;



    public Core()
    {
        
        
    }
    public void Restart(ProblemConfig config)
    {
        IntComparator.Ascending ascendComparator = new IntComparator.Ascending();
        IntList list = new IntList();
        // generate
        Random rd = new Random(config.seed);
        for (int i = 0; i < config.count; i++)
        {
            IntElement ie = new IntElement(rd.Next(config.min, config.max));
            list.Add(ie);
        }
        list.LockInput();

        test = new QuickSort<IntElement, CompareFunction<IntElement>>(list, ascendComparator, config);

        _algorithm = new QuickSort<IntElement, CompareFunction<IntElement>>(list, ascendComparator, config);
        _algorithm = new QuickSort<IntElement, IntComparator.Ascending>(list, ascendComparator, config);



        Algorithm<Object, Object> test;
        EndomorphicAlgorithm<Object> test1;
        SortAlgorithm<ComparableElement, CompareFunction<ComparableElement>, TCollection<ComparableElement>> test2;
        ComparisonBasedSortAlgorithm<ComparableElement, CompareFunction<ComparableElement>, TCollection<ComparableElement>> test3 = new QuickSort<ComparableElement, CompareFunction<ComparableElement>>(list, ascendComparator, config);
        QuickSort<IntElement, IntComparator.Ascending> test4 = new QuickSort<IntElement, IntComparator.Ascending>(list, ascendComparator, config);



    }
    public void Solve()
    {
        _algorithm.Solve();
    }
}
