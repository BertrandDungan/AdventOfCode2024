namespace AdventOfCode2024.Day2;

public static class Day2
{
    public static int GetSafeReports(string input)
    {
        var reports = GetReportLevels(input);
        var safeReports = reports.Where(ReportIsCompletelySafe);
        return safeReports.Count();
    }

    public static int GetSafeReportsWithOneMistake(string input)
    {
        var reports = GetReportLevels(input);
        var safeReports = reports.Where(ReportIsTolerablySafe);
        return safeReports.Count();
    }

    private static IEnumerable<IEnumerable<int>> GetReportLevels(string reports)
    {
        return reports.Split('\n').Select(report => report.Split(' ').Select(int.Parse));
    }

    private static bool ReportIsCompletelySafe(IEnumerable<int> report)
    {
        var comparisonLevel = report.First();
        var levelSign = Math.Sign(comparisonLevel - report.ElementAt(1));

        foreach (var level in report.Skip(1))
        {
            var levelDifference = Math.Abs(comparisonLevel - level);
            var levelSignDiff = Math.Sign(comparisonLevel - level);
            if (levelDifference > 3 || levelDifference == 0 || levelSign != levelSignDiff)
            {
                return false;
            }

            comparisonLevel = level;
        }

        return true;
    }

    private static bool ReportIsTolerablySafe(IEnumerable<int> report)
    {
        var comparisonLevel = report.First();
        var levelSign = Math.Sign(comparisonLevel - report.ElementAt(1));

        foreach (var level in report.Skip(1))
        {
            var levelDifference = Math.Abs(comparisonLevel - level);
            var levelSignDiff = Math.Sign(comparisonLevel - level);
            if (levelDifference > 3 || levelDifference == 0 || levelSign != levelSignDiff)
            {
                var alternativePermutations = GetReportPermutations(report);
                return alternativePermutations.Any(ReportIsCompletelySafe);
            }

            comparisonLevel = level;
        }

        return true;
    }

    private static IEnumerable<IEnumerable<int>> GetReportPermutations(IEnumerable<int> report)
    {
        var permutations = new List<IEnumerable<int>>();
        for (var currentIndex = 0; currentIndex < report.Count(); currentIndex++)
        {
            permutations.Add(report.Where((_, comparisonIndex) => comparisonIndex != currentIndex).ToList());
        }

        return permutations;
    }
}