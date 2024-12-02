using System.Text.RegularExpressions;

namespace AdventOfCode2024.Week1;

public static partial class Week1
{
    public static int GetTotalDistance(string input)
    {
        var pairs = FindPairs(input);
        var distances = pairs.Select(GetPairDifference);
        return distances.Sum();
    }

    private static IEnumerable<(int First, int Second)> FindPairs(string input)
    {
        var group1 = FirstHalf().Matches(input).Select(match => int.Parse(match.Value)).OrderBy(value => value);
        var group2 = SecondHalf().Matches(input).Select(match => int.Parse(match.Value)).OrderBy(value => value);
        return group1.Zip(group2);
    }

    private static int GetPairDifference((int First, int Second) input)
    {
        return Math.Abs(input.First - input.Second);
    }

    [GeneratedRegex("([0-9]+) ")]
    private static partial Regex FirstHalf();

    [GeneratedRegex(" ([0-9]+)")]
    private static partial Regex SecondHalf();
}