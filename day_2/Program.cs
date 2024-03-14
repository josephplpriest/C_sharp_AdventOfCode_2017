class Program
{
    public static void Main()
    {
        // string filePath = "input/example.txt";
        string filePath = "input/input.txt";

    // Part 1

    //     try
    //     {
    //         // Read all lines from the file into a string array
    //         string[] lines = File.ReadAllLines(filePath);

    //         int differenceCounter = 0;

    //         // Output each line
    //         foreach (string line in lines)
    //         {
    //             var intArray = line.Split(null).Select(int.Parse).ToList();
    //             Console.WriteLine(line);
    //             int difference = intArray.Max() - intArray.Min();
    //             Console.WriteLine($"  Max - Min: {difference}" );
    //             differenceCounter += difference;
    //         }

    //         Console.WriteLine($"Final difference total: {differenceCounter}");
    //     }
    //     catch (IOException e)
    //     {
    //         Console.WriteLine("An error occurred while reading the file: " + e.Message);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine("An unexpected error occurred: " + e.Message);
    //     }
    // }

        try
        {
            // Read all lines from the file into a string array
            string[] lines = File.ReadAllLines(filePath);

            int differenceCounter = 0;

            // Output each line
            foreach (string line in lines)
            {
                var intArray = line.Split(null).Select(int.Parse).ToList();

                for (int i = 0; i < intArray.Count - 1; i++)
                {
                    for (int j = i+1; j < intArray.Count; j++)
                    {
                        List<int> tempInts = [intArray[i], intArray[j]];
                        int larger = tempInts.Max();
                        int smaller = tempInts.Min();
                        if (larger % smaller == 0)
                        {
                            differenceCounter += larger / smaller;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"Final difference total: {differenceCounter}");
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("An unexpected error occurred: " + e.Message);
        }
    }


}