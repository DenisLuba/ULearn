namespace Bubble_Merge_QuickSort;

internal class Program
{
    private static readonly Random Random = new Random();

    public static void Main()
    {
        var array = GenerateArray(10);
        foreach (var i in array)
            Console.WriteLine(i);

        var copyArray = (int[]) array.Clone();
        Console.WriteLine("Bubble Sort");

        foreach (var i in BubbleSort.Sort(copyArray))
            Console.WriteLine(i);

        copyArray = (int[]) array.Clone();
        Console.WriteLine("Merge Sort");

        foreach (var i in MergeSort.Sort(array))
            Console.WriteLine(i);
        
    }

    private static int[] GenerateArray(int length)
    {
        var array = new int[length];
        for (var i = 0; i < length; i++)
            array[i] = Random.Next(100);

        return array;
    }
}