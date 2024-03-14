
string filePath = "input/input.txt";

string[] lines = File.ReadAllLines(filePath);

int distinctLineCounter = 0;

foreach (string line in lines) {
    int distinctCount = line.Split().ToList().Distinct().Count();
    int nonDistinctCount = line.Split().ToList().Count;
    if (distinctCount == nonDistinctCount) 
    {
        distinctLineCounter += 1;
    }
}

Console.WriteLine(distinctLineCounter);