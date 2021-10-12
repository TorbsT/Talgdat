using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ReadIndexCommand : Command
{
    public int index { get => _index; }

    private int _index;

    public ReadIndexCommand(int index)
    {
        _index = index;
    }
}
