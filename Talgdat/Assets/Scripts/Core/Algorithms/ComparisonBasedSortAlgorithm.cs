using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ComparisonBasedSortAlgorithm<Element, Func, Collection> : SortAlgorithm<Element, Func, Collection> where Element : ComparableElement where Func : CompareFunction<Element> where Collection : TCollection<Element>
{
    public ComparisonBasedSortAlgorithm(ProblemConfig config) : base(config) { }
}
