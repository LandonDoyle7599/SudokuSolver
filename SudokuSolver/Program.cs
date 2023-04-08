using System;

namespace SudokuSolver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Sudoku Solver!");
            var reader = new ReaderWriter();
            var sudoku = new Sudoku(reader.Read());
            if (sudoku.Solve())
            {
                Console.WriteLine("Solved!");
            }else
            {
                Console.WriteLine("No solution found!");
            }
            Console.WriteLine(sudoku);
            Console.WriteLine("Please enter the path you want to save the solved puzzle to:");
            path = Console.ReadLine();
            sudoku.Save(path);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}