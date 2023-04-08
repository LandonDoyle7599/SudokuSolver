using System;

namespace SudokuSolver
{
    public class Sudoku
    {
        private readonly char[][] _board;
        private readonly int _size;

        public Sudoku(string[] lines)
        {
            _size = int.Parse(lines[0]);
            _board = new char[_size][];
            for (var i = 0; i < _size; i++)
            {
                _board[i] = new char[_size];
            }
            for (var i = 2; i < _size+2; i++)
            {
                var line = lines[i];
                var split = line.Split(' ');
                for (var j = 0; j < _size; j++)
                {
                    _board[i-2][j] = split[j][0];
                }
            }
        }

      //solution function, empty cells are marked with -
        public bool Solve()
        {
            for (var i = 0; i < _size; i++)
            {
                for (var j = 0; j < _size; j++)
                {
                    if (_board[i][j] == '-')
                    {
                        for (var k = 1; k <= _size; k++)
                        {
                            _board[i][j] = (char)(k + '0');
                            if (IsValid(i, j) && Solve())
                            {
                                return true;
                            }

                            _board[i][j] = '-';
                        }

                        return false;
                    }
                }
            }

            return true;
        }
        
private bool IsValid(int row, int col)
        {
            for (var i = 0; i < _size; i++)
            {
                if (i != col && _board[row][i] == _board[row][col])
                {
                    return false;
                }
            }

            for (var i = 0; i < _size; i++)
            {
                if (i != row && _board[i][col] == _board[row][col])
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
                    if (i != row && j != col && _board[i][j] == _board[row][col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < _size; i++)
            {
                for (var j = 0; j < _size; j++)
                {
                    result += _board[i][j];
                }

                result += "\r";
            }

            return result;
        }
        
        public void Save(string path)
        {
            System.IO.File.WriteAllText(path, ToString());
        }
    }
}