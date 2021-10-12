using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SwapCommand : Command
{
    public int aIndex { get => _aIndex; }
    public int bIndex { get => _bIndex; }

    private int _aIndex;
    private int _bIndex;

    public SwapCommand(int aIndex, int bIndex)
    {
        _aIndex = aIndex;
        _bIndex = bIndex;
    }
}
