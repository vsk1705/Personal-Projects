using SudokuSolverApp.Data;
using SudokuSolverApp.Workers;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverApp.Strategies
{
    class SudokuSolverEngine
    {
        private readonly SudokuStateManager _sudokuStateManager;
        private readonly SudokuMapper _sudokuMapper;

        public SudokuSolverEngine(SudokuStateManager sudokuStateManager, SudokuMapper sudokuMapper)
        {
            this._sudokuMapper = sudokuMapper;
            this._sudokuStateManager = sudokuStateManager;
        }

        public bool Solve(int[,] sudokuMatrix)
        {
            List<IStrategy> strategies = new List<IStrategy>()
            {
                new SimpleMarkUpStrategy(_sudokuMapper),
                new NakedPairStrategy(_sudokuMapper)
            };

            var currentState = _sudokuStateManager.Generate(sudokuMatrix);
            var nextState = _sudokuStateManager.Generate(strategies.First().Solve(sudokuMatrix));

            while (!_sudokuStateManager.IsSolved(sudokuMatrix) && currentState != nextState)
            {
                currentState = nextState;
                foreach (var strategy in strategies) 
                    nextState = _sudokuStateManager.Generate(strategy.Solve(sudokuMatrix));
            }
            return _sudokuStateManager.IsSolved(sudokuMatrix);
        }
    }
}
