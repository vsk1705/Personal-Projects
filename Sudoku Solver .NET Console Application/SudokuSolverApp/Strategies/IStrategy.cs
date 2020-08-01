namespace SudokuSolverApp.Strategies
{
    interface IStrategy
    {
        int[,] Solve(int[,] SudokuMatrix);
    }
}
