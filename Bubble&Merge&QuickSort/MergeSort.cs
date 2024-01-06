namespace Bubble_Merge_QuickSort;

public class MergeSort
{
    public static int[] Sort(int[] array)
    {
        var temporaryArray = new int[array.Length];
        Sort(array, temporaryArray, 0, array.Length - 1);
        return array;
    }

    private static void Sort(int[] array, int[] temporaryArray, int start, int end)
    {
        if (start == end) return;
        var middle = (start + end) / 2;
        Sort(array, temporaryArray, start, middle);
        Sort(array, temporaryArray, middle + 1, end);
        MergeArrays(array, temporaryArray, start, middle, end);
    }

    private static void MergeArrays(int[] array, int[] temporaryArray, int start, int middle, int end)
    {
        var leftPointer = start;
        var rightPointer = middle + 1;
        var length = end - start + 1;
        for (var i = 0; i < length; i++)
        {
            if (rightPointer > end ||
                (leftPointer <= middle && array[leftPointer] < array[rightPointer]))
            {
                temporaryArray[i] = array[leftPointer];
                leftPointer++;
            }
            else
            {
                temporaryArray[i] = array[rightPointer];
                rightPointer++;
            }
        }

        for (var i = 0; i < length; i++)
            array[start + i] = temporaryArray[i];
        
    }
}