using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int x { get => _x; set { _x = value; } }
    public int y { get => _y; set { _y = value; } }

    public Node(int x, int y)
    {
        SetXY(x, y);
    }

    private int _x;
    private int _y;
    public void SetXY(int x, int y)
    {
        _x = x;
        _y = y;
    }
}
