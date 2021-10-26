using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ReadEdgeCommand : ICommand
{
    public int id { get => _id; }
    public bool failed { get => _fail; }

    public ReadEdgeCommand(int id, bool fail = false)
    {
        _id = id;
        _fail = fail;
    }
    private int _id;
    private bool _fail;
}
