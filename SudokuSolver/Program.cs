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
            var solver = new Solver(sudoku);
            var result = solver.Solve();
            if (result)
            {
                Console.WriteLine("Solution found!");
                Console.WriteLine(sudoku.ToString());
                reader.Write(sudoku);
            }
            else
            {
                Console.WriteLine("No solution found, puzzle unsolvable.");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}