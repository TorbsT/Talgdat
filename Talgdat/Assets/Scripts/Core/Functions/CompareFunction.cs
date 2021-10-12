using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompareFunction<Element>
{
    public bool LessThan(Element a, Element b) => Compare(a, b) < 0;
    public bool LessOrEqualTo(Element a, Element b) => Compare(a, b) <= 0;
    public bool EqualTo(Element a, Element b) => Compare(a, b) == 0;
    public bool MoreOrEqualTo(Element a, Element b) => Compare(a, b) >= 0;
    public bool MoreThan(Element a, Element b) => Compare(a, b) > 0;
    public abstract int Compare(Element a, Element b);
}
