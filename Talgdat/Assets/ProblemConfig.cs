using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProblemConfig
{
    public int Seed = 1234;
    public int Min = 1;
    public int Max = 100;
    public int Count = 8;

    public float visualSortTime = 10f;
    public int UnmarkQueueSize = 1;
}
