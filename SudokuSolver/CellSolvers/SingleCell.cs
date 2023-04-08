namespace SudokuSolver
{
    public class SingleCell
    {
        public char[,] Board { get; }
        public int Size { get; }

        public SingleCell(char[,] board, int size)
        {
            Board = board;
            Size = size;
        }

        public bool Solve()
        {
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (Board[i, j] == '.')
                    {
                        for (var k = 1; k <= 9; k++)
                        {
                            Board[i, j] = (char)(k + '0');
                            if (IsValid(i, j) && Solve())
                            {
                                return true;
                            }

                            Board[i, j] = '.';
                        }

                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsValid(int row, int col)
        {
            for (var i = 0; i < 9; i++)
            {
                if (i != col && Board[row, i] == Board[row, col])
                {
                    return false;
                }
            }

            for (var i = 0; i < 9; i++)
            {
                if (i != row && Board[i, col] == Board[row, col])
                {
                    return false;
                }
            }

            var rowStart = (row / 3) * 3;
            var colStart = (col / 3) * 3;
            for (var i = rowStart; i < rowStart + 3; i++)
            {
                for (var j = colStart; j < colStart + 3; j++)
                {
                    if (i != row && j != col && Board[i, j] == Board[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}