using System;
using System.Collections.Generic;
using System.IO;

namespace FileMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            string file1Path = @"c:\Users\bk91062\Documents\File1.txt";
            string file2Path = @"c:\Users\bk91062\Documents\File2.txt";
            string outputPath = "output.txt";

            // Read lines from both files
            List<string> file1Lines = ReadFileLines(file1Path);
            List<string> file2Lines = ReadFileLines(file2Path);

            // Merge the lines and write to output file
            MergeAndWrite(file1Lines, file2Lines, outputPath);

            Console.WriteLine("Files merged successfully.");
        }

        static List<string> ReadFileLines(string filePath)
        {
            List<string> lines = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {filePath}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return lines;
        }

        static void MergeAndWrite(List<string> file1Lines, List<string> file2Lines, string outputPath)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                int i = 0, j = 0;

                // Merge the lines until either file reaches its end
                while (i < file1Lines.Count && j < file2Lines.Count)
                {
                    if (file1Lines[i].CompareTo(file2Lines[j]) < 0)
                    {
                        writer.WriteLine(file1Lines[i]);
                        i++;
                    }
                    else
                    {
                        writer.WriteLine(file2Lines[j]);
                        j++;
                    }
                }

                // Write remaining lines from file 1
                while (i < file1Lines.Count)
                {
                    writer.WriteLine(file1Lines[i]);
                    i++;
                }

                // Write remaining lines from file 2
                while (j < file2Lines.Count)
                {
                    writer.WriteLine(file2Lines[j]);
                    j++;
                }
            }
        }
    }
}
