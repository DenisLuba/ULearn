namespace Bubble_Merge_QuickSort;

public static class QuickSort
{
    public static int[] Sort(int[] array)
    {
        Sort(array, 0, array.Length - 1);
        return array;
    }

    private static void Sort(int[] array, int start, int end)
    {
        if (start == end) return;

        var pivot = array[end];
        var baseIndex = start;
        for (var i = start; i < end; i++)
        {
            if (array[i] > pivot) continue;
            array.Switch(i, baseIndex);
            baseIndex++;
        }
        array.Switch(baseIndex, end);
        if (baseIndex > start) Sort(array, start, baseIndex - 1);
        if (baseIndex < end) Sort(array, baseIndex + 1, end);
    }

    private static void Switch(this int[] array, int index1, int index2)
    {
        (array[index1], array[index2]) = (array[index2], array[index1]);
    }
}