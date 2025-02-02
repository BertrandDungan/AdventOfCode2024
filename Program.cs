using AdventOfCode2024.Helpers;
using AdventOfCode2024.Day4;

var input = InputParsing.LoadTextResource("Day4\\Input.txt");
var part1Result = Day4.ChristmasCount(input);

Console.WriteLine($"Part 1: {part1Result}");