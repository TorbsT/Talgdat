using System;

public class StringElement : ComparableElement
{
    public char this[int index] { get { if (index < 0 || index >= Length) throw new InvalidOperationException(this + " has no char at index " + index); return text[index]; } }
    public int Length { get => text.Length; }

    private string text;

    public StringElement(string text)
    {
        this.text = text ?? throw new ArgumentException("Tried making StringElement with null text");
    }
}
