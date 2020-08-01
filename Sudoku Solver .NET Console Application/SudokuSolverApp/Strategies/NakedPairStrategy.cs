using SudokuSolverApp.Data;
using System;

namespace SudokuSolverApp.Strategies
{
    class NakedPairStrategy : IStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public NakedPairStrategy(SudokuMapper sudokuMapper)
        {
            this._sudokuMapper = sudokuMapper;
        }
        public int[,] Solve(int[,] sudokuMatrix)
        {
            for (int row = 0; row < sudokuMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuMatrix.GetLength(1); col++)
                {
                    EliminateNakedPairFromOthersInRow(sudokuMatrix, row, col);
                    EliminateNakedPairFromOthersInCol(sudokuMatrix, row, col);
                    EliminateNakedPairFromOthersInBlock(sudokuMatrix, row, col);
                }
            }
            return sudokuMatrix;
        }

        private void EliminateNakedPairFromOthersInRow(int[,] sudokuMatrix, int givenRow, int givenCol)
        {
            if (!HasNakedPairInRow(sudokuMatrix, givenRow, givenCol))
                return;
            for (int col = 0; col < sudokuMatrix.GetLength(1); col++)
            {
                if (sudokuMatrix[givenRow, givenCol] != sudokuMatrix[givenRow, givenCol] && sudokuMatrix[givenRow, col].ToString().Length > 1)
                    EliminateNakedPair(sudokuMatrix, sudokuMatrix[givenRow, givenCol], givenRow, col);
            }
        }

        private void EliminateNakedPair(int[,] sudokuMatrix, int valueToBeEliminated, int fromRow, int fromCol)
        {
            var valueToBeEliminatedArray = valueToBeEliminated.ToString().ToCharArray();
            foreach (var value in valueToBeEliminatedArray)
                sudokuMatrix[fromRow, fromCol] = Convert.ToInt32(sudokuMatrix[fromRow, fromCol].ToString().Replace(value.ToString(), string.Empty));
        }

        private bool HasNakedPairInRow(int[,] sudokuMatrix, int givenRow, int givenCol)
        {
            for (int col = 0; col < sudokuMatrix.GetLength(1); col++)
            {
                if (givenCol != col && IsNakedPair(sudokuMatrix[givenRow, col], sudokuMatrix[givenRow, givenCol]))
                    return true;
            }
            return false;
        }

        private bool IsNakedPair(int firstpair, int secondpair)
        {
            return firstpair.ToString().Length == 2 && firstpair == secondpair;
        }

        private void EliminateNakedPairFromOthersInCol(int[,] sudokuMatrix, int givenRow, int givenCol)
        {
            if (!HasNakedPairInCol(sudokuMatrix, givenRow, givenCol))
                return;
            for (int row = 0; row < sudokuMatrix.GetLength(0); row++)
            {
                if (sudokuMatrix[givenRow, givenCol] != sudokuMatrix[row, givenCol] && sudokuMatrix[row, givenCol].ToString().Length > 1)
                    EliminateNakedPair(sudokuMatrix, sudokuMatrix[givenRow, givenCol], row, givenCol);
            }
        }

        private bool HasNakedPairInCol(int[,] sudokuMatrix, int givenRow, int givenCol)
        {
            for (int row = 0; row < sudokuMatrix.GetLength(0); row++)
            {
                if (givenRow != row && IsNakedPair(sudokuMatrix[row, givenCol], sudokuMatrix[givenRow, givenCol]))
                    return true;
            }
            return false;
        }

        private void EliminateNakedPairFromOthersInBlock(int[,] sudokuMatrix, int givenRow, int givenCol)
        {
            if (!HasNakedPairInBlock(sudokuMatrix, givenRow, givenCol))
                return;

            var sudokuMap = _sudokuMapper.Find(givenRow, givenCol);
            for (int row = sudokuMap.StartRow; row < sudokuMap.StartRow + 2; row++)
            {
                for (int col = sudokuMap.StartCol; col < sudokuMap.StartCol + 2; col++)
                {
                    if (sudokuMatrix[row, col] != sudokuMatrix[givenRow, givenCol] && sudokuMatrix[row, col].ToString().Length > 1)
                    {
                        EliminateNakedPair(sudokuMatrix, sudokuMatrix[givenRow, givenCol], row, col);
                    }
                }
            }
        }

        private bool HasNakedPairInBlock(int[,] sudokuMatrix, int givenRow, int givenCol)
        {
            for (int row = 0; row < sudokuMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuMatrix.GetLength(1); col++)
                {
                    var elementSame = givenRow == row && givenCol == col;
                    var elementInSameBlock = _sudokuMapper.Find(givenRow, givenCol).StartRow == _sudokuMapper.Find(row, col).StartRow &&
                        _sudokuMapper.Find(givenRow, givenCol).StartCol == _sudokuMapper.Find(row, col).StartCol;

                    if (!elementSame && elementInSameBlock && IsNakedPair(sudokuMatrix[givenRow, givenCol], sudokuMatrix[row, col])) return true;
                }
            }
            return false;
        }
    }
}
