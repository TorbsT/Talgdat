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
    private Queue<Bar> _unmarkQueue = new Queue<Bar>();
    private int _unmarkQueueSize = 10;

    public Controller()
    {
        _core = new Core();

        _core.Restart();
        _bars = new List<Bar>();
        for (int i = 0; i < _core.list.Count; i++)
        {
            int value = _core.list[i];
            Bar bar = GameObject.Instantiate(Talgdat.BarPrefab).GetComponent<Bar>();
            bar.index = i;
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
            List<Command> commands = _core.list.commands;
            if (_replayIndex >= commands.Count) return;
            Command command = commands[_replayIndex];
            if (command is SetIndexToValueCommand setCommand)
            {
                int barIndex = setCommand.index;
                int barValue = setCommand.value;

                Bar bar = _bars[barIndex];
                bar.value = barValue;
                Mark(barIndex, "write");
            } else if (command is SwapCommand swapCommand)
            {
                int aIndex = swapCommand.aIndex;
                int bIndex = swapCommand.bIndex;
                Bar aBar = _bars[aIndex];
                Bar bBar = _bars[bIndex];

                _bars[aIndex] = bBar;
                bBar.index = aIndex;
                _bars[bIndex] = aBar;
                aBar.index = bIndex;
                Mark(aIndex, "write");
                Mark(bIndex, "write");
            } else if (command is ReadIndexCommand readCommand)
            {
                int index = readCommand.index;
                float pitch = readCommand.value/1080f + 0.5f;
                Mark(index, "read");
                PlaySound(index, pitch);
            }



            _replayIndex++;
            _lastDisplayTime = Time.time;
            //if (_replayIndex >= commands.Count) _replayIndex = 0;
        }
    }
    private void Mark(int index, string tag)
    {
        Bar bar = _bars[index];
        bar.Mark(tag);
        _unmarkQueue.Enqueue(bar);
        if (_unmarkQueue.Count > _unmarkQueueSize)
        {
            Bar b = _unmarkQueue.Dequeue();
            b.Unmark();
        }
    }
    private void PlaySound(int index, float pitch)
    {
        Bar bar = _bars[index];
        bar.AudioSource.pitch = pitch;
        bar.AudioSource.Play();
    }
    public void FixedUpdate()
    {

    }
}
