using System.Text.RegularExpressions;

namespace AdventOfCode2024.Week1;

public static class Week1
{
    public static int GetTotalDistance(string input)
    {
        var pairs = FindPairs(input);
        var distances = pairs.Select(GetPairDifference);
        return distances.Sum();
    }

    private static IEnumerable<(int First, int Second)> FindPairs(string input)
    {
        var group1 = Regex.Matches(input, Group1Pattern).Select(match => int.Parse(match.Value)).OrderBy(value => value);
        var group2 = Regex.Matches(input, Group2Pattern).Select(match => int.Parse(match.Value)).OrderBy(value => value);
        return group1.Zip(group2);
    }

    private const string Group1Pattern = "([0-9]+) ";
    private const string Group2Pattern = " ([0-9]+)";

    private static int GetPairDifference((int First, int Second) input)
    {
        return Math.Abs(input.First - input.Second);
    }
}