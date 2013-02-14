using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
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
        private static Thread solverThread;
        private static Actions _action;

        public static PuzzleState StartNode { get { return Solver._startNode; } set { Solver._startNode = value; } }
        public static PuzzleState CurrentNode { get { return Solver._currentNode; } set { Solver._currentNode = value; } }
        public static PuzzleState GoalNode { get { return Solver._goalNode; } set { Solver._goalNode = value; } }
        public static List<PuzzleState> OpenList { get { return Solver._openList; } set { Solver._openList = value; } }
        public static List<PuzzleState> ClosedList { get { return Solver._closedList; } set { Solver._closedList = value; } }
        public static Actions Action { get { return Solver._action; } set { Solver._action = value; } }

        static Solver()
        {
            int[] startArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] goalArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Solver.StartNode = new PuzzleState(startArray);
            Solver.GoalNode = new PuzzleState(goalArray);
            Solver.CurrentNode = new PuzzleState(Solver.StartNode);
            Solver.OpenList = new List<PuzzleState>();
            Solver.ClosedList = new List<PuzzleState>();
            Solver.Action = Actions.None;
            Solver.solverThread  = new Thread(Solver.main);
            Solver.solverThread.IsBackground = true;
            Solver.solverThread.Start();
        }

        private static void main()
        {
            while (true)
            {
                switch (Solver.Action)
                {
                    case Actions.Shuffling:
                        Solver.shuffleTiles();
                        Solver.Action = Actions.None;
                        break;
                    case Actions.Solving:
                        Solver.initializeStartNode();
                        Thread.Sleep(3000);
                        Solver.Action = Actions.None;
                        break;
                    default:
                        // Do nothing.
                        break;
                }
            }
        }

        private static void shuffleTiles()
        {
            GemPuzzleForm oGemPuzzleForm = GemPuzzleForm.getInstance();

            Solver.initializeStartNode();
            for (int i = 0; i < 25; i++)
            {
                Solver.StartNode = PuzzleState.setNextStateRandomly(Solver.StartNode);
                oGemPuzzleForm.Invoke(new System.Windows.Forms.MethodInvoker(() =>
                {
                    for (int j = Constants.MinimumValue; j < Constants.InvisibleValue; j++)
                    {
                        oGemPuzzleForm.gemButtons[j].Value = Solver.StartNode.Values[j];
                    }
                }));
                Thread.Sleep(500);
            }
        }

        private static void findSolution()
        {

        }

        private static void initializeStartNode()
        {
            GemPuzzleForm oGemPuzzleForm;
            int[] currentArray = new int[Constants.InvisibleValue];
            oGemPuzzleForm = GemPuzzleForm.getInstance();
            oGemPuzzleForm.Invoke(new System.Windows.Forms.MethodInvoker(() =>
            {
                for (int i = Constants.MinimumValue; i < Constants.InvisibleValue; i++)
                {
                    currentArray[i] = oGemPuzzleForm.gemButtons[i].Value;
                }
            }));
            Solver.StartNode = new PuzzleState(currentArray);
        }
    }

    public enum Actions
    {
        None,
        Solving,
        Shuffling
    }
}
