using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day3;

public static class Day3
{
    public static int GetMultiplicationResult(string input)
    {
        var multiplicationPairs = GetMultiplicationPairs(input);
        var multiplicationResult = multiplicationPairs.Select(
            pair => pair.Item1 * pair.Item2
        );
        return multiplicationResult.Sum();
    }

    private static IEnumerable<(int, int)> GetMultiplicationPairs(string input)
    {
        return MultiplicationFinder.MultiplicationRegex().Matches(input).Select(
            match => (
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value)
            )
        );
    }
}

internal static partial class MultiplicationFinder
{
    [GeneratedRegex(@"mul\(([0-9]{1,3}),([0-9]{1,3})\)")]
    public static partial Regex MultiplicationRegex();
}