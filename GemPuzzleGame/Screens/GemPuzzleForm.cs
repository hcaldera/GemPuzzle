using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GemPuzzleGame.Puzzle;

namespace GemPuzzleGame
{
    public partial class GemPuzzleForm : Form
    {
        private static GemPuzzleForm _instance;
        public GemButton[] gemButtons;
        public ToolStripStatusLabel Nodes { get { return this.sslNodes; } set { this.sslNodes = value; } }
        public ToolStripStatusLabel Moves { get { return this.sslMoves; } set { this.sslMoves = value; } }

        public bool MainButtons
        {
            set
            {
                this.tsbResolve.Enabled = value;
                this.tsbShuffle.Enabled = value;
            }
        }
        public bool ControlButtons
        { 
            set
            {
                this.tsbStart.Enabled = value;
                this.tsbBackward.Enabled = value;
                this.tsbPlay.Enabled = value;
                this.tsbStop.Enabled = value;
                this.tsbForward.Enabled = value;
                this.tsbEnd.Enabled = value;
            }
        }

        public GemPuzzleForm()
        {
            InitializeComponent();
            GemButton[] tmpGemButtons = { this.gemButton0, this.gemButton1, this.gemButton2, this.gemButton3, this.gemButton4, this.gemButton5, this.gemButton6, this.gemButton7, this.gemButton8 };
            this.gemButtons = tmpGemButtons;
            for (int i = Constants.MinimumValue; i < Constants.InvisibleValue; i++)
            {
                this.gemButtons[i].Click += new System.EventHandler(this.gemButton_Click);
                this.gemButtons[i].ArrayPosition = i;
                this.gemButtons[i].Value = Solver.StartNode.Values[i];
            }
        }

        public static GemPuzzleForm getInstance()
        {
            if (null == GemPuzzleForm._instance)
            {
                GemPuzzleForm._instance = new GemPuzzleForm();
            }
            return GemPuzzleForm._instance;
        }

        private void gemButton_Click(object sender, EventArgs e)
        {
            GemButton clickedGemButton = sender as GemButton;
            int pos = clickedGemButton.ArrayPosition;
            bool moveUp, moveDown, moveLeft, moveRight;
            if (Actions.None == Solver.Action)
            {
                moveUp = ((pos - 3) > -1) && (Constants.InvisibleValue == this.gemButtons[pos - 3].Value);
                moveDown = ((pos + 3) < 9) && (Constants.InvisibleValue == this.gemButtons[pos + 3].Value);
                moveLeft = ((pos % 3) > 0) && (Constants.InvisibleValue == this.gemButtons[pos - 1].Value);
                moveRight = ((pos % 3) < 2) && (Constants.InvisibleValue == this.gemButtons[pos + 1].Value);

                if (moveUp)
                {
                    this.gemButtons[pos - 3].Value = clickedGemButton.Value;
                    clickedGemButton.Value = Constants.InvisibleValue;
                    this.gemButtons[pos - 3].Focus();
                }
                else if (moveDown)
                {
                    this.gemButtons[pos + 3].Value = clickedGemButton.Value;
                    clickedGemButton.Value = Constants.InvisibleValue;
                    this.gemButtons[pos + 3].Focus();
                }
                else if (moveLeft)
                {
                    this.gemButtons[pos - 1].Value = clickedGemButton.Value;
                    clickedGemButton.Value = Constants.InvisibleValue;
                    this.gemButtons[pos - 1].Focus();
                }
                else if (moveRight)
                {
                    this.gemButtons[pos + 1].Value = clickedGemButton.Value;
                    clickedGemButton.Value = Constants.InvisibleValue;
                    this.gemButtons[pos + 1].Focus();
                }
            }
        }

        private void tsbResolve_Click(object sender, EventArgs e)
        {
            if (Actions.None == Solver.Action)
            {
                this.MainButtons = false;
                this.ControlButtons = false;
                Solver.Action = Actions.Solving;
            }
        }

        private void tsbShuffle_Click(object sender, EventArgs e)
        {
            int[] currentArray = new int[Constants.InvisibleValue];
            if (Actions.None == Solver.Action)
            {
                Solver.Action = Actions.Shuffling;
            }
        }

        private void GemPuzzleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((Actions.None != Solver.Action) && (Actions.Waiting != Solver.Action))
            {
                e.Cancel = true;
            }
        }

        private void tsbStart_Click(object sender, EventArgs e)
        {
            if (Actions.Waiting == Solver.Action)
            {
                Solver.Action = Actions.GoToStart;
            }
        }

        private void tsbBackward_Click(object sender, EventArgs e)
        {
            if (Actions.Waiting == Solver.Action)
            {
                Solver.Action = Actions.GoBackward;
            }
        }

        private void tsbPlay_Click(object sender, EventArgs e)
        {
            if (Actions.Waiting == Solver.Action)
            {
                Solver.Action = Actions.Explore;
            }
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            if (Actions.Waiting == Solver.Action)
            {
                this.MainButtons = true;
                this.ControlButtons = false;
                this.sslMoves.Text = "";
                this.sslNodes.Text = "";
                Solver.GoalNode = new PuzzleState(Solver.GoalArray);
                Solver.Action = Actions.None;
            }
        }

        private void tsbForward_Click(object sender, EventArgs e)
        {
            if (Actions.Waiting == Solver.Action)
            {
                Solver.Action = Actions.GoForward;
            }
        }

        private void tsbEnd_Click(object sender, EventArgs e)
        {
            if (Actions.Waiting == Solver.Action)
            {
                Solver.Action = Actions.GoToEnd;
            }
        }
    }
}