using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    private Core _core;
    private List<Bar> _bars;

    public Controller()
    {
        _core = new Core();


        _bars = new List<Bar>();
        for (int i = 0; i < _core.list.Count; i++)
        {
            int value = _core.list[i];
            Bar bar = GameObject.Instantiate(Talgdat.BarPrefab).GetComponent<Bar>();
            bar.pos = i;
            bar.value = value;
            _bars.Add(bar);
        }

    }
    public void Start()
    {
        
    }
    public void Update()
    {

    }
    public void FixedUpdate()
    {

    }
}
