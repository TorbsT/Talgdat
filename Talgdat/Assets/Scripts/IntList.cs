
using System.Collections.Generic;
using System;

public class IntList
{
    public List<ICommand> commands { get => _commands; }
    public int arrayAccesses { get => _arrayAccesses; }
    public int swaps { get => _swaps; }
    public int this[int index]
    {
        get => get(index);
        set { set(index, value); }
    }
    public int Count { get { if (_inputLocked) return _output.Count; else return _input.Count; } }

    private List<int> _input;
    private List<int> _output;
    private List<ICommand> _commands;
    private int _arrayAccesses;
    private int _swaps;
    private bool _inputLocked;

    public IntList()
    {
        _input = new List<int>();
        _commands = new List<ICommand>();
    }
    public void Add(int n)
    {
        if (_inputLocked) _output.Add(n);
        else _input.Add(n);
    } 
    public void Swap(int a, int b)
    {
        if (OutOfRange(a) || OutOfRange(b)) throw new IndexOutOfRangeException("Swapping Indexes " + a + " & " + b + ", Count was " + Count);
        _swaps++;
        int aValue = _output[a];
        int bValue = _output[b];
        _output[a] = bValue;
        _output[b] = aValue;
        _commands.Add(new SwapCommand(a, aValue, b, bValue));
    }
    public void LockInput()
    {
        if (_inputLocked) throw new InvalidOperationException("Input already locked");
        _output = GetCopy(false);
        _inputLocked = true;
    }
    public List<ICommand> CopyCommands()
    {
        if (!_inputLocked) throw new InvalidOperationException("Can't get commands, input isn't locked");
        List<ICommand> result = new List<ICommand>();
        foreach (ICommand c in _commands)
        {
            result.Add(c);
        }
        return result;
    }
    public List<int> GetInputCopy() => GetCopy(false);
    public List<int> GetOutputCopy() => GetCopy(true);
    public List<int> GetCopy(bool getOutput)
    {
        List<int> result = new List<int>();
        foreach (int i in Get(getOutput))
        {
            result.Add(i);
        }
        return result;
    }
    private List<int> Get(bool getOutput)
    {
        if (getOutput && !_inputLocked) throw new InvalidOperationException("Can't get output when input isn't locked");
        if (getOutput) return _output;
        return _input;
    }
    private int get(int index)
    {
        if (OutOfRange(index)) throw new IndexOutOfRangeException("Getting Index was " + index + ", Count was " + Count);
        _arrayAccesses++;
        int value = _output[index];
        _commands.Add(new ReadIndexCommand(index, value));
        return value;
    }
    private void set(int index, int value)
    {
        if (OutOfRange(index)) throw new IndexOutOfRangeException("Setting Index was " + index + ", Count was " + Count);
        _arrayAccesses++;
        _output[index] = value;
        _commands.Add(new SetIndexToValueCommand(index, value));
    }
    private bool OutOfRange(int index) => index < 0 || index >= Count;


    public static IntList GenerateRandom(int min, int max, int count, int seed)
    {
        IntList list = new IntList();
        Random r = new Random(seed);
        for (int i = 0; i < count; i++)
        {
            list._input.Add(r.Next(min, max + 1));
        }
        return list;
    }
    public override string ToString()
    {
        string txt = "[";
        for (int i = 0; i < _output.Count-1; i++)
        {
            txt += _output[i].ToString()+", ";
        }
        txt += _output[Count-1].ToString()+"]";
        if (_arrayAccesses > 0 || _swaps > 0)
        {
            txt += " with " + _arrayAccesses + " accesses and " + _swaps + " swaps";
        }
        return txt;
    }
}
