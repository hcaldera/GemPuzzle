using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GemPuzzleGame
{
    public partial class GemPuzzle : Form
    {
        private static GemPuzzle _instance;
        public GemButton[] gemButtons;

        public GemPuzzle()
        {
            InitializeComponent();
            this.gemButton0.Click += new System.EventHandler(this.gemButton_Click);
            this.gemButton1.Click += new System.EventHandler(this.gemButton_Click);
            this.gemButton2.Click += new System.EventHandler(this.gemButton_Click);
            this.gemButton3.Click += new System.EventHandler(this.gemButton_Click);
            this.gemButton4.Click += new System.EventHandler(this.gemButton_Click);
            this.gemButton5.Click += new System.EventHandler(this.gemButton_Click);
            this.gemButton6.Click += new System.EventHandler(this.gemButton_Click);
            this.gemButton7.Click += new System.EventHandler(this.gemButton_Click);
            this.gemButton8.Click += new System.EventHandler(this.gemButton_Click);
            GemButton[] tmpGemButtons = { this.gemButton0, this.gemButton1, this.gemButton2, this.gemButton3, this.gemButton4, this.gemButton5, this.gemButton6, this.gemButton7, this.gemButton8 };
            this.gemButtons = tmpGemButtons;
        }

        public static GemPuzzle getInstance()
        {
            if (null == GemPuzzle._instance)
            {
                GemPuzzle._instance = new GemPuzzle();
            }
            return GemPuzzle._instance;
        }

        private void gemButton_Click(object sender, EventArgs e)
        {
            GemButton clickedGemButton = sender as GemButton;
            int pos = clickedGemButton.ArrayPosition;
            bool moveUp, moveDown, moveLeft, moveRight;
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

        private void tsbResolve_Click(object sender, EventArgs e)
        {

        }

        private void tsbShuffle_Click(object sender, EventArgs e)
        {

        }

    }
}