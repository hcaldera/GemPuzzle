using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GemPuzzleGame.Puzzle
{
    public class PuzzleState
    {
        private int _lastMovement;
        private byte _nonVisiblePosition;
        private int[] _values;
        private int _heuristic1;
        private int _heuristic2;
        private int _cost;
        private List<byte> _previousMoves;
        private byte[] _validMovementsPositions;

        public int LastMovement { get { return this._lastMovement; } set { this._lastMovement = value; } }
        public byte NonVisiblePosition { get { return this._nonVisiblePosition; } set { this._nonVisiblePosition = value; } }
        public int[] Values { get { return this._values; } set { this._values = value; } }
        public int Heuristic1 { get { return this._heuristic1; } set { this._heuristic1 = value; } }
        public int Heuristic2 { get { return this._heuristic2; } set { this._heuristic2 = value; } }
        public int Cost { get { return this._cost; } set { this._cost = value; } }
        public List<byte> PreviousMoves { get { return this._previousMoves; } set { this._previousMoves = value; } }
        public byte[] ValidMovements { get { return this._validMovementsPositions; } set { this._validMovementsPositions = value; } }

        public PuzzleState(int[] values)
        {
            this.NonVisiblePosition = Constants.MinimumValue;
            this.Values = new int[values.Length];
            values.CopyTo(this.Values, 0);
            while ((this.NonVisiblePosition < Constants.InvisibleValue) && (values[this.NonVisiblePosition] != Constants.InvisibleValue))
            {
                this.NonVisiblePosition++;
            }
            this.LastMovement = -1;
            this.Heuristic1 = getHeuristic1();
            this.Heuristic2 = getHeuristic2();
            this.Cost = 0;
            this.PreviousMoves = new List<byte>();
            this.PreviousMoves.Add(this.NonVisiblePosition);
            this.setValidMovements();
        }

        public PuzzleState(PuzzleState state)
        {
            this.NonVisiblePosition = state.NonVisiblePosition;
            this.Values = new int[state.Values.Length];
            state.Values.CopyTo(this.Values, 0);
            this.LastMovement = state.LastMovement;
            this.Heuristic1 = state.Heuristic1;
            this.Heuristic2 = state.Heuristic2;
            this.Cost = state.Cost;
            this.PreviousMoves = new List<byte>(state.PreviousMoves);
            this.ValidMovements = new byte[state.ValidMovements.Length];
            state.ValidMovements.CopyTo(this.ValidMovements, 0);
        }

        public PuzzleState(PuzzleState state, byte nextMovePosition)
        {
            this.Values = new int[Constants.InvisibleValue];
            state.Values.CopyTo(this.Values, 0);
            this.LastMovement = state.NonVisiblePosition;
            this.NonVisiblePosition = nextMovePosition;
            this.Values[this.LastMovement] = this.Values[nextMovePosition];
            this.Values[nextMovePosition] = Constants.InvisibleValue;
            this.Heuristic1 = getHeuristic1();
            this.Heuristic2 = getHeuristic2(); 
            this.Cost = state.Cost + 1;
            this.PreviousMoves = new List<byte>(state.PreviousMoves);
            this.PreviousMoves.Add(nextMovePosition);
            this.setValidMovements();
        }

        private PuzzleState(int[] values, byte nextMovePosition)
        {
            int nonVisiblePos = Constants.MinimumValue;
            this.Values = new int[Constants.InvisibleValue];
            values.CopyTo(this.Values, 0);
            while (values[nonVisiblePos] != Constants.InvisibleValue)
            {
                nonVisiblePos++;
            }
            this.LastMovement = nonVisiblePos;
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

        public static PuzzleState SetNextStateRandomly(PuzzleState state)
        {
            PuzzleState tmpState;
            Random nextMove = new Random(DateTime.Now.Millisecond);
            int index = nextMove.Next(0, state.ValidMovements.Length);
            tmpState = new PuzzleState(state.Values, state.ValidMovements[index]);
            return tmpState;
        }

        public int GetFofN()
        {
            // f(n) = h(n) + g(n)
            //return this.Heuristic1 + this.Cost; // h(n) = h1
            return this.Heuristic2 + this.Cost; // h(n) = h2
            //return this.Heuristic1 + this.Heuristic2 + this.Cost; // h(n) = h1 + h2
        }

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
                if ((this.NonVisiblePosition - 3) != this.LastMovement)
                {
                    tmpValidMovements[validMovements] = (byte)(this.NonVisiblePosition - 3);
                    validMovements++;
                }
            }
            // Down
            if ((this.NonVisiblePosition + 3) < Constants.InvisibleValue)
            {
                if ((this.NonVisiblePosition + 3) != this.LastMovement)
                {
                    tmpValidMovements[validMovements] = (byte)(this.NonVisiblePosition + 3);
                    validMovements++;
                }
            }
            // Left
            if ((this.NonVisiblePosition % 3) != 0)
            {
                if ((this.NonVisiblePosition - 1) != this.LastMovement)
                {
                    tmpValidMovements[validMovements] = (byte)(this.NonVisiblePosition - 1);
                    validMovements++;
                }
            }
            // Right
            if ((this.NonVisiblePosition % 3) != 2)
            {
                if ((this.NonVisiblePosition + 1) != this.LastMovement)
                {
                    tmpValidMovements[validMovements] = (byte)(this.NonVisiblePosition + 1);
                    validMovements++;
                }
            }

            this.ValidMovements = new byte[validMovements];
            for (int i = 0; i < validMovements; i++)
            {
                this.ValidMovements[i] = tmpValidMovements[i];
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

        public Tile(int position)
        {
            this.X = (position - 1) / 3;
            this.Y = (position - 1) % 3;
        }

        public static int getCost(Tile tile1, Tile tile2)
        {
            return Math.Abs(tile1.X - tile2.X) + Math.Abs(tile1.Y - tile2.Y);
        }
    }
}