using System.Collections.Generic;

namespace SudokuSolver
{
    public class NakedPairsSolver : SudokuCellSolvers
    {
        private NakedSingleSolver nsSolver;
        HiddenSingles hsSolver;
        public NakedPairsSolver(Sudoku puzzle) : base(puzzle)
        {
            nsSolver = new NakedSingleSolver(puzzle);
            hsSolver = new HiddenSingles(puzzle);
        }

        public override void Solve()
        {
            // Iterate through every cell on the board
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    SudokuCell cell = Board[row][col];

                    // If the cell is already solved or has more than two possible values, move on to the next one
                    if (cell.Value != '-' || cell.PossibleValues.Count != 2)
                    {
                        continue;
                    }

                    // Check the rest of the cells in the same row for another cell with the same two possible values
                    for (int i = 0; i < Size; i++)
                    {
                        if (i != col)
                        {
                            SudokuCell otherCell = Board[row][i];
                            if (otherCell.Value == '-' && otherCell.PossibleValues.Count == 2 && 
                                cell.PossibleValues[0] == otherCell.PossibleValues[0] && 
                                cell.PossibleValues[1] == otherCell.PossibleValues[1])
                            {
                                // If found, remove the two possible values from all other cells in the same row
                                for (int j = 0; j < Size; j++)
                                {
                                    SudokuCell affectedCell = Board[row][j];
                                    if (affectedCell != cell && affectedCell != otherCell && affectedCell.Value == '-')
                                    {
                                        affectedCell.PossibleValues.Remove(cell.PossibleValues[0]);
                                        affectedCell.PossibleValues.Remove(cell.PossibleValues[1]);
                                    }
                                }
                            }
                        }
                    }

                    // Check the rest of the cells in the same column for another cell with the same two possible values
                    for (int j = 0; j < Size; j++)
                    {
                        if (j != row)
                        {
                            SudokuCell otherCell = Board[j][col];
                            if (otherCell.Value == '-' && otherCell.PossibleValues.Count == 2 && 
                                cell.PossibleValues[0] == otherCell.PossibleValues[0] && 
                                cell.PossibleValues[1] == otherCell.PossibleValues[1])
                            {
                                // If found, remove the two possible values from all other cells in the same column
                                for (int i = 0; i < Size; i++)
                                {
                                    SudokuCell affectedCell = Board[i][col];
                                    if (affectedCell != cell && affectedCell != otherCell && affectedCell.Value == '-')
                                    {
                                        affectedCell.PossibleValues.Remove(cell.PossibleValues[0]);
                                        affectedCell.PossibleValues.Remove(cell.PossibleValues[1]);
                                    }
                                }
                            }
                        }
                    }

                    // Check the rest of the cells in the same box for another cell with the same two possible values
                    int boxSize = (int)System.Math.Sqrt(Size);
                    int boxRow = row / boxSize;
                    int boxCol = col / boxSize;
                    for (int i = boxRow * boxSize; i < boxRow * boxSize + boxSize; i++)
                    {
                        for (int j = boxCol * boxSize; j < boxCol * boxSize + boxSize; j++)
                        {
                            if (i != row && j != col)
                            {
                                SudokuCell otherCell = Board[i][j];
                                if (otherCell.Value == '-' && otherCell.PossibleValues.Count == 2 && cell.PossibleValues[0] == otherCell.PossibleValues[0] &&
                                    cell.PossibleValues[1] == otherCell.PossibleValues[1])
                                {
                                    // If found, remove the two possible values from all other cells in the same box
                                    for (int m = boxRow * boxSize; m < boxRow * boxSize + boxSize; m++)
                                    {
                                        for (int n = boxCol * boxSize; n < boxCol * boxSize + boxSize; n++)
                                        {
                                            SudokuCell affectedCell = Board[m][n];
                                            if (affectedCell != cell && affectedCell != otherCell && affectedCell.Value == '-')
                                            {
                                                affectedCell.PossibleValues.Remove(cell.PossibleValues[0]);
                                                affectedCell.PossibleValues.Remove(cell.PossibleValues[1]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            nsSolver.Solve();
            hsSolver.Solve();
        }
    }
}
