namespace AdventOfCode.CSharp;

public class Day2
{
    private const string RockOpponent = "A";
    private const string PaperOpponent = "B";
    private const string ScissorsOpponent = "C";

    private const string RockResponse = "X";
    private const string PaperResponse = "Y";
    private const string ScissorsResponse = "Z";

    private const string NeedToLose = "X";
    private const string NeedToDraw = "Y";
    private const string NeedToWin = "Z";
    private const int RockPoints = 1;
    private const int PaperPoints = 2;
    private const int ScissorsPoints = 3;

    public static async Task RunAsync()
    {
        var path = "InputFiles/Day2.txt";
        var input = await File.ReadAllLinesAsync(path);

        int points = 0;
        int pointsSecondStrategy = 0;

        foreach (var line in input)
        {
            var firstAndSecondColumn = line.Split(' ');
            var opponentsShape = firstAndSecondColumn[0];
            var responseShape = firstAndSecondColumn[1];

            points += AddPoints(opponentsShape, responseShape);
            pointsSecondStrategy += AddPoints(opponentsShape, responseShape, true);
        }

        Console.WriteLine("Day 2 results:");
        Console.WriteLine($"The points received by following the strategy is: {points}");
        Console.WriteLine($"The points received by following the second strategy is: {pointsSecondStrategy}");

        Console.WriteLine("--------------------------------------");
    }

    private static int AddPoints(string opponentsShape, string responseShape, bool secondStrategy = false)
    {
        if (opponentsShape.Equals(RockOpponent))
        {
            return DeterminePointsForRock(responseShape, secondStrategy);
        }
        if (opponentsShape.Equals(PaperOpponent))
        {
            return DeterminePointsForPaper(responseShape, secondStrategy);
        }
        if (opponentsShape.Equals(ScissorsOpponent))
        {
            return DeterminePointsForScissors(responseShape, secondStrategy);
        }

        throw new ArgumentOutOfRangeException($"Could not determine opponents shape {opponentsShape}");
    }

    private static int AddPointsForResponse(string responseShape)
    {
        switch (responseShape)
        {
            case RockResponse:
                return 1;
            case PaperResponse:
                return 2;
            case ScissorsResponse:
                return 3;
            default:
                return 0;
        }
    }

    private static int DeterminePointsForRock(string responseShape, bool secondStrategy = false)
    {
        if (!secondStrategy)
        {
            switch (responseShape)
            {
                case RockResponse: // This is a draw
                    return 3 + RockPoints;
                case PaperResponse: // This is a win
                    return 6 + PaperPoints;
                case ScissorsResponse: // This is a loss
                    return 0 + ScissorsPoints;
                default:
                    return 0;
            }
        }

        switch (responseShape)
        {
            case NeedToLose: // This is a draw
                return 0 + ScissorsPoints;
            case PaperResponse: // This is a win
                return 3 + RockPoints;
            case ScissorsResponse: // This is a loss
                return 6 + PaperPoints;
            default:
                return 0;
        }
    }

    private static int DeterminePointsForPaper(string responseShape, bool secondStrategy = false)
    {
        if (!secondStrategy)
        {
            switch (responseShape)
            {
                case RockResponse: // This is a loss
                    return 0 + RockPoints;
                case PaperResponse: // This is a draw
                    return 3 + PaperPoints;
                case ScissorsResponse: // This is a win
                    return 6 + ScissorsPoints;
                default:
                    return 0;
            }
        }

        switch (responseShape)
        {
            case NeedToLose: // This is a loss
                return 0 + RockPoints;
            case NeedToDraw: // This is a draw
                return 3 + PaperPoints;
            case NeedToWin: // This is a win
                return 6 + ScissorsPoints;
            default:
                return 0;
        }
    }

    private static int DeterminePointsForScissors(string responseShape, bool secondStrategy = false)
    {
        if (!secondStrategy)
        {
            switch (responseShape)
            {
                case RockResponse: // This is a win
                    return 6 + RockPoints;
                case PaperResponse: // This is a loss
                    return 0 + PaperPoints;
                case ScissorsResponse: // This is a draw
                    return 3 + ScissorsPoints;
                default:
                    return 0;
            }
        }

        switch (responseShape)
        {
            case NeedToLose: // This is a win
                return 0 + PaperPoints;
            case NeedToDraw: // This is a loss
                return 3 + ScissorsPoints;
            case NeedToWin: // This is a draw
                return 6 + RockPoints;
            default:
                return 0;
        }
    }
}