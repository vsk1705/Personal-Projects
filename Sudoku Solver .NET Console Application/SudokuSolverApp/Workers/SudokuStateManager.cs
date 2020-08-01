using System.Text;

namespace SudokuSolverApp.Workers
{
    class SudokuStateManager
    {
        public string Generate(int[,] sudokuMatrix)
        {
            StringBuilder key = new StringBuilder();

            for (int row = 0; row < sudokuMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuMatrix.GetLength(1); col++)
                {
                    key.Append(sudokuMatrix[row, col]);
                }
            }
            return key.ToString();
        }

        public bool IsSolved(int[,] sudokuMatrix)
        {
            for (int row = 0; row < sudokuMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < sudokuMatrix.GetLength(1); col++)
                {
                    if (sudokuMatrix[row, col] == 0 || sudokuMatrix[row, col].ToString().Length > 1)
                        return false;
                }
            }
            return true;
        }
    }
}


