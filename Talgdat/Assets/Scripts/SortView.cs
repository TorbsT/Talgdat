using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortView
{
    private IntList _list;
    private ProblemConfig _config;

    private Queue<Bar> _unmarkQueue;
    private List<Bar> _bars;
    private List<int> _startState;
    private List<ICommand> _commands;
    private float _lastFrameTime;
    private float _uiDelay;
    private int _replayIndex;
    private int _markedCount;
    private bool _started;

    public SortView(IntList list, ProblemConfig config)
    {
        _config = config;
        _list = list;
        _startState = list.GetInputCopy();
        _commands = list.CopyCommands();
        _uiDelay = _config.VisualSortTime / _commands.Count;
}
    public void Destroy()
    {
        while (_unmarkQueue.Count > 0) _unmarkQueue.Dequeue().Unmark();  // Maybe inefficient
        foreach (Bar bar in _bars)
        {
            BarPool.Instance.Enpool(bar);
        }
    }
    public void Start()
    {
        if (_started) Destroy();
        _started = true;
        _replayIndex = 0;
        _markedCount = 0;
        _bars = new List<Bar>();
        _unmarkQueue = new Queue<Bar>();

        for (int i = 0; i < _startState.Count; i++)
        {
            int value = _startState[i];
            Bar bar = BarPool.Instance.Depool();
            bar.index = i;
            bar.value = value;
            _bars.Add(bar);
        }
        _lastFrameTime = Time.time;
    }
    public void Update()
    {
        int counter = 0;
        float timeSinceLastFrame = Time.time - _lastFrameTime;
        if (timeSinceLastFrame < _uiDelay) return;
        while (timeSinceLastFrame >= _uiDelay && _replayIndex < _commands.Count)
        {
            timeSinceLastFrame -= _uiDelay;
            ShowScreen();
            counter++;
        }
        _lastFrameTime = Time.time;
    }
    private void ShowScreen()
    {
        if (_replayIndex >= _commands.Count) return;
        ICommand command = _commands[_replayIndex];
        if (command is SetIndexToValueCommand setCommand)
        {
            int barIndex = setCommand.index;
            int barValue = setCommand.value;

            Bar bar = _bars[barIndex];
            bar.value = barValue;
            Mark(barIndex, "write");
        }
        else if (command is SwapCommand swapCommand)
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
        }
        else if (command is ReadIndexCommand readCommand)
        {
            int index = readCommand.index;
            float relative = (float)readCommand.value / (_config.Max - _config.Min);
            float pitch = relative + 0.5f;//(relative + 0.5f)*5f;
            Mark(index, "read");
            PlaySound(index, pitch);
        }

        _replayIndex++;
        //if (_replayIndex >= commands.Count) _replayIndex = 0;
    }
    private void Mark(int index, string tag)
    {
        Bar bar = _bars[index];
        if (bar.ActiveWrites == 0) _markedCount++;
        bar.Mark(tag);
        _unmarkQueue.Enqueue(bar);
        if (_markedCount > _config.UnmarkQueueSize)
        {
            Bar b = _unmarkQueue.Dequeue();
            b.Unmark();
            if (bar.ActiveWrites == 0) _markedCount--;
        }
    }
    private void PlaySound(int index, float pitch)
    {
        //Bar bar = _bars[index];
        //bar.AudioSource.pitch = pitch;
        //bar.AudioSource.Play();
        AudioSource src = Controller.Instance.AudioSource;
        src.pitch = pitch;
        if (!src.isPlaying) src.Play();
        //Controller.Instance.AudioSource.Play();
    }
}
