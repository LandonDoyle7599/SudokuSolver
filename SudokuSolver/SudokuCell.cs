using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    public class SudokuCell
    {
        public List<char> PossibleValues { get; set; }
        public char Value { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        
        public SudokuCell(char value, int row, int column)
        {
            Value = value;
            Row = row;
            Column = column;
            PossibleValues = new List<char>();
        }
        
    }
}