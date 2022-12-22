namespace AdventOfCode.CSharp;

public class Day1
{
    public static async Task RunAsync()
    {
        var path = "Day1.txt";
        var input = await File.ReadAllLinesAsync(path);

        var elfsCalories = new List<int>();

        int caloriesForOneElf = 0;

        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                elfsCalories.Add(caloriesForOneElf);
                caloriesForOneElf = 0;
                continue;
            }

            caloriesForOneElf += int.Parse(line);
        }

        Console.WriteLine($"The maximum amount of calories is: {elfsCalories.Max()}");

        var orderedByCalories = elfsCalories.OrderByDescending(x => x);

        var caloriesOfTopThreeElfs = orderedByCalories.Take(3).Sum();

        System.Console.WriteLine($"The calories of the top three elfs is: {caloriesOfTopThreeElfs}");
    }
}