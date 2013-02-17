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
        private static byte[] _solutionMoves;
        private static byte _position;
        private static int[] _goalArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static PuzzleState StartNode { get { return Solver._startNode; } set { Solver._startNode = value; } }
        public static PuzzleState CurrentNode { get { return Solver._currentNode; } set { Solver._currentNode = value; } }
        public static PuzzleState GoalNode { get { return Solver._goalNode; } set { Solver._goalNode = value; } }
        public static List<PuzzleState> OpenList { get { return Solver._openList; } set { Solver._openList = value; } }
        public static List<PuzzleState> ClosedList { get { return Solver._closedList; } set { Solver._closedList = value; } }
        public static Actions Action { get { return Solver._action; } set { Solver._action = value; } }
        public static byte[] SolutionMoves { get { return Solver._solutionMoves; } set { Solver._solutionMoves = value; } }
        public static byte Position { get { return Solver._position; } set { Solver._position = value; } }
        public static int[] GoalArray { get { return Solver._goalArray; } set { Solver._goalArray = value; } }

        static Solver()
        {
            int[] startArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Solver.StartNode = new PuzzleState(startArray);
            Solver.GoalNode = new PuzzleState(Solver.GoalArray);
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
                        Solver.findSolution();
                        Solver.Action = Actions.Solved;
                        break;
                    case Actions.Solved:
                        GemPuzzleForm.getInstance().Invoke(new System.Windows.Forms.MethodInvoker(() =>
                        {
                            GemPuzzleForm.getInstance().Moves.Text = "Total Moves: " + (Solver.GoalNode.PreviousMoves.Count - 1).ToString();
                        }));
                        Solver.SolutionMoves = new byte[Solver.GoalNode.PreviousMoves.Count];
                        Solver.GoalNode.PreviousMoves.CopyTo(Solver.SolutionMoves);
                        Solver.Position = 0;
                        Solver.Action = Actions.Explore;
                        break;
                    case Actions.GoToStart:
                        PuzzleState state;
                        if (Solver.Position > 0)
                        {
                            state = Solver.getCurrentState();
                            while (Solver.Position > 0)
                            {
                                state = new PuzzleState(state, Solver.SolutionMoves[--Solver.Position]);
                                Solver.updateTiles(state);
                                Thread.Sleep(100);
                            }
                        }
                        Solver.Action = Actions.Waiting;
                        break;
                    case Actions.GoBackward:
                        if (Solver.Position > 0)
                        {
                            state = Solver.getCurrentState();
                            state = new PuzzleState(state, Solver.SolutionMoves[--Solver.Position]);
                            Solver.updateTiles(state);
                        }
                        Solver.Action = Actions.Waiting;
                        break;
                    case Actions.Explore:
                        Solver.explore(500);
                        Solver.Action = Actions.Waiting;
                        break;
                    case Actions.GoForward:
                        if (Solver.Position < (Solver.SolutionMoves.Length - 1))
                        {
                            state = Solver.getCurrentState();
                            state = new PuzzleState(state, Solver.SolutionMoves[++Solver.Position]);
                            Solver.updateTiles(state);
                        }
                        Solver.Action = Actions.Waiting;
                        break;
                    case Actions.GoToEnd:
                        Solver.explore(100);
                        Solver.Action = Actions.Waiting;
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

            Solver.StartNode = Solver.getCurrentState();
            for (int i = 0; i < 50; i++)
            {
                Solver.StartNode = PuzzleState.SetNextStateRandomly(Solver.StartNode);
                Solver.updateTiles(Solver.StartNode);
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Algorithm A*
        /// f(n) = h(n) + g(n).
        /// Where:
        /// n: is the current state.
        /// f: is the function that decides which state is going to be explored.
        /// h: is the heuristic (the distance from the current state to the goal state.
        /// g: is the cost to get from the start state to the current state n.
        /// </summary>
        private static void findSolution()
        {
            List<PuzzleState> successorNodes;
            int index;
            bool notIgnore;
            int nodesVisited = 0;
            // 1. Create a node containing the goal state (Solver.GoalNode).
            // 2. Create a node containing the start state (Solver.StartNode)
            Solver.StartNode = Solver.getCurrentState();
            // 3. Put the start node on the OpenList.
            Solver.OpenList.Add(Solver.StartNode);
            // 4. While OpenList is not empty.
            while (Solver.OpenList.Count > 0)
            {
                // 5. Get the node off the open list with the lowest f and call it current node (Solver.CurrentNode).
                Solver.CurrentNode = Solver.getBestNodeFromOpenList();
                // 6. If Solver.CurrentNode is the same state as Solver.GoalState we have found the solution; break from the while loop
                if (Solver.GoalNode.IsEqualTo(Solver.CurrentNode))
                {
                    Solver.GoalNode = new PuzzleState(Solver.CurrentNode);
                    Solver.CurrentNode = null;
                    nodesVisited = Solver.ClosedList.Count + 1;
                    Solver.OpenList.Clear();
                    Solver.ClosedList.Clear();
                }
                else
                {
                    // 7. Generate each state that can come after CurrentNode.
                    successorNodes = new List<PuzzleState>(Solver.CurrentNode.ValidMovements.Length);
                    for (int i = 0; i < Solver.CurrentNode.ValidMovements.Length; i++)
                    {
                        successorNodes.Add(new PuzzleState(Solver.CurrentNode, Solver.CurrentNode.ValidMovements[i]));
                    }

                    foreach (PuzzleState state in successorNodes)
                    { // 8. For each successor node of current node:
                        // 9. If successor node is on the Open List but the existing one is a good or better, then disscard this successor and continue.
                        notIgnore = true;
                        index = Solver.searchInList(Solver.OpenList, state);
                        if (index > -1)
                        {
                            if (state.GetFofN() < Solver.OpenList[index].GetFofN())
                            {
                                // 9.1 Remove occurrances of successor node from Open List.
                                Solver.OpenList.RemoveAt(index);
                            }
                            else
                            {
                                notIgnore = false;
                            }
                        }
                        // 10. If successor node is on the Closed List but the existing one is a good or better, then disscard this successor and continue.
                        index = Solver.searchInList(Solver.ClosedList, state);
                        if (index > -1)
                        {
                            if (state.GetFofN() < Solver.ClosedList[index].GetFofN())
                            {
                                // 10.1 Remove occurrances of successor node from Closed List.
                                Solver.ClosedList.RemoveAt(index);
                            }
                            else
                            {
                                notIgnore = false;
                            }
                        }
                        // 11. Add successor node to the Open List.
                        if (notIgnore)
                        {
                            Solver.OpenList.Add(state);
                        }
                    }
                    // 14. Add CurrentNode to the Closed List.
                    Solver.ClosedList.Add(new PuzzleState(Solver.CurrentNode));
                    nodesVisited = Solver.ClosedList.Count;
                }
                GemPuzzleForm.getInstance().Invoke(new System.Windows.Forms.MethodInvoker(() =>
                {
                    GemPuzzleForm.getInstance().Nodes.Text = "Nodes Visited: " + nodesVisited.ToString();
                }));
            }
        }

        private static void explore(int delay)
        {
            GemPuzzleForm oGemPuzzleForm = GemPuzzleForm.getInstance();
            PuzzleState currentState;
            //PuzzleState nextState;
            int[] tmpValues = new int[Constants.InvisibleValue];
            oGemPuzzleForm.Invoke(new System.Windows.Forms.MethodInvoker(() =>
            {
                for (int i = Constants.MinimumValue; i < Constants.InvisibleValue; i++)
                {
                    tmpValues[i] = oGemPuzzleForm.gemButtons[i].Value;
                }
            }));
            currentState = new PuzzleState(tmpValues);
            while (Solver.Position < (Solver.SolutionMoves.Length - 1))
            {
                currentState = new PuzzleState(currentState, Solver.SolutionMoves[++Solver.Position]);
                Solver.updateTiles(currentState);
                Thread.Sleep(delay);
            }
            oGemPuzzleForm.Invoke(new System.Windows.Forms.MethodInvoker(() =>
            {
                oGemPuzzleForm.ControlButtons = true;
            }));
        }

        private static PuzzleState getCurrentState()
        {
            GemPuzzleForm oGemPuzzleForm;
            PuzzleState state;
            int[] currentArray = new int[Constants.InvisibleValue];
            oGemPuzzleForm = GemPuzzleForm.getInstance();
            oGemPuzzleForm.Invoke(new System.Windows.Forms.MethodInvoker(() =>
            {
                for (int i = Constants.MinimumValue; i < Constants.InvisibleValue; i++)
                {
                    currentArray[i] = oGemPuzzleForm.gemButtons[i].Value;
                }
            }));
            state = new PuzzleState(currentArray);
            return state;
        }

        private static void updateTiles(PuzzleState state)
        {
            GemPuzzleForm.getInstance().Invoke(new System.Windows.Forms.MethodInvoker(() =>
            {
                for (int j = Constants.MinimumValue; j < Constants.InvisibleValue; j++)
                {
                    GemPuzzleForm.getInstance().gemButtons[j].Value = state.Values[j];
                }
            }));
        }

        private static PuzzleState getBestNodeFromOpenList()
        {
            PuzzleState bestState;
            int index = 0;
            if (Solver.OpenList.Count > 1)
            {
                for (int i = 1; i < Solver.OpenList.Count; i++)
                {
                    if ((Solver.OpenList[i].GetFofN()) < Solver.OpenList[index].GetFofN())
                    {
                        index = i;
                    }
                }
            }
            bestState = new PuzzleState(Solver.OpenList[index]);
            Solver.OpenList.RemoveAt(index);
            return bestState;
        }

        private static int searchInList(List<PuzzleState> list, PuzzleState state)
        {
            int index = -1;
            for (int i = 0; (i < list.Count) && (index == -1); i++)
            {
                if (list[i].IsEqualTo(state))
                {
                    index = i;
                }
            }
            return index;
        }
    }

    public enum Actions
    {
        None,
        Solving,
        Shuffling,
        Solved,
        Waiting,
        Explore,
        GoToStart,
        GoBackward,
        GoForward,
        GoToEnd
    }
}
