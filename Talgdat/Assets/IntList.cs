
using System.Collections.Generic;
using System;

public class IntList
{
    public int arrayAccesses { get => _arrayAccesses; }
    public int swaps { get => _swaps; }
    public int this[int index]
    {
        get => get(index);
        set { set(index, value); }
    }
    public List<int> elements { get => _elements; }
    public int Count { get => _elements.Count; }

    private List<int> _elements;
    private int _arrayAccesses;
    private int _swaps;

    public IntList()
    {
        _elements = new List<int>();
    }
    public void Swap(int a, int b)
    {
        if (OutOfRange(a) || OutOfRange(b)) throw new IndexOutOfRangeException("Swapping Indexes " + a + " & " + b + ", Count was " + Count);
        _swaps++;
        int temp = get(a);
        set(a, get(b));
        set(b, temp);
    }

    private int get(int index)
    {
        if (OutOfRange(index)) throw new IndexOutOfRangeException("Getting Index was " + index + ", Count was " + Count);
        _arrayAccesses++;
        return _elements[index];
    }
    private void set(int index, int value)
    {
        if (OutOfRange(index)) throw new IndexOutOfRangeException("Setting Index was " + index + ", Count was " + Count);
        _arrayAccesses++;
        _elements[index] = value;
    }
    private bool OutOfRange(int index) => index < 0 || index >= Count;


    public static IntList GenerateRandom(int min, int max, int count)
    {
        IntList list = new IntList();
        Random r = new Random(Core.Seed);
        for (int i = 0; i < count; i++)
        {
            list._elements.Add(r.Next(min, max + 1));
        }
        return list;
    }
    public override string ToString()
    {
        string txt = "[";
        for (int i = 0; i < _elements.Count-1; i++)
        {
            txt += _elements[i].ToString()+", ";
        }
        txt += _elements[Count-1].ToString()+"]";
        if (_arrayAccesses > 0 || _swaps > 0)
        {
            txt += " with " + _arrayAccesses + " accesses and " + _swaps + " swaps";
        }
        return txt;
    }
}
