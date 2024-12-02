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
        var group1 = FirstHalf().Matches(input).Select(match => int.Parse(match.Value)).OrderDescending();
        var group2 = SecondHalf().Matches(input).Select(match => int.Parse(match.Value)).OrderDescending();
        return group1.Zip(group2);
    }

    private static int GetPairDifference((int First, int Second) input)
    {
        return Math.Abs(input.First - input.Second);
    }

    public static int GetSimilarityScore(string input)
    {
        var group1 = FirstHalf().Matches(input).Select(match => int.Parse(match.Value)).Distinct();
        var group2 = SecondHalf().Matches(input).Select(match => int.Parse(match.Value));

        var similarityTracker = group1.ToDictionary(value => value, _ => 0);

        foreach (var number in group2)
        {
            if (similarityTracker.ContainsKey(number))
            {
                similarityTracker[number] += 1;
            }
        }

        var similarityScoreSum = similarityTracker.Select(pair => pair.Key * pair.Value).Sum();

        return similarityScoreSum;
    }

    [GeneratedRegex("([0-9]+) ")]
    private static partial Regex FirstHalf();

    [GeneratedRegex(" ([0-9]+)")]
    private static partial Regex SecondHalf();
}