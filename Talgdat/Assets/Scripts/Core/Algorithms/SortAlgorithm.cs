using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SortAlgorithm<Element, Func, Collection> : EndomorphicAlgorithm<Collection> where Element : ComparableElement where Func : CompareFunction<Element> where Collection : TCollection<Element>
{
    public SortAlgorithm(ProblemConfig config) : base(config) { }
}
