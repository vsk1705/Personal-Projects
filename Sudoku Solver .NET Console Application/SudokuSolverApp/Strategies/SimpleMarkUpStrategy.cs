using SudokuSolverApp.Data;
using System;
using System.Linq;

namespace SudokuSolverApp.Strategies
{
    class SimpleMarkUpStrategy : IStrategy
    {
        private readonly SudokuMapper _sudokuMapper;
        public SimpleMarkUpStrategy(SudokuMapper sudokuMapper)
        {
            this._sudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] SudokuMatrix)
        {
            for(int row = 0; row < SudokuMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < SudokuMatrix.GetLength(1); col++)
                {
                    if (SudokuMatrix[row, col] == 0 || SudokuMatrix[row, col].ToString().Length > 1)
                    {
                        var possibilityInRowAndCol = GetPossibilityInRowAndCol(SudokuMatrix, row, col);
                        var possibilityInBlock = GetPossibilityInBlock(SudokuMatrix, row, col);
                        SudokuMatrix[row, col] = GetIntersectionOfPossibilities(possibilityInRowAndCol, possibilityInBlock);
                    }     
                }
            }
            return SudokuMatrix;
        }

        private int GetPossibilityInRowAndCol(int[,] sudokuMatrix, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int col = 0; col < sudokuMatrix.GetLength(1); col++)
                if (IsValidElement(sudokuMatrix[givenRow, col]))
                    possibilities[sudokuMatrix[givenRow, col] - 1] = 0;

            for (int row = 0; row < sudokuMatrix.GetLength(0); row++)
                if (IsValidElement(sudokuMatrix[row, givenCol]))
                    possibilities[sudokuMatrix[row, givenCol] - 1] = 0;

            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        private int GetPossibilityInBlock(int[,] sudokuMatrix, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var sudokuMap = _sudokuMapper.Find(givenRow, givenCol);

            for (int row = sudokuMap.StartRow; row <= sudokuMap.StartRow + 2; row++)
            {
                for (int col = sudokuMap.StartCol; col <= sudokuMap.StartCol + 2; col++)
                {
                    if (IsValidElement(sudokuMatrix[row, col])) possibilities[sudokuMatrix[row, col] - 1] = 0;
                }
            }
            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }
        private bool IsValidElement(int cellElement)                    // Helper Method
        {
            if (cellElement != 0 && cellElement.ToString().Length == 1)
                return true;
            return false;
        }
        private int GetIntersectionOfPossibilities(int possibilityInRowAndCol, int possibilityInBlock)
        {
            var possibilityInRowAndColArray = possibilityInRowAndCol.ToString().ToCharArray();
            var possibilityInBlockArray = possibilityInBlock.ToString().ToCharArray();
            var possibilityIntersectionArray = possibilityInRowAndColArray.Intersect(possibilityInBlockArray);
            return Convert.ToInt32(string.Join(string.Empty, possibilityIntersectionArray));
        }
    }
}
