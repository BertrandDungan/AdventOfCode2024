namespace AdventOfCode2024.Helpers;

public static class InputParsing
{
    public static string LoadTextResource(string filename)
    {
        var filePath = $"{Directory.GetCurrentDirectory()}\\{filename}";
        return File.ReadAllText (filePath);
    }
}