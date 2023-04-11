using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    public class AssignPossibleValues: SudokuCellSolvers
    {
        private readonly Sudoku _puzzle;
        
        public AssignPossibleValues(Sudoku puzzle) : base(puzzle)
        {
            _puzzle = puzzle;
        }

        //method goes through Board and assigns possible values to each cell
        public override void Solve()
        {
            // Loop through every cell in the puzzle
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    var cell = Board[i][j];

                    // If the cell already has a value, skip it
                    if (cell.Value != '-')
                    {
                        cell.PossibleValues = new List<char>();
                        continue;
                    }

                    // Otherwise, initialize the possible values list with all the valid values
                    cell.PossibleValues = new List<char>(Values);

                    // Remove any values that are already present in the same row, column, or box
                    for (var k = 0; k < Size; k++)
                    {
                        // Check the row
                        if (Board[i][k].Value != '-')
                        {
                            cell.PossibleValues.Remove(Board[i][k].Value);
                        }

                        // Check the column
                        if (Board[k][j].Value != '-')
                        {
                            cell.PossibleValues.Remove(Board[k][j].Value);
                        }

                        // Check the box
                        var boxRow = (i / (int)Math.Sqrt(Size)) * (int)Math.Sqrt(Size) + k / (int)Math.Sqrt(Size);
                        var boxCol = (j / (int)Math.Sqrt(Size)) * (int)Math.Sqrt(Size) + k % (int)Math.Sqrt(Size);
                        if (Board[boxRow][boxCol].Value != '-')
                        {
                            cell.PossibleValues.Remove(Board[boxRow][boxCol].Value);
                        }
                    }
                    cell.PossibleValues.Sort();
                }
            }
        }
            
            
            
    }
}