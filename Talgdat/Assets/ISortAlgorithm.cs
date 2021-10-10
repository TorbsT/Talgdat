using System;
public interface ISortAlgorithm<Element> where Element : global::Element
{
    void Sort(Tlist<Element> tlist, Predicate<Element> predicate);
}
