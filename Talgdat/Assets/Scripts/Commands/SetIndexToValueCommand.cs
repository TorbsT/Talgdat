using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SetIndexToValueCommand : ICommand
{
    public int index { get => _index; }
    public int value { get => _value; }

    private int _index;
    private int _value;

    public SetIndexToValueCommand(int index, int value)
    {
        _index = index;
        _value = value;
    }
}
