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
        var safeReports = reports.Where(
            report => ReportIsCompletelySafe(report) | ReportIsTolerablySafe(report)
        );
        return safeReports.Count();
    }

    private static List<List<int>> GetReportLevels(string reports)
    {
        return reports.Split('\n').Select(
            report => report.Split(' ').Select(int.Parse).ToList()
        ).ToList();
    }

    private static bool ReportIsCompletelySafe(List<int> report)
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

    private static bool ReportIsTolerablySafe(List<int> report)
    {
        var alternativePermutations = GetReportPermutations(report);
        return alternativePermutations.Any(ReportIsCompletelySafe);
    }

    private static List<List<int>> GetReportPermutations(List<int> report)
    {
        return report.Select(
            (_, currentIndex) =>
                report.Where(
                    (_, comparisonIndex) => comparisonIndex != currentIndex
                ).ToList()
        ).ToList();
    }
}