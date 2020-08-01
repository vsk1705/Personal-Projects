using System;
namespace SudokuSolverApp.Workers
{
    class SudokuMatrixDisplayer
    {
        public void Display(string title, int[,] sudokuMatrix)
        {
            if (!title.Equals(string.Empty)) 
                Console.WriteLine("{0} {1}", title, Environment.NewLine);

            for(int row = 0; row < sudokuMatrix.GetLength(0); row++)
            {
                Console.Write("|");
                for(int col = 0; col < sudokuMatrix.GetLength(1); col++)
                {
                    Console.Write("{0}{1}",sudokuMatrix[row, col],'|');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

