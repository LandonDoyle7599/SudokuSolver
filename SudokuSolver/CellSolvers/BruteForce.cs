using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    public class BruteForceSolver : SudokuCellSolvers
    {
        public BruteForceSolver(Sudoku puzzle) : base(puzzle)
        {
        }

        public override void Solve()
        {
            // Find the first empty cell in the puzzle
            SudokuCell emptyCell = FindEmptyCell();

            // If there are no more empty cells, the puzzle is solved
            if (emptyCell == null)
            {
                return;
            }

            // Try out all possible values for the empty cell
            List<char> validValues = GetValidValues(emptyCell.Row, emptyCell.Column);
            foreach (char value in validValues)
            {
                // Set the cell to the valid value and recurse to solve the rest of the puzzle
                Board[emptyCell.Row][emptyCell.Column].Value = value;
                Solve();

                // If the recursion has solved the puzzle, return
                if (IsSolved())
                {
                    return;
                }
            }

            // If none of the values worked, reset the cell to empty and backtrack
            Board[emptyCell.Row][emptyCell.Column].Value = '-';
        }

        private SudokuCell FindEmptyCell()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Board[i][j].Value == '-')
                    {
                        return Board[i][j];
                    }
                }
            }
            return null;
        }
        
        private List<char> GetValidValues(int row, int col)
        {
            List<char> validValues = new List<char>(Values);

            // Check row and column for the same value
            for (int i = 0; i < Size; i++)
            {
                if (Board[row][i].Value != '-')
                {
                    validValues.Remove(Board[row][i].Value);
                }
                if (Board[i][col].Value != '-')
                {
                    validValues.Remove(Board[i][col].Value);
                }
            }

            // Check box for the same value
            int boxSize = (int)Math.Sqrt(Size);
            int boxRow = row / boxSize * boxSize;
            int boxCol = col / boxSize * boxSize;
            for (int i = boxRow; i < boxRow + boxSize; i++)
            {
                for (int j = boxCol; j < boxCol + boxSize; j++)
                {
                    if (Board[i][j].Value != '-')
                    {
                        validValues.Remove(Board[i][j].Value);
                    }
                }
            }

            // If the value is valid, return true
            return validValues;
        }

        private bool IsSolved()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Board[i][j].Value == '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
