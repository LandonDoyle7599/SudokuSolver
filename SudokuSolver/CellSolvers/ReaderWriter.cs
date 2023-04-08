using System;
using System.IO;

namespace SudokuSolver
{
    public class ReaderWriter
    {
        public string[] Read()
        {
            Console.WriteLine("Enter the path to the file you want to read:");
            var path = Console.ReadLine();
            bool possiblePath = path.IndexOfAny(Path.GetInvalidPathChars()) == -1;
            if (!possiblePath)
            {
                Console.WriteLine("Invalid path! Try again.");
                Environment.Exit(1);
            }
            return File.ReadAllLines(path);
        }
        
        public void Write(string[] lines)
        {
            Console.WriteLine("Enter the path to the file you want to write to:");
            var path = Console.ReadLine();
            bool possiblePath = path.IndexOfAny(Path.GetInvalidPathChars()) == -1;
            if (!possiblePath)
            {
                Console.WriteLine("Invalid path! Try again.");
                Environment.Exit(1);
            }
            File.WriteAllLines(path, lines);
        }
    }
}