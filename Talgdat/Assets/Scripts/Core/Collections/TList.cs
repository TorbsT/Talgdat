using System.Collections.Generic;
using System;

public class TList<Element> : TCollection<Element>
{
    public bool InputLocked { get => _inputLocked; }
    public List<Command> commands { get => _commands; }
    public int arrayAccesses { get => _arrayAccesses; }
    public int swaps { get => _swaps; }
    public Element this[int index]
    {
        get => get(index, InputLocked);
        set { set(index, value, InputLocked); }
    }
    public int Count { get => _outputElements.Count; }

    private List<Element> _inputElements;
    private List<Element> _outputElements;
    private List<Command> _commands;
    private int _arrayAccesses;
    private int _swaps;
    private bool _inputLocked;

    public TList()
    {
        _inputElements = new List<Element>();
        _commands = new List<Command>();
    }

    public void LockInput()
    {
        if (_inputLocked) throw new InvalidOperationException(this + " is already inputlocked");
        _inputLocked = true;

        // Copy every element over to _outputElements
        _outputElements = new List<Element>();
        foreach (Element element in _inputElements)
        {
            _outputElements.Add(element);
        }
    }
    public void Add(Element element)
    {  // Chooses input or output automatically
        if (_inputLocked) _outputElements.Add(element);
        else _inputElements.Add(element);
    }
    public void Swap(int aIndex, int bIndex)
    {  // Chooses automatically input or output
        if (OutOfRange(aIndex, InputLocked) || OutOfRange(bIndex, InputLocked)) throw new IndexOutOfRangeException("Swapping Indexes " + aIndex + " & " + bIndex + ", Count was " + Count);
        Element aValue = this[aIndex];
        Element bValue = this[bIndex];
        this[aIndex] = bValue;
        this[bIndex] = aValue;
        if (_inputLocked)
        {
            _swaps++;
            _commands.Add(new SwapCommand(aIndex, bIndex));
        }
    }

    public Element get(int index, bool getFromOutput)
    {
        Element element;
        if (getFromOutput)
        {
            if (!_inputLocked) throw new InvalidOperationException(this + " tried getting element @index" + index + " from output, but input is unlocked");
            if (OutOfRange(index, true)) throw new IndexOutOfRangeException("Getting Index was " + index + ", Count was " + Count);
            _arrayAccesses++;
            element = _outputElements[index];
            _commands.Add(new ReadIndexCommand(index));
        }
        else
        {
            if (OutOfRange(index, false)) throw new IndexOutOfRangeException("Getting Index was " + index + ", Count was " + Count);
            element = _inputElements[index];
        }
        return element;
    }
    private void set(int index, Element element, bool setInOutput)
    {
        if (setInOutput)
        {
            if (!_inputLocked) throw new InvalidOperationException(this + " tried setting element @index" + index + " to " + element + " in output, but input is unlocked");
            if (OutOfRange(index, true)) throw new IndexOutOfRangeException("Setting Index was " + index + ", Count was " + Count);
            _outputElements[index] = element;
            _arrayAccesses++;
            _commands.Add(new SetIndexToValueCommand(index, element.StringFormatted()));
        } else
        {
            if (_inputLocked) throw new InvalidOperationException(this + " tried setting element @index" + index + " to " + element + " in input, but input is locked");
            if (OutOfRange(index, false)) throw new IndexOutOfRangeException("Setting Index was " + index + ", Count was " + Count);
            _inputElements[index] = element;
        }
    }
    private bool OutOfRange(int index, bool ofOutput)
    {
        if (index < 0) return true;
        if (index >= GetCount(ofOutput)) return true;
        return false;
    }
    public int GetCount(bool ofOutput)
    {
        if (ofOutput && !_inputLocked) throw new InvalidOperationException(this + "Tried getting count of output, but input is unlocked");
        if (ofOutput) return _outputElements.Count;
        else return _inputElements.Count;
    }

    public TList<Element> Copy()
    {
        TList<Element> l = new TList<Element>();
        foreach (Element e in _outputElements)
        {
            l._outputElements.Add(e);
        }
        return l;
    }
    public override string ToString()
    {
        string txt = "[";
        for (int i = 0; i < _outputElements.Count - 1; i++)
        {
            txt += _outputElements[i].ToString() + ", ";
        }
        txt += _outputElements[Count - 1].ToString() + "]";
        if (_arrayAccesses > 0 || _swaps > 0)
        {
            txt += " with " + _arrayAccesses + " accesses and " + _swaps + " swaps";
        }
        return txt;
    }
}
