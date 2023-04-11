using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    public class NakedSingleSolver : SudokuCellSolvers
    {
        public NakedSingleSolver(Sudoku puzzle) : base(puzzle)
        {
        }

        public override void Solve()
        {
            // Iterate through every cell on the board
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    SudokuCell cell = Board[row][col];

                    // If the cell is already solved, move on to the next one
                    if (cell.Value != '-')
                    {
                        continue;
                    }

                    // If the cell has only one possible value, it is a naked single  
                    if (cell.PossibleValues.Count == 1)
                    {
                        cell.Value = cell.PossibleValues[0];
                        cell.PossibleValues.Clear();
                    }
                }
            }
        }
    }
}