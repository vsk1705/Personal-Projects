using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SudokuSolverApp.Test
{
    [TestClass]
    public class SudokoSolverStrategiesTest
    {
        private readonly IStrategy _simpleMarkupStrategy = new SimpleMarkUpStrategy(new SudokuMapper());
        private readonly IStrategy _nakedPairsStrategy = new NakedPairStrategy(new SudokuMapper());
        [TestMethod]
        public void ToSolveTopLeftMostCellElement()
        {
            int[,] sudokuMatrix =
            {
                 { 0, 1, 2, 3, 9, 8, 4, 7, 5},
                { 5, 3, 8, 4, 1, 7, 6, 2, 9},
                { 4, 7, 9, 5, 6, 2, 3, 1, 8},
                { 9, 6, 7, 2, 8, 4, 1, 5, 3},
                { 3, 8, 4, 6, 5, 1, 7, 9, 2},
                { 2, 5, 1, 7, 3, 9, 8, 6, 4},
                { 8, 2, 5, 1, 4, 6, 9, 3, 7},
                { 1, 9, 3, 8, 7, 5, 2, 4, 6},
                { 7, 4, 6, 9, 2, 3, 5, 8, 1}
             };

            var solvedSudokuMatrix = _simpleMarkupStrategy.Solve(sudokuMatrix);
            Assert.AreEqual(solvedSudokuMatrix[0, 0], 6);
        }

        [TestMethod]
        public void ShouldEliminateNumbersInColBasedOnNakedPair()
        {
            int[,] sudokuBoard =
            {
                { 1, 0, 0, 0 , 0, 0, 0, 0, 0},
                { 24, 0, 0, 0, 0, 0, 0, 0, 0},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0},
                { 5, 0, 0, 0, 0, 0, 0, 0, 0},
                { 6, 0, 0, 0, 0, 0, 0, 0, 0},
                { 24, 0, 0, 0, 0, 0, 0, 0, 0},
                { 7, 0, 0, 0, 0, 0, 0, 0, 0},
                { 8, 0, 0, 0, 0, 0, 0, 0, 0},
                { 249, 0, 0, 0, 0, 0, 0, 0, 0},
            };

            var solvedSudokuBoard = _nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[8, 0] == 9);
        }

        [TestMethod]
        public void ShouldEliminateNumbersInBlock1BasedOnNakedPair()
        {
            int[,] sudokuBoard =
            {
                { 1, 2, 3, 0 , 0, 0, 0, 0, 0},
                { 45, 6, 7, 0, 0, 0, 0, 0, 0},
                { 8, 45, 459, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };

            var solvedSudokuBoard = _nakedPairsStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[2, 2] == 9);
        }
    }
}
