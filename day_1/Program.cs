using FileReader;

// Part 1

// string firstLine = FileReader.FirstLine.Reader().Trim();

// string circularLine = firstLine + firstLine[firstLine.Length - 1];


// int totalSum = 0;

// for (int i = 0; i < circularLine.Length; i++)
// {
//     int currVal;
//     if (circularLine[i] == circularLine[i+1])
//     {
//         int.TryParse(circularLine[i].ToString(), out currVal);
//         totalSum += currVal;
//     }
// }

// Console.WriteLine(totalSum);




// Part 2

string circularLine = FileReader.FirstLine.Reader().Trim();

int totalSum = 0;

int offset = circularLine.Length / 2;

for (int i = 0; i < circularLine.Length; i++)
{
    int currVal;
    if (circularLine[i] == circularLine[(i+offset) % (offset * 2)])
    {
        int.TryParse(circularLine[i].ToString(), out currVal);
        totalSum += currVal;
    }
}

Console.WriteLine(totalSum);