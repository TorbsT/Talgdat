using System.Collections.Generic;
using System;

public class Tlist<T>
{
    private List<Element> _elements;
    private Predicate<Element> _predicate;
    public Tlist()
    {
        _elements = new List<Element>();
    }
    public void Sort(ISortAlgorithm<Element> algorithm, Predicate<Element> predicate)
    {
        
    }
}
