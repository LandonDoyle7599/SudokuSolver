using System.Collections.Generic;

namespace SudokuSolver
{
    public class XWingSolver : SudokuCellSolvers
    {
        private AssignPossibleValues apvSolver;
        private NakedSingleSolver nsSolver;
        private HiddenSingles hsSolver;
        private NakedPairsSolver npSolver;
        

        public XWingSolver(Sudoku puzzle) : base(puzzle)
        {
            apvSolver = new AssignPossibleValues(puzzle);
            nsSolver = new NakedSingleSolver(puzzle);
            hsSolver = new HiddenSingles(puzzle);
            npSolver = new NakedPairsSolver(puzzle);
        }

        public override void Solve()
        {
            apvSolver.Solve();
            foreach (var value in Values)
            {
                // Check for X-Wing in rows
                for (int i = 0; i < Size; i++)
                {
                    List<SudokuCell> candidates = new List<SudokuCell>();
                    foreach (SudokuCell cell in Board[i])
                    {
                        if (cell.Value == '-' && cell.PossibleValues.Contains(value))
                        {
                            candidates.Add(cell);
                        }
                    }

                    if (candidates.Count == 2)
                    {
                        int row1 = candidates[0].Row;
                        int row2 = candidates[1].Row;
                        if (row1 != row2)
                        {
                            List<SudokuCell> eliminations = new List<SudokuCell>();
                            for (int j = 0; j < Size; j++)
                            {
                                if (Board[row1][j].PossibleValues.Contains(value) &&
                                    Board[row2][j].PossibleValues.Contains(value))
                                {
                                    foreach (SudokuCell cell in Board[j])
                                    {
                                        if (cell.Value == '-' && cell.Row != row1 && cell.Row != row2 &&
                                            cell.PossibleValues.Contains(value))
                                        {
                                            eliminations.Add(cell);
                                        }
                                    }
                                }
                            }

                            if (eliminations.Count > 0)
                            {
                                foreach (SudokuCell cell in candidates)
                                {
                                    cell.PossibleValues.Clear();
                                    cell.PossibleValues.Add(value);
                                }

                                foreach (SudokuCell cell in eliminations)
                                {
                                    cell.PossibleValues.Remove(value);
                                }

                                apvSolver.Solve();
                            }
                        }
                    }
                }

                // Check for X-Wing in columns
                for (int j = 0; j < Size; j++)
                {
                    List<SudokuCell> candidates = new List<SudokuCell>();
                    for (int i = 0; i < Size; i++)
                    {
                        SudokuCell cell = Board[i][j];
                        if (cell.Value == '-' && cell.PossibleValues.Contains(value))
                        {
                            candidates.Add(cell);
                        }
                    }

                    if (candidates.Count == 2)
                    {
                        int col1 = candidates[0].Column;
                        int col2 = candidates[1].Column;
                        if (col1 != col2)
                        {
                            List<SudokuCell> eliminations = new List<SudokuCell>();
                            for (int i = 0; i < Size; i++)
                            {
                                if (Board[i][col1].PossibleValues.Contains(value) &&
                                    Board[i][col2].PossibleValues.Contains(value))
                                {
                                    foreach (SudokuCell cell in Board[i])
                                    {
                                        if (cell.Value == '-' && cell.Column != col1 && cell.Column != col2 &&
                                            cell.PossibleValues.Contains(value))
                                        {
                                            eliminations.Add(cell);
                                        }
                                    }
                                }
                            }

                            if (eliminations.Count > 0)
                            {
                                foreach (SudokuCell cell in candidates)
                                {
                                    cell.PossibleValues.Clear();
                                    cell.PossibleValues.Add(value);
                                }

                                foreach (SudokuCell cell in eliminations)
                                {
                                    cell.PossibleValues.Remove(value);
                                }

                                apvSolver.Solve();
                            }
                        }
                    }
                }

                // X-Wing in boxes
                int boxSize = (int)System.Math.Sqrt(Size);
                for (int boxRow = 0; boxRow < Size; boxRow += boxSize)
                {
                    for (int boxCol = 0; boxCol < Size; boxCol += boxSize)
                    {
                        List<SudokuCell> candidates = new List<SudokuCell>();
                        List<int> rows = new List<int>();
                        List<int> cols = new List<int>();
                        for (int i = boxRow; i < boxRow + boxSize; i++)
                        {
                            for (int j = boxCol; j < boxCol + boxSize; j++)
                            {
                                SudokuCell cell = Board[i][j];
                                if (cell.Value == '-' && cell.PossibleValues.Contains(value))
                                {
                                    candidates.Add(cell);
                                    if (!rows.Contains(cell.Row))
                                    {
                                        rows.Add(cell.Row);
                                    }

                                    if (!cols.Contains(cell.Column))
                                    {
                                        cols.Add(cell.Column);
                                    }
                                }
                            }
                        }

                        if (candidates.Count == 2 && rows.Count == 2 && cols.Count == 2)
                        {
                            int row1 = rows[0];
                            int row2 = rows[1];
                            int col1 = cols[0];
                            int col2 = cols[1];
                            if (row1 != row2 && col1 != col2)
                            {
                                List<SudokuCell> eliminations = new List<SudokuCell>();
                                for (int i = boxRow; i < boxRow + boxSize; i++)
                                {
                                    for (int j = boxCol; j < boxCol + boxSize; j++)
                                    {
                                        SudokuCell cell = Board[i][j];
                                        if (cell.Value == '-' && cell.Row != row1 && cell.Row != row2 &&
                                            cell.Column != col1 && cell.Column != col2 &&
                                            cell.PossibleValues.Contains(value))
                                        {
                                            eliminations.Add(cell);
                                        }
                                    }
                                }

                                if (eliminations.Count > 0)
                                {
                                    foreach (SudokuCell cell in candidates)
                                    {
                                        cell.PossibleValues.Clear();
                                        cell.PossibleValues.Add(value);
                                    }

                                    foreach (SudokuCell cell in eliminations)
                                    {
                                        cell.PossibleValues.Remove(value);
                                    }

                                    apvSolver.Solve();
                                }
                            }
                        }
                    }
                }

            }
            nsSolver.Solve();
            hsSolver.Solve();
            npSolver.Solve();
        }
    }
}