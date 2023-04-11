using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    public class HiddenPairsSolver : SudokuCellSolvers
    {
        NakedSingleSolver nsSolver;
        HiddenSingles hsSolver;
        NakedPairsSolver npSolver;
        public HiddenPairsSolver(Sudoku puzzle) : base(puzzle)
        {
            nsSolver = new NakedSingleSolver(puzzle);
            hsSolver = new HiddenSingles(puzzle);
            npSolver = new NakedPairsSolver(puzzle);
        }
        
        public override void Solve()
        {
            HiddenPairs(0);
            HiddenPairs(1);
            HiddenPairs(2);
            nsSolver.Solve();
            hsSolver.Solve();
            npSolver.Solve();
        }

        public void HiddenPairs(int unitType)
        {
            // Iterate through every unit (row, column, box) on the board
            for (int unit = 0; unit < Size; unit++)
            {
                // Collect all unsolved cells in the unit
                List<SudokuCell> unsolvedCells = new List<SudokuCell>();
                foreach (SudokuCell cell in GetUnitCells(unitType, unit))
                {
                    if (cell.Value == '-')
                    {
                        unsolvedCells.Add(cell);
                    }
                }

                // If there are less than 3 unsolved cells in the unit, move on to the next unit
                if (unsolvedCells.Count < 3)
                {
                    continue;
                }

                // Generate all possible pairs of unsolved cells in the unit
                List<Tuple<SudokuCell, SudokuCell>> unsolvedPairs = new List<Tuple<SudokuCell, SudokuCell>>();
                for (int i = 0; i < unsolvedCells.Count; i++)
                {
                    for (int j = i + 1; j < unsolvedCells.Count; j++)
                    {
                        unsolvedPairs.Add(new Tuple<SudokuCell, SudokuCell>(unsolvedCells[i], unsolvedCells[j]));
                    }
                }

                // Check each pair of unsolved cells for a hidden pair
                foreach (Tuple<SudokuCell, SudokuCell> pair in unsolvedPairs)
                {
                    List<char> combinedPossibleValues = new List<char>(pair.Item1.PossibleValues);
                    combinedPossibleValues.AddRange(pair.Item2.PossibleValues);

                    // If the combined possible values of the pair contain exactly two distinct values,
                    // those values form a hidden pair in the unit
                    if (combinedPossibleValues.Count == 2 && combinedPossibleValues[0] != combinedPossibleValues[1])
                    {
                        // Iterate through the rest of the unsolved cells in the unit
                        foreach (SudokuCell cell in unsolvedCells)
                        {
                            if (cell != pair.Item1 && cell != pair.Item2)
                            {
                                // Remove the hidden pair from the possible values of the other cells in the unit
                                if (cell.PossibleValues.Contains(combinedPossibleValues[0]))
                                {
                                    cell.PossibleValues.Remove(combinedPossibleValues[0]);
                                }

                                if (cell.PossibleValues.Contains(combinedPossibleValues[1]))
                                {
                                    cell.PossibleValues.Remove(combinedPossibleValues[1]);
                                }
                            }
                        }
                    }
                }
            }
        }
        private List<SudokuCell> GetUnitCells(int unitType, int unitIndex)
        {
            List<SudokuCell> unitCells = new List<SudokuCell>();

            switch (unitType)
            {
                // Row unit
                case 0:
                    unitCells.AddRange(Board[unitIndex]);
                    break;
                // Column unit
                case 1:
                    for (int row = 0; row < Size; row++)
                    {
                        unitCells.Add(Board[row][unitIndex]);
                    }
                    break;
                // Box unit
                case 2:
                    int boxSize = (int)Math.Sqrt(Size);
                    int startRow = (unitIndex / boxSize) * boxSize;
                    int startCol = (unitIndex % boxSize) * boxSize;

                    for (int row = startRow; row < startRow + boxSize; row++)
                    {
                        for (int col = startCol; col < startCol + boxSize; col++)
                        {
                            unitCells.Add(Board[row][col]);
                        }
                    }
                    break;
            }

            return unitCells;
        }

    }
}
