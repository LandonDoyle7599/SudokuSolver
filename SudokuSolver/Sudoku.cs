using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SudokuSolver
{
    public class Sudoku
    {
        public SudokuCell[][] Board { get; set; }
        public int Size { get; set; }
        public char[] Values { get; set; }

        public Sudoku(string[] lines)
        {
            if (!ValidateInput(lines))
            {
                Console.WriteLine("Puzzle input isn't structured correctly, try again.");
                Environment.Exit(0);
            }
            for(var i = 0; i < lines.Length; i++)
            {
                lines[i] = Regex.Replace(lines[i], @"\s+", string.Empty);
            }
            Values = lines[1].ToCharArray();
            Size = int.Parse(lines[0]);
            Board = new SudokuCell[Size][];
            for (var i = 0; i < Size; i++)
            {
                Board[i] = new SudokuCell[Size];
            }
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    Board[i][j] = new SudokuCell(lines[i + 2][j], i, j);
                }
            }

            if (!CheckIfValid())
            {
                Console.WriteLine("Invalid Puzzle, try again.");
                Environment.Exit(0);
            }
        }
        
        
        public override string ToString()
        {
            var result = "";
            result += Size + "\n";
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    result += Board[i][j].Value;
                }

                result += "\n";
            }

            return result;
        }
        
        public string[] ToArray()
        {
            var result = new string[Size + 2];
            result[0] = "Size: " + Size + "x" + Size;
            result[1] = "Solved";
            for (var i = 0; i < Size; i++)
            {
                result[i + 2] = " ";
                for (var j = 0; j < Size; j++)
                {
                    result[i + 2] += Board[i][j].Value;
                    result[i+2] += " ";
                }

                result[i+2]=result[i + 2].Trim();
            }

            return result;
        }

        public bool CheckIfValid()
        {
            var valid = true;
            for (var i = 0; i < Size; i++)
            {
                var row = new List<char>();
                var column = new List<char>();
                for (var j = 0; j < Size; j++)
                {
                    row.Add(Board[i][j].Value);
                    column.Add(Board[j][i].Value);
                }

                if (row.Count != row.Distinct().Count() + (row.Count(s => s == '-') > 0 ? row.Count(s => s == '-') - 1 : 0))
                {
                    valid = false;
                }

                if (column.Count != column.Distinct().Count() + (column.Count(s => s == '-') > 0 ? column.Count(s => s == '-') - 1 : 0))
                {
                    valid = false;
                }
            }

            var boxSize = (int)Math.Sqrt(Size);
            for (var i = 0; i < boxSize; i++)
            {
                for (var j = 0; j < boxSize; j++)
                {
                    var box = new List<char>();
                    for (var m = 0; m < boxSize; m++)
                    {
                        for (var n = 0; n < boxSize; n++)
                        {
                            box.Add(Board[i * boxSize + m][j * boxSize + n].Value);
                        }
                    }

                    if (box.Count != box.Distinct().Count() + (box.Count(s => s == '-') > 0 ? box.Count(s => s == '-') - 1 : 0))
                    {
                        valid = false;
                    }
                }
            }

            return valid;
        }
        
        public static bool ValidateInput(string[] input)
        {
            int size;
            if (!int.TryParse(input[0], out size))
            {
                return false;
            }
            input = Array.FindAll(input, s => !string.IsNullOrWhiteSpace(s));

            int sqrt = (int)Math.Sqrt(size);
            if (sqrt * sqrt != size)
            {
                return false;
            }

            string[] possibleValues = input[1].Split(' ');
            if (possibleValues.Length != size)
            {
                return false;
            }

            HashSet<string> set = new HashSet<string>(possibleValues);
            if (set.Count != size)
            {
                return false;
            }

            if (input.Length != size + 2)
            {
                return false;
            }

            for (int i = 2; i < input.Length; i++)
            {
                string[] row = input[i].Split(' ');
                if (row.Length != size)
                {
                    return false;
                }

                foreach (string val in row)
                {
                    if (!set.Contains(val) && val != "-")
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}