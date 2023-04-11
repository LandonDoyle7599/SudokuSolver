using System.Collections.Generic;

namespace SudokuSolver
{
    public class HiddenSingles : SudokuCellSolvers
    {
        private AssignPossibleValues apvSolver;
        public HiddenSingles(Sudoku puzzle) : base(puzzle)
        {
            apvSolver = new AssignPossibleValues(puzzle);
        }

        public override void Solve()
        {
            apvSolver.Solve();
            for (int i = 0; i < Size; i++)
            {
                // Check for hidden singles in rows
                foreach (char value in Values)
                {
                    List<SudokuCell> candidates = new List<SudokuCell>();
                    foreach (SudokuCell cell in Board[i])
                    {
                        if (cell.Value == '-')
                        {
                            if (cell.PossibleValues.Contains(value))
                            {
                                candidates.Add(cell);
                            }
                        }
                    }
                    if (candidates.Count == 1)
                    {
                        candidates[0].Value = value;
                        apvSolver.Solve();
                    }
                }
                
                // Check for hidden singles in boxes
                int boxSize = (int)System.Math.Sqrt(Size);
                for (int m = 0; m < boxSize; m++)
                {
                    for (int n = 0; n < boxSize; n++)
                    {
                        foreach (char value in Values)
                        {
                            List<SudokuCell> candidates = new List<SudokuCell>();
                            for (int x = m * boxSize; x < m * boxSize + boxSize; x++)
                            {
                                for (int y = n * boxSize; y < n * boxSize + boxSize; y++)
                                {
                                    SudokuCell cell = Board[x][y];
                                    if (cell.Value == '-')
                                    {
                                        if (cell.PossibleValues.Contains(value))
                                        {
                                            candidates.Add(cell);
                                        }
                                    }
                                }
                            }
                            if (candidates.Count == 1)
                            {
                                candidates[0].Value = value;
                                apvSolver.Solve();
                            }
                        }
                    }
                }

                // Check for hidden singles in columns
                foreach (char value in Values)
                {
                    List<SudokuCell> candidates = new List<SudokuCell>();
                    for (int j = 0; j < Size; j++)
                    {
                        SudokuCell cell = Board[j][i];
                        if (cell.Value == '-')
                        {
                            if (cell.PossibleValues.Contains(value))
                            {
                                candidates.Add(cell);
                            }
                        }
                    }
                    if (candidates.Count == 1)
                    {
                        candidates[0].Value = value;
                        apvSolver.Solve();
                    }
                }

            }
        }
    }
}