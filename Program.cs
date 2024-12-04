using AdventOfCode2024.Helpers;
using AdventOfCode2024.Day2;

var input = InputParsing.LoadTextResource("Day2\\Input.txt");
var part1Result = Day2.GetSafeReports(input);

Console.WriteLine($"Part 1: {part1Result}");