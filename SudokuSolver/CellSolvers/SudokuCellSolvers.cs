namespace SudokuSolver
{
    public abstract class SudokuCellSolvers
    {
        public char[,] Board { get; }
        public int Size { get; }

        public SudokuCellSolvers(char[,] board, int size)
        {
            Board = board;
            Size = size;
        }

        public abstract bool Solve();
    }
}