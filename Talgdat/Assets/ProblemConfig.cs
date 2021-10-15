using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProblemConfig
{
    public static ProblemConfig Instance;

    public string Algorithm = "undefined";
    public int Seed = 1234;
    public int Min = 1;
    public int Max = 100;
    public int Count = 8;

    public float VisualSortTime = 10f;
    public int UnmarkQueueSize = 1;

    public ProblemConfig()
    {
        Instance = this;
    }
    public override string ToString() =>
        Algorithm + " Seed" + Seed + " Min" + Min + " Max" + Max + " Count" + Count + " Time" + VisualSortTime + " Mark" + UnmarkQueueSize;
}
