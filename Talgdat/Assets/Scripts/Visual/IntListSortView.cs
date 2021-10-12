using System.Collections.Generic;
using UnityEngine;

public class IntListSortView
{
    private List<Bar> _bars = new List<Bar>();
    [SerializeField] private int _replayIndex;
    private float _lastDisplayTime;
    [SerializeField] private float _timeSinceLastDisplay;
    private IntList _list;
    public IntListSortView(IntList list)
    {
        _list = list;
        if (!list.InputLocked) Debug.LogError("Can't begin a view of an non-inputlocked list");
        for (int i = 0; i < list.Count; i++)
        {
            IntElement value = list[i];
            Bar bar = GameObject.Instantiate(Talgdat.BarPrefab).GetComponent<Bar>();
            bar.index = i;
            bar.value = 0;
            _bars.Add(bar);
        }
    }
    public void Start()
    {

    }
    public void Update()
    {

    }
}
