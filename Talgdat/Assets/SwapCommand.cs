using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SwapCommand : Command
{
    public int aIndex { get => _aIndex; }
    public int aValue { get => _aValue; }
    public int bIndex { get => _bIndex; }
    public int bValue { get => _bValue; }

    private int _aIndex;
    private int _aValue;
    private int _bIndex;
    private int _bValue;

    public SwapCommand(int aIndex, int aValue, int bIndex, int bValue)
    {
        _aIndex = aIndex;
        _aValue = aValue;
        _bIndex = bIndex;
        _bValue = bValue;
    }
}
