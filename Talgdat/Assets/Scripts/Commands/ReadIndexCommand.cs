using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ReadIndexCommand : ICommand
{
    public int index { get => _index; }
    public int value { get => _value; }

    private int _index;
    private int _value;

    public ReadIndexCommand(int index, int value)
    {
        _index = index;
        _value = value;
    }
}
