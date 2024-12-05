using AdventOfCode2024.Helpers;
using AdventOfCode2024.Day3;

var input = InputParsing.LoadTextResource("Day3\\Input.txt");
var part1Result = Day3.GetMultiplicationResult(input);

Console.WriteLine($"Part 1: {part1Result}");