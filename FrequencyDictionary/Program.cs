using NUnit.Framework;
using System.Text.RegularExpressions;

namespace FrequencyDictionary;

public class Program
{
    public static void Main()
    {
        Assert.That(
            GetMostFrequentWords("A box of biscuits, a box of mixed biscuits, and a biscuit mixer.", 2)
            , Is.EqualTo(new[] {("a", 3), ("biscuits", 2)}).AsCollection);

        Assert.That(
            GetMostFrequentWords("", 100), Is.EqualTo(new (string, int) [] { }).AsCollection);

        Assert.That(
            GetMostFrequentWords("Each Easter Eddie eats eighty Easter eggs.", 3)
            , Is.EqualTo(new[] { ("easter", 2), ("each", 1), ("eats", 1) }).AsCollection);
    }

    public static (string, int)[] GetMostFrequentWords(string text, int count)
    {
        return Regex.Split(text, @"\W+")
            .Where(word => word != "")
            .Select(word => word.ToLower())
            .GroupBy(word => word)
            .Select(group => ValueTuple.Create(group.Key, group.Count()))
            .OrderByDescending(group => group.Item2)
            .ThenBy(group => group.Item1)
            .Take(count)
            .ToArray();
    }
}