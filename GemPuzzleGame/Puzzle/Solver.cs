using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemPuzzleGame.Puzzle;

namespace GemPuzzleGame.Puzzle
{
    public static class Solver
    {
        private static PuzzleState _startNode;
        private static PuzzleState _currentNode;
        private static PuzzleState _goalNode;
        private static List<PuzzleState> _openList;
        private static List<PuzzleState> _closedList;

        public static PuzzleState StartNode { get { return Solver._startNode; } set { Solver._startNode = value; } }
        public static PuzzleState CurrentNode { get { return Solver._currentNode; } set { Solver._currentNode = value; } }
        public static PuzzleState GoalNode { get { return Solver._goalNode; } set { Solver._goalNode = value; } }
        public static List<PuzzleState> OpenList { get { return Solver._openList; } set { Solver._openList = value; } }
        public static List<PuzzleState> ClosedList { get { return Solver._closedList; } set { Solver._closedList = value; } }

        static Solver()
        {
            int[] startArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] goalArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Solver.StartNode = new PuzzleState(startArray);
            Solver.GoalNode = new PuzzleState(goalArray);
            Solver.CurrentNode = new PuzzleState(Solver.StartNode);
            Solver.OpenList = new List<PuzzleState>();
            Solver.ClosedList = new List<PuzzleState>();
        }
    }
}
