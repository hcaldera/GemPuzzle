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
        private int _heuristic;
        private int[] _validMovementsPositions;
        private ChildState[] _children;

        public int LastMovement { get { return this._lastMovement; } set { this._lastMovement = value; } }
        public int NonVisiblePosition { get { return this._nonVisiblePosition; } set { this._nonVisiblePosition = value; } }
        public int[] Values { get { return this._values; } set { this._values = value; } }
        public int Heuristic { get { return this._heuristic; } set { this._heuristic = value; } }
        public int[] ValidMovements { get { return this._validMovementsPositions; } set { this._validMovementsPositions = value; } }
        public ChildState[] Children { get { return this._children; } set { this._children = value; } }

        public PuzzleState(int[] values, int nextMovementPos, int nonVisiblePos)
        {
            this.LastMovement = nonVisiblePos;
            this.NonVisiblePosition = nextMovementPos;
            values.CopyTo(this.Values, 0);
            this.Values[nonVisiblePos] = this.Values[nextMovementPos];
            this.Values[nextMovementPos] = Constants.InvisibleValue;

        }
    }

    internal class ChildState
    {
        private int _heuristic;
        public int Heuristic { get { return this._heuristic; } set { this._heuristic = value; } }

        ChildState(int[] values, int nextMovement, int nonVisiblePos)
        {
            Point currentValue;
            Point expectedValue;
            int[] tmpValues = new int[values.Length];
            this.Heuristic = 0;
            values.CopyTo(tmpValues, 0);
            for (int i = Constants.MinimumValue; i < Constants.InvisibleValue; i++)
            {
                currentValue = Point.getPoint(values[i]);
                expectedValue = Point.getPoint(i);
                this.Heuristic += Point.getCost(currentValue, expectedValue);
            }
        }
    }

    internal class Point
    {
        private int x;
        private int y;
        public int X { get { return this.x; } set { this.x = value; } }
        public int Y { get { return this.y; } set { this.y = value; } }

        private Point(int position)
        {
            this.X = position / 3;
            this.Y = position % 3;
        }

        public static Point getPoint(int position)
        {
            Point tmpPoint = null;
            if ((position > Constants.InvalidValue) && (position < Constants.InvisibleValue))
            {
                tmpPoint = new Point(position);
            }
            return tmpPoint;
        }

        public static int getCost(Point current, Point expected)
        {
            int cost = 0;
            cost = Math.Abs(current.X - expected.X) + Math.Abs(current.Y - expected.Y);
            return cost;
        }
    }
}