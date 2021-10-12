using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SetIndexToValueCommand : Command
{
    public int index { get => _index; }
    public string value { get => _value; }

    private int _index;
    private string _value;

    public SetIndexToValueCommand(int index, string value)
    {
        _index = index;
        _value = value;
    }
}
