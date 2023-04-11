using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    public class Solver
    {
        private Sudoku _puzzle;

        public Solver(Sudoku puzzle)
        {
            _puzzle = puzzle;
        }

        public bool Solve()
        {
            // Assign every possible value to each cell
            AssignPossibleValues apvSolver = new AssignPossibleValues(_puzzle);
            apvSolver.Solve();
            Console.WriteLine("After assigning possible values: " +GetRemainingUnsolved());
            if (!CheckIfPossible())
            {
                return false;
            }

            // // Run naked singles solver
            NakedSingleSolver nsSolver = new NakedSingleSolver(_puzzle);
            nsSolver.Solve();
            Console.WriteLine("After naked singles: " +GetRemainingUnsolved());
            if (CheckIfSolved())
            {
                return true;
            }
            
            
            apvSolver.Solve();
            if (!CheckIfPossible())
            {
                return false;
            }
            // Run hidden singles solver
            HiddenSingles hsSolver = new HiddenSingles(_puzzle);
            hsSolver.Solve();
            Console.WriteLine("After hidden singles: " +GetRemainingUnsolved());
            if (CheckIfSolved())
            {
                return true;
            }
            
            apvSolver.Solve();
            if (!CheckIfPossible())
            {
                return false;
            }
            // Run naked pairs solver
            NakedPairsSolver npSolver = new NakedPairsSolver(_puzzle);
            npSolver.Solve();
            Console.WriteLine("After naked pairs: " +GetRemainingUnsolved());
            if (CheckIfSolved())
            {
                return true;
            }
            
            apvSolver.Solve();
            if (!CheckIfPossible())
            {
                return false;
            }
            // Run hidden pairs solver
            HiddenPairsSolver hpSolver = new HiddenPairsSolver(_puzzle);
            hpSolver.Solve();
            Console.WriteLine("After hidden pairs: " +GetRemainingUnsolved());
            if (CheckIfSolved())
            {
                return true;
            }
            
            apvSolver.Solve();
            if (!CheckIfPossible())
            {
                return false;
            }
            // Run xwing solver
            XWingSolver xwSolver = new XWingSolver(_puzzle);
            xwSolver.Solve();
            Console.WriteLine("After xwing: " +GetRemainingUnsolved());
            if (CheckIfSolved())
            {
                return true;
            }


            apvSolver.Solve();
            if (!CheckIfPossible())
            {
                return false;
            }
            // Run backtracking solver
            BruteForceSolver bfSolver = new BruteForceSolver(_puzzle);
            bfSolver.Solve();
            Console.WriteLine("After brute force: " +GetRemainingUnsolved());
            return CheckIfSolved();
        }
        
        

        public bool CheckIfSolved()
        {
            //check columns for duplicates
            for (var i = 0; i < _puzzle.Size; i++)
            {
                var column = new List<char>();
                for (var j = 0; j < _puzzle.Size; j++)
                {
                    column.Add(_puzzle.Board[j][i].Value);
                }
                if (column.Contains('-'))
                {
                    return false;
                }
                if (column.Count != column.Distinct().Count())
                {
                    return false;
                }
            }
            //check rows for duplicates
            for (var i = 0; i < _puzzle.Size; i++)
            {
                var row = new List<char>();
                for (var j = 0; j < _puzzle.Size; j++)
                {
                    row.Add(_puzzle.Board[i][j].Value);
                }
                if (row.Contains('-'))
                {
                    return false;
                }
                if (row.Count != row.Distinct().Count())
                {
                    return false;
                }
            }
//check boxes for duplicates
            int boxSize = (int)Math.Sqrt(_puzzle.Size);
            for (var i = 0; i < boxSize; i++)
            {
                for (var j = 0; j < boxSize; j++)
                {
                    var box = new List<char>();
                    for (var x = i * boxSize; x < i * boxSize + boxSize; x++)
                    {
                        for (var y = j * boxSize; y < j * boxSize + boxSize; y++)
                        {
                            box.Add(_puzzle.Board[x][y].Value);
                        }
                    }
                    if (box.Contains('-'))
                    {
                        return false;
                    }
                    if (box.Count != box.Distinct().Count())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CheckIfPossible()
        {
            for (var i = 0; i < _puzzle.Size; i++)
            {
                for (var j = 0; j < _puzzle.Size; j++)
                {
                    if (_puzzle.Board[i][j].Value == '-')
                    {
                        if (_puzzle.Board[i][j].PossibleValues.Count == 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private int GetRemainingUnsolved()
        {
            var count = 0;
            for (var i = 0; i < _puzzle.Size; i++)
            {
                for (var j = 0; j < _puzzle.Size; j++)
                {
                    if (_puzzle.Board[i][j].Value == '-')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}