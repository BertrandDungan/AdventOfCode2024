using AdventOfCode2024.Helpers;
using AdventOfCode2024.Day1;

var input = InputParsing.LoadTextResource("Day1\\Input.txt");
var part1Result = Day1.GetTotalDistance(input);
var part2Result = Day1.GetSimilarityScore(input);

Console.WriteLine($"Part 1: {part1Result}");
Console.WriteLine($"Part 2: {part2Result}");