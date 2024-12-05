using AdventOfCode2024.Helpers;
using AdventOfCode2024.Day2;

var input = InputParsing.LoadTextResource("Day2\\Input.txt");
var part1Result = Day2.GetSafeReports(input);
var part2Result = Day2.GetSafeReportsWithOneMistake(input);

Console.WriteLine($"Part 1: {part1Result}");
Console.WriteLine($"Part 2: {part2Result}");