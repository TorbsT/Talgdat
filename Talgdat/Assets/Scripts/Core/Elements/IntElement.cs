using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntElement : ComparableElement, IStringableElement
{
    public int x { get => _x; }
    private int _x;
    public IntElement(int x)
    {
        _x = x;
    }
    public int Compare(IntElement other)
    {
        return _x - other._x;
    }
    public string StringFormatted() => _x.ToString();
}
