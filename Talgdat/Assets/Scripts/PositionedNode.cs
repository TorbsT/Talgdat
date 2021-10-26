using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionedNode
{
    public int X { get => _x; }
    public int Y { get => _y; }

    private int _x;
    private int _y;
    public PositionedNode(int x, int y)
    {
        _x = x;
        _y = y;
    }
}
