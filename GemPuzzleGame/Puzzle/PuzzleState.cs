using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GemPuzzleGame.Puzzle
{
    public class PuzzleState
    {
        private int _lastMovement;
        private int _nonVisiblePosition;
        private int[] _values;
        private int _heuristic2;
        private int _cost;
        private int[] _validMovementsPositions;

        public int LastMovement { get { return this._lastMovement; } set { this._lastMovement = value; } }
        public int NonVisiblePosition { get { return this._nonVisiblePosition; } set { this._nonVisiblePosition = value; } }
        public int[] Values { get { return this._values; } set { this._values = value; } }
        public int Heuristic2 { get { return this._heuristic2; } set { this._heuristic2 = value; } }
        public int Cost { get { return this._cost; } set { this._cost = value; } }
        public int[] ValidMovements { get { return this._validMovementsPositions; } set { this._validMovementsPositions = value; } }

        public PuzzleState(int[] values)
        {
            this.NonVisiblePosition = Constants.MinimumValue;
            this.Values = new int[values.Length];
            values.CopyTo(this.Values, 0);
            while (values[this.NonVisiblePosition] != Constants.InvisibleValue)
            {
                this.NonVisiblePosition++;
            }
            this.LastMovement = -1;
            this.Heuristic2 = getHeuristic2();
            this.Cost = 0;
            this.setValidMovements();
        }

        public PuzzleState(PuzzleState state)
        {
            this.NonVisiblePosition = state.NonVisiblePosition;
            this.Values = new int[state.Values.Length];
            state.Values.CopyTo(this.Values, 0);
            this.LastMovement = state.LastMovement;
            this.Heuristic2 = state.Heuristic2;
            this.Cost = state.Cost;
            this.ValidMovements = new int[state.ValidMovements.Length];
            state.ValidMovements.CopyTo(this.ValidMovements, 0);
        }

        public PuzzleState(PuzzleState state, int nextMovePosition)
        {
            int nonVisiblePos = Constants.MinimumValue;

            state.Values.CopyTo(this.Values, 0);
            while (state.Values[nonVisiblePos] != Constants.InvisibleValue)
            {
                nonVisiblePos++;
            }
            this.LastMovement = nonVisiblePos;
            this.NonVisiblePosition = nextMovePosition;
            this.Values[nonVisiblePos] = this.Values[nextMovePosition];
            this.Values[nextMovePosition] = Constants.InvisibleValue;
            this.Heuristic2 = getHeuristic2(); 
            this.Cost = state.Cost + 1;
            this.setValidMovements();
        }

        public PuzzleState(int[] values, int nextMovePosition, int cost)
        {
            int nonVisiblePos = Constants.MinimumValue;

            values.CopyTo(this.Values, 0);
            while (values[nonVisiblePos] != Constants.InvisibleValue)
            {
                nonVisiblePos++;
            }
            this.LastMovement = nonVisiblePos;
            this.NonVisiblePosition = nextMovePosition;
            this.Values[nonVisiblePos] = this.Values[nextMovePosition];
            this.Values[nextMovePosition] = Constants.InvisibleValue;
            this.Heuristic2 = getHeuristic2(); 
            this.Cost = cost + 1;
            this.setValidMovements();
        }

        private void setValidMovements()
        {
            int[] tmpValidMovements = new int[4];
            int validMovements = 0;

            // Up
            if ((this.NonVisiblePosition - 3) >= Constants.MinimumValue)
            {
                if ((this.NonVisiblePosition - 3) != this.LastMovement)
                {
                    tmpValidMovements[validMovements] = this.NonVisiblePosition - 3;
                    validMovements++;
                }
            }
            // Down
            if ((this.NonVisiblePosition + 3) < Constants.InvisibleValue)
            {
                if ((this.NonVisiblePosition + 3) != this.LastMovement)
                {
                    tmpValidMovements[validMovements] = this.NonVisiblePosition + 3;
                    validMovements++;
                }
            }
            // Left
            if ((this.NonVisiblePosition % 3) != 0)
            {
                if ((this.NonVisiblePosition - 1) != this.LastMovement)
                {
                    tmpValidMovements[validMovements] = this.NonVisiblePosition - 1;
                    validMovements++;
                }
            }
            // Right
            if ((this.NonVisiblePosition % 3) != 2)
            {
                if ((this.NonVisiblePosition + 1) != this.LastMovement)
                {
                    tmpValidMovements[validMovements] = this.NonVisiblePosition + 1;
                    validMovements++;
                }
            }

            this.ValidMovements = new int[validMovements];
            for (int i = 0; i < validMovements; i++)
            {
                this.ValidMovements[i] = tmpValidMovements[i];
            }
        }

        private int getHeuristic2()
        {
            Tile currentValue;
            Tile expectedValue;
            int heuristic2;

            heuristic2 = 0;
            for (int i = Constants.MinimumValue; i < Constants.InvisibleValue; i++)
            {
                currentValue = new Tile(this.Values[i]);
                expectedValue = new Tile(i + 1);
                heuristic2 += Tile.getCost(currentValue, expectedValue);
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