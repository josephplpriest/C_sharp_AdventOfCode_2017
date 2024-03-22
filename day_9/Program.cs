using System.Dynamic;

string inputData = File.ReadAllLines("input/input.txt").First();

List<int> groups = new List<int>();


GarbageCounter.n = 0;

CountGroupsInString(0, inputData, groups);

Console.WriteLine(GarbageCounter.n);



static int CountGroupsInString(int groupCount, string str, List<int> groupsSeen)
{

    Console.WriteLine("Function call starting with: " + str);
    if (str.Length == 0)
    {
        return 0;
    }
    // Add group count to total counter?
    groupsSeen.Add(groupCount);

    // iterate through string
    int currPosition = 0;

    while (currPosition < str.Length)
    {
        if (str[currPosition] == '{')
        {
            currPosition += CountGroupsInString(groupCount + 1, str.Substring(currPosition + 1), groupsSeen);
        }
        else if (str[currPosition] == '<')
        {
            currPosition += GetGarbageTerminationPosition(str.Substring(currPosition+1));
        }
        else if (str[currPosition] == '}')
            return currPosition + 2;
        else currPosition++;
    }
    return currPosition;
}

static int GetGarbageTerminationPosition(string str)
  {
      int i = 0;
      while (i < str.Length)
      {
          if (str[i] == '!')
          {
              i += 2;
          }
          else if (str[i] == '>')
          {
              return i + 1;
          }
          else
          {
              GarbageCounter.n ++;
              i++;
          }
      }
      return 0;
  }

class GarbageCounter
{
    public static int n { get; set; }
}