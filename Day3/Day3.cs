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

    public static int GetInstructionResult(string input)
    {
        var instructions = GetInstructions(input);

        var shouldPerformInstruction = true;
        var result = 0;
        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case "do()":
                    shouldPerformInstruction = true;
                    break;
                case "don't()":
                    shouldPerformInstruction = false;
                    break;
                default:
                {
                    if (shouldPerformInstruction)
                    {
                        var splitNumbers = instruction.Split(",").Select(int.Parse).ToArray();
                        result += splitNumbers[0] * splitNumbers[1];
                    }

                    break;
                }
            }
        }

        return result;
    }

    private static IEnumerable<(int, int)> GetMultiplicationPairs(string input)
    {
        return MultiplicationFinder.NumberMultRegex().Matches(input).Select(
            match => (
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value)
            )
        );
    }


    private static IEnumerable<string> GetInstructions(string input)
    {
        return MultiplicationFinder.InstructionMultRegex().Matches(input).Select(
            match => match.Groups["result"].Value
        );
    }
}

internal static partial class MultiplicationFinder
{
    [GeneratedRegex(@"mul\(([0-9]{1,3}),([0-9]{1,3})\)")]
    public static partial Regex NumberMultRegex();

    [GeneratedRegex(
        @"mul\((?'result'[0-9]{1,3},[0-9]{1,3})\)|(?'result'do\(\))|(?'result'don\'t\(\))"
    )]
    public static partial Regex InstructionMultRegex();
}