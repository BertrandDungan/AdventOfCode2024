using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day1;

public static partial class Day1
{
    public static int GetTotalDistance(string input)
    {
        var pairs = FindPairs(input);
        var distances = pairs.Select(GetPairDifference);
        return distances.Sum();
    }
    
    public static int GetSimilarityScore(string input)
    {
        var group2 = GetSecondHalf(input);

        var similarityTracker = GetFirstHalf(input).Distinct().ToDictionary(value => value, _ => 0);

        foreach (var number in group2)
        {
            if (similarityTracker.ContainsKey(number))
            {
                similarityTracker[number] += 1;
            }
        }

        return similarityTracker.Select(pair => pair.Key * pair.Value).Sum();
    }

    private static IEnumerable<(int First, int Second)> FindPairs(string input)
    {
        var group1 = GetFirstHalf(input).OrderDescending();
        var group2 = GetSecondHalf(input).OrderDescending();
        return group1.Zip(group2);
    }

    private static int GetPairDifference((int First, int Second) input)
    {
        return Math.Abs(input.First - input.Second);
    }

    private static IEnumerable<int> GetFirstHalf(string input)
    {
        return FirstHalf().Matches(input).Select(match => int.Parse(match.Value));
    }

    private static IEnumerable<int> GetSecondHalf(string input)
    {
        return SecondHalf().Matches(input).Select(match => int.Parse(match.Value));
    }

    [GeneratedRegex("([0-9]+) ")]
    private static partial Regex FirstHalf();

    [GeneratedRegex(" ([0-9]+)")]
    private static partial Regex SecondHalf();
}