using AdventOfCode2024.Helpers;
using AdventOfCode2024.Week1;

var input = InputParsing.LoadTextResource("Week1\\Input.txt");
var part1Result = Week1.GetTotalDistance(input);
var part2Result = Week1.GetSimilarityScore(input);

Console.WriteLine($"Part 1: {part1Result}");
Console.WriteLine($"Part 2: {part2Result}");