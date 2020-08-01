using SudokuSolverApp.Data;
using SudokuSolverApp.Strategies;
using SudokuSolverApp.Workers;
using System;

namespace SudokuSolverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuTextFileReader sudokuTextFileReader = new SudokuTextFileReader();
                SudokuMatrixDisplayer sudokuMatrixDisplayer = new SudokuMatrixDisplayer();
                SudokuMapper sudokuMapper = new SudokuMapper();
                SudokuStateManager sudokuStateManager = new SudokuStateManager();
                SudokuSolverEngine sudokuSolverEngine = new SudokuSolverEngine(sudokuStateManager, sudokuMapper);
                
                Console.WriteLine("Please enter the filename containing the Sudoku Puzzle:");
                var filename = Console.ReadLine();

                var sudokuMatrix = sudokuTextFileReader.ReadFile(filename);
                sudokuMatrixDisplayer.Display("Initial State", sudokuMatrix);

                bool isSudokuSolved = sudokuSolverEngine.Solve(sudokuMatrix);
                sudokuMatrixDisplayer.Display("Final State", sudokuMatrix);

                Console.WriteLine(isSudokuSolved ? "You have successfully solved this Sudoku Puzzle!"
                                                 : "Unfortunatley, current algorithm(s) were not enough to solve the current Sudoku Puzzle!");
            }
   
             catch (Exception ex)
            {
                // In real world we would want to log this message
                Console.WriteLine("{0} : {1}", "Sudoku Puzzle cannot be solved because there was an error:", ex.Message);
            }
        }
    }
}
