using System;
using System.IO;

namespace FileReader
{
    class FirstLine
    {
        public static string Reader()
        {
            try
            {
                string filePath = "input/data.txt";
                // string filePath = "input/example.txt";

                // Open the file with a StreamReader
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // Read the first line from the file
                    string firstLine = sr.ReadLine();

                    // Check if the line is not null
                    if (firstLine != null)
                    {
                        return firstLine;            

                    }
                    else
                    {
                        return "The file is empty.";
                    }
                }
            }
            catch
            {
                return "The file is empty.";

            }
        }
    }
}
