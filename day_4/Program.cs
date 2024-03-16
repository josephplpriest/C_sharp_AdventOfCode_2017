using System;
using MyUtils;



string filePath = "input/input.txt";

string[] lines = File.ReadAllLines(filePath);


/*    Part 1

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
*/

// Part 2
int noValidAnagramCount = 0;

foreach (string line in lines)
{
    List<string> possibleAnagrams = [.. line.Split()];

    for (int i = 0; i < possibleAnagrams.Count - 1; i++)
    {
        for (int j = i + 1; j < possibleAnagrams.Count; j++)
        {
            bool isValidAnagram = AnagramChecker.IsAnagram(possibleAnagrams[i], possibleAnagrams[j]);
            if (isValidAnagram) { goto Found; }
        }
    }
    noValidAnagramCount += 1;
    Found:
        continue;
}
    
Console.WriteLine(noValidAnagramCount);
