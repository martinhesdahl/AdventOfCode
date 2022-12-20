var path = "CaloriesInput.txt";
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

System.Console.WriteLine(elfsCalories.Max());
Console.ReadLine();