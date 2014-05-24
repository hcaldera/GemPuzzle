using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GemPuzzleGame.Puzzle
{
    public class PuzzleState
    {
        private int _lastMove;
        private byte _nonVisiblePosition;
        private int[] _values;
        private int _heuristic1;
        private int _heuristic2;
        private int _cost;
        private List<byte> _previousMoves;
        private byte[] _validMoves;

        /// <summary>Holds the last move (array position changed) to get to the current state.</summary>
        public int LastMove { get { return this._lastMove; } set { this._lastMove = value; } }
        /// <summary>Holds the position in the puzzle that will be hollow.</summary>
        public byte NonVisiblePosition { get { return this._nonVisiblePosition; } set { this._nonVisiblePosition = value; } }
        /// <summary>
        /// An array holding the values of each button, counting from left to right and top to bottom.
        /// The value is the number showed to the final user.
        /// </summary>
        public int[] Values { get { return this._values; } set { this._values = value; } }
        /// <summary>The value of h_1(n) (How many tiles are in their correct position.)</summary>
        public int Heuristic1 { get { return this._heuristic1; } set { this._heuristic1 = value; } }
        /// <summary>Hold h_2(n) (Manhattan Algorithm is used to get this)</summary>
        public int Heuristic2 { get { return this._heuristic2; } set { this._heuristic2 = value; } }
        /// <summary>How many moves it took to gef from the StartNode to the CurrentNode.</summary>
        public int Cost { get { return this._cost; } set { this._cost = value; } }
        /// <summary>Collection containing the moves made to get to the CurrentNode from the StartNode</summary>
        public List<byte> PreviousMoves { get { return this._previousMoves; } set { this._previousMoves = value; } }
        /// <summary>Array containing the allowed moves to get to a next possible stte.</summary>
        public byte[] ValidMoves { get { return this._validMoves; } set { this._validMoves = value; } }

        /// <summary>
        /// This constructor is used to create the first state from which all next states are to be created.
        /// </summary>
        /// <param name="values">An array containing the value of each tile in the puzzle.</param>
        public PuzzleState(int[] values)
        {
            this.NonVisiblePosition = Constants.MinimumValue;
            this.Values = new int[values.Length];
            values.CopyTo(this.Values, 0);
            while ((this.NonVisiblePosition < Constants.InvisibleValue) && (values[this.NonVisiblePosition] != Constants.InvisibleValue))
            {
                this.NonVisiblePosition++;
            }
            this.LastMove = -1;
            this.Heuristic1 = getHeuristic1();
            this.Heuristic2 = getHeuristic2();
            this.Cost = 0;
            this.PreviousMoves = new List<byte>();
            this.PreviousMoves.Add(this.NonVisiblePosition);
            this.setValidMovements();
        }

        /// <summary>
        /// This constructor is used when it is only necessary to create a copy ot the current state in the puzzle.
        /// </summary>
        public PuzzleState(PuzzleState state)
        {
            this.NonVisiblePosition = state.NonVisiblePosition;
            this.Values = new int[state.Values.Length];
            state.Values.CopyTo(this.Values, 0);
            this.LastMove = state.LastMove;
            this.Heuristic1 = state.Heuristic1;
            this.Heuristic2 = state.Heuristic2;
            this.Cost = state.Cost;
            this.PreviousMoves = new List<byte>(state.PreviousMoves);
            this.ValidMoves = new byte[state.ValidMoves.Length];
            state.ValidMoves.CopyTo(this.ValidMoves, 0);
        }

        /// <summary>
        /// This constructor creates a new state, and updates cost, heuristic, none visible position, etc.
        /// </summary>
        /// <param name="state">This is the parent node</param>
        /// <param name="nextMovePosition">This is the position in the array that actually creates the new state.</param>
        public PuzzleState(PuzzleState state, byte nextMovePosition)
        {
            this.Values = new int[Constants.InvisibleValue];
            state.Values.CopyTo(this.Values, 0);
            this.LastMove = state.NonVisiblePosition;
            this.NonVisiblePosition = nextMovePosition;
            this.Values[this.LastMove] = this.Values[nextMovePosition];
            this.Values[nextMovePosition] = Constants.InvisibleValue;
            this.Heuristic1 = getHeuristic1();
            this.Heuristic2 = getHeuristic2(); 
            this.Cost = state.Cost + 1;
            this.PreviousMoves = new List<byte>(state.PreviousMoves);
            this.PreviousMoves.Add(nextMovePosition);
            this.setValidMovements();
        }

        /// <summary>
        /// Private constructor used only to shuffle the state, no need to track on movements.
        /// </summary>
        /// <param name="values">Array containing the values of each tile.</param>
        /// <param name="nextMovePosition">The position in the array that will move.</param>
        private PuzzleState(int[] values, byte nextMovePosition)
        {
            int nonVisiblePos = Constants.MinimumValue;
            this.Values = new int[Constants.InvisibleValue];
            values.CopyTo(this.Values, 0);
            while (values[nonVisiblePos] != Constants.InvisibleValue)
            {
                nonVisiblePos++;
            }
            this.LastMove = nonVisiblePos;
            this.NonVisiblePosition = nextMovePosition;
            this.Values[nonVisiblePos] = this.Values[nextMovePosition];
            this.Values[nextMovePosition] = Constants.InvisibleValue;
            this.Heuristic1 = getHeuristic1();
            this.Heuristic2 = getHeuristic2(); 
            this.Cost = 0;
            this.PreviousMoves = new List<byte>();
            this.PreviousMoves.Add(this.NonVisiblePosition);
            this.setValidMovements();
        }

        /// <summary>
        /// Given a state, it calculates a new state randomly.
        /// </summary>
        /// <param name="state">The state containing the next possible and valid moves.</param>
        /// <returns>A state created randomly from a given state.</returns>
        public static PuzzleState SetNextStateRandomly(PuzzleState state)
        {
            PuzzleState tmpState;
            Random nextMove = new Random(DateTime.Now.Millisecond);
            int index = nextMove.Next(0, state.ValidMoves.Length);
            tmpState = new PuzzleState(state.Values, state.ValidMoves[index]);
            return tmpState;
        }

        /// <summary>
        /// Gets f(n) = h(n) + g(n)
        /// </summary>
        /// <returns>The sum of the heuristic and cost.</returns>
        public int GetFofN()
        {
            // f(n) = h(n) + g(n)
            //return this.Heuristic1 + this.Cost; // h(n) = h1
            return this.Heuristic2 + this.Cost; // h(n) = h2
            //return this.Heuristic1 + this.Heuristic2 + this.Cost; // h(n) = h1 + h2
        }

        /// <summary>
        /// Checks if two states have the same value arrangement (the tiles).
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool IsEqualTo(PuzzleState state)
        {
            bool equals = false;
            if ((state.Heuristic2 == this.Heuristic2) && (state.Heuristic1 == this.Heuristic1))
            {
                equals = true;
                for (int i = Constants.MinimumValue; (i < Constants.InvisibleValue) && equals; i++)
                {
                    if (state.Values[i] != this.Values[i])
                    {
                        equals = false;
                    }
                }
            }
            return equals;
        }

        private void setValidMovements()
        {
            byte[] tmpValidMovements = new byte[4];
            byte validMovements = 0;

            // Up
            if ((this.NonVisiblePosition - 3) >= Constants.MinimumValue)
            {
                if ((this.NonVisiblePosition - 3) != this.LastMove)
                {
                    tmpValidMovements[validMovements] = (byte)(this.NonVisiblePosition - 3);
                    validMovements++;
                }
            }
            // Down
            if ((this.NonVisiblePosition + 3) < Constants.InvisibleValue)
            {
                if ((this.NonVisiblePosition + 3) != this.LastMove)
                {
                    tmpValidMovements[validMovements] = (byte)(this.NonVisiblePosition + 3);
                    validMovements++;
                }
            }
            // Left
            if ((this.NonVisiblePosition % 3) != 0)
            {
                if ((this.NonVisiblePosition - 1) != this.LastMove)
                {
                    tmpValidMovements[validMovements] = (byte)(this.NonVisiblePosition - 1);
                    validMovements++;
                }
            }
            // Right
            if ((this.NonVisiblePosition % 3) != 2)
            {
                if ((this.NonVisiblePosition + 1) != this.LastMove)
                {
                    tmpValidMovements[validMovements] = (byte)(this.NonVisiblePosition + 1);
                    validMovements++;
                }
            }

            this.ValidMoves = new byte[validMovements];
            for (int i = 0; i < validMovements; i++)
            {
                this.ValidMoves[i] = tmpValidMovements[i];
            }
        }

        private int getHeuristic1()
        {
            int heuristic1 = 0;
            for (int i = 0; i < Constants.InvisibleValue; i++)
            {
                if ((this.Values[i] != Constants.InvisibleValue) && (this.Values[i] != Solver.GoalArray[i]))
                {
                    heuristic1++;
                }
            }
            return heuristic1;
        }

        private int getHeuristic2()
        {
            Tile currentValue;
            Tile expectedValue;
            int heuristic2;

            heuristic2 = 0;
            for (int i = Constants.MinimumValue; i < Constants.InvisibleValue; i++)
            {
                if (this.Values[i] < Constants.InvisibleValue)
                {
                    currentValue = new Tile(this.Values[i]);
                    expectedValue = new Tile(Solver.GoalArray[i]);
                    heuristic2 += Tile.getCost(currentValue, expectedValue);
                }
            }
            return heuristic2;
        }
    }

    internal class Tile
    {
        internal int X;
        internal int Y;

        internal Tile(int position)
        {
            this.X = (position - 1) / 3;
            this.Y = (position - 1) % 3;
        }

        internal static int getCost(Tile tile1, Tile tile2)
        {
            return Math.Abs(tile1.X - tile2.X) + Math.Abs(tile1.Y - tile2.Y);
        }
    }
}