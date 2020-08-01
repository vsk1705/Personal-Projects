using System;
using System.IO;
using System.Linq;

namespace SudokuSolverApp.Workers
{
    class SudokuTextFileReader
    {
        public int[,] ReadFile(string filename)
        {
            try
            {
                int[,] sudokumatrix = new int[9, 9];

                string[] sudokuMatrixLines = File.ReadAllLines(filename);

                int row = 0;
                foreach (var sudokuMatrixLine in sudokuMatrixLines)
                {
                    string[] sudokuMatrixLineElements = sudokuMatrixLine.Split('|').Skip(1).Take(9).ToArray();
                    int col = 0;
                    foreach (var sudokuMatrixLineElement in sudokuMatrixLineElements)
                    {
                        sudokumatrix[row, col] = sudokuMatrixLineElement.Equals(" ") ? 0 : Convert.ToInt16(sudokuMatrixLineElement);
                        col++;
                    }
                    row++;
                }
                return sudokumatrix;
            }
            catch(Exception ex)
            {
                throw new Exception("Something went wrong with the reading of the Sudoku Text File" + ex.Message);
            }
        }
    }
}


