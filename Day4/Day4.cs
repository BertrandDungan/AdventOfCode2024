namespace AdventOfCode2024.Day4;

public static class Day4
{
    private const int CheckDistance = 3;

    public static int ChristmasCount(string input)
    {
        var wordSearch = input.Split('\n', StringSplitOptions.TrimEntries).Select(line => line.ToCharArray()).ToArray();
        var lineIndexLength = wordSearch[0].Length;

        var sum = 0;

        for (var currY = 0; currY < wordSearch.Length; currY++)
        {
            for (var currX = 0; currX < lineIndexLength; currX++)
            {
                sum += CheckXmas(wordSearch, currX, currY, lineIndexLength);
            }
        }

        return sum;
    }

    private static int CheckXmas(char[][] search, int currX, int currY, int lineIndexLength)
    {
        if (search[currY][currX] != 'X') return 0;
        var validDirections = new[]
        {
            CheckN(search, currX, currY),
            CheckNe(search, currX, currY, lineIndexLength),
            CheckE(search, currX, currY, lineIndexLength),
            CheckSe(search, currX, currY, lineIndexLength),
            CheckS(search, currX, currY),
            CheckSw(search, currX, currY),
            CheckW(search, currX, currY),
            CheckNw(search, currX, currY)
        };
        return validDirections.Sum();
    }

    private static int CheckN(char[][] search, int currX, int currY)
    {
        if (currY - CheckDistance >= 0 &&
            search[currY - 1][currX] == 'M' &&
            search[currY - 2][currX] == 'A' &&
            search[currY - 3][currX] == 'S')
        {
            return 1;
        }

        return 0;
    }

    private static int CheckNe(char[][] input, int currX, int currY, int lineIndexLength)
    {
        if (currY - CheckDistance >= 0 &&
            currX + CheckDistance < lineIndexLength &&
            input[currY - 1][currX + 1] == 'M' &&
            input[currY - 2][currX + 2] == 'A' &&
            input[currY - 3][currX + 3] == 'S')
        {
            return 1;
        }

        return 0;
    }

    private static int CheckE(char[][] input, int currX, int currY, int lineIndexLength)
    {
        if (currX + CheckDistance < lineIndexLength &&
            input[currY][currX + 1] == 'M' &&
            input[currY][currX + 2] == 'A' &&
            input[currY][currX + 3] == 'S')
        {
            return 1;
        }

        return 0;
    }

    private static int CheckSe(char[][] input, int currX, int currY, int lineIndexLength)
    {
        if (currY + CheckDistance < input.Length - 1 &&
            currX + CheckDistance < lineIndexLength &&
            input[currY + 1][currX + 1] == 'M' &&
            input[currY + 2][currX + 2] == 'A' &&
            input[currY + 3][currX + 3] == 'S')
        {
            return 1;
        }

        return 0;
    }

    private static int CheckS(char[][] input, int currX, int currY)
    {
        if (currY + CheckDistance < input.Length - 1 &&
            input[currY + 1][currX] == 'M' &&
            input[currY + 2][currX] == 'A' &&
            input[currY + 3][currX] == 'S')
        {
            return 1;
        }

        return 0;
    }

    private static int CheckSw(char[][] input, int currX, int currY)
    {
        if (currY + CheckDistance < input.Length - 1 &&
            currX - CheckDistance >= 0 &&
            input[currY + 1][currX - 1] == 'M' &&
            input[currY + 2][currX - 2] == 'A' &&
            input[currY + 3][currX - 3] == 'S')
        {
            return 1;
        }

        return 0;
    }

    private static int CheckW(char[][] input, int currX, int currY)
    {
        if (currX - CheckDistance >= 0 &&
            input[currY][currX - 1] == 'M' &&
            input[currY][currX - 2] == 'A' &&
            input[currY][currX - 3] == 'S')
        {
            return 1;
        }

        return 0;
    }

    private static int CheckNw(char[][] input, int currX, int currY)
    {
        if (currY - CheckDistance >= 0 &&
            currX - CheckDistance >= 0 &&
            input[currY - 1][currX - 1] == 'M' &&
            input[currY - 2][currX - 2] == 'A' &&
            input[currY - 3][currX - 3] == 'S')
        {
            return 1;
        }

        return 0;
    }
}