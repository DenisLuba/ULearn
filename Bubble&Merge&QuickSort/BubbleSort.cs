namespace Bubble_Merge_QuickSort;

public class BubbleSort
{
    public static int[] Sort(int[] array)
    {
        for (var i = array.Length - 1; i > 0; i--)
        {
            for (var j = 1; j <= i; j++)
            {
                if (array[j - 1] > array[j])
                    (array[j - 1], array[j]) = (array[j], array[j - 1]);
            }
        }

        return array;
    }
}