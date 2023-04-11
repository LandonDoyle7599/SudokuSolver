namespace SudokuSolver
{
    public abstract class SudokuCellSolvers
    {
        public SudokuCell[][] Board { get; }
        public int Size { get; }
        public char[] Values { get; }

        public SudokuCellSolvers(Sudoku puzzle)
        {
            Board = puzzle.Board;
            Size = puzzle.Size;
            Values = puzzle.Values;
            
        }
        public abstract void Solve();
        
    }
}