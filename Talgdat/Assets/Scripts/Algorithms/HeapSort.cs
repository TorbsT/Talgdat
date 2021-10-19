

public class HeapSort : ISortAlgorithm
{
    public const string Name = "HeapSort";
    private IntList list;
    public void Sort(IntList list)
    {
        this.list = list;
        // Build max-heap
        int high = list.Count - 1;
        for (int i = high; i >= 0; i--)
        {
            SiftDown(i, high);
        }

        for (int i = high; i > 0; i--)
        {
            list.Swap(0, i);
            if (i > 0) SiftDown(0, i-1);
        }
    }
    private void SiftDown(int current, int high)
    {
        int largest = current;
        int l = current * 2 + 1;
        int r = current * 2 + 2;

        // Find the largest of (current, l, r).
        if (l <= high && list[l] > list[largest]) largest = l;
        if (r <= high && list[r] > list[largest]) largest = r;

        // If downsifting is needed:
        if (largest != current)
        {
            list.Swap(current, largest);
            SiftDown(largest, high);  // Continue sifting down
        }
        
    }
}
