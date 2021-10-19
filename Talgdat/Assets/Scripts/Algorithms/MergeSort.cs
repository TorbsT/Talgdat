
using System.Collections.Generic;
public class MergeSort : ISortAlgorithm
{
    public const string Name = "MergeSort";
    private IntList list;
    public void Sort(IntList list)
    {
        this.list = list;
        MSort(0, list.Count - 1);
    }
    private void MSort(int low, int high)
    {
        if (low >= high) return;
        int split = (low + high) / 2;
        MSort(low, split);
        MSort(split + 1, high);
        Merge(low, split + 1, high);
    }
    private void Merge(int llow, int rlow, int rhigh)
    {
        // Supposes llow to (rlow-1) is sorted
        // Supposes rlow to rhigh is sorted

        List<int> temp = new List<int>();
        // Put all elements between llow to rhigh into temp, in sorted order

        int l = llow;
        int r = rlow;
        while (l < rlow && r <= rhigh)
        {
            int lowest;
            if (list[r] < list[l]) lowest = r;
            else lowest = l;

            temp.Add(list[lowest]);
            if (lowest == r) r++;
            else l++;
        }
        // Only one if the subarrays remain
        while (l < rlow)
        {
            temp.Add(list[l]);
            l++;
        }
        while (r < rhigh)
        {
            temp.Add(list[r]);
            r++;
        }
        // temp is now sorted, put pack into list

        for (int i = 0; i < temp.Count; i++)
        {
            list[llow + i] = temp[i];
        }

    }
}
