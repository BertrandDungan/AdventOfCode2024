using AdventOfCode2024.Helpers;
using AdventOfCode2024.Week1;

var input = InputParsing.LoadTextResource("Week1\\Input.txt");
var result = Week1.GetTotalDistance(input);
Console.WriteLine(result);