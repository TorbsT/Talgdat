using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Controller
{
    private Core _core;
    private List<Bar> _bars;
    [SerializeField] private int _replayIndex;
    private float _lastDisplayTime;
    [SerializeField] private float _timeSinceLastDisplay;

    public Controller()
    {
        _core = new Core();

        _core.Restart();
        _bars = new List<Bar>();
        for (int i = 0; i < _core.list.Count; i++)
        {
            int value = _core.list[i];
            Bar bar = GameObject.Instantiate(Talgdat.BarPrefab).GetComponent<Bar>();
            bar.pos = i;
            bar.value = value;
            _bars.Add(bar);
        }

        _core.Solve();
    }
    public void Update()
    {
        if (Time.time - _lastDisplayTime >= Talgdat.uiDelay)
        {
            _timeSinceLastDisplay = Time.time - _lastDisplayTime;
            List<SetIndexToValueCommand> commands = _core.list.commands;
            if (_replayIndex >= commands.Count) return;
            int barIndex = commands[_replayIndex].index;
            int barValue = commands[_replayIndex].value;

            Bar bar = _bars[barIndex];
            bar.value = barValue;


            _replayIndex++;
            _lastDisplayTime = Time.time;
            //if (_replayIndex >= commands.Count) _replayIndex = 0;
        }
    }
    public void FixedUpdate()
    {

    }
}
