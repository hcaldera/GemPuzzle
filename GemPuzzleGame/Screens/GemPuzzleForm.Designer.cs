namespace GemPuzzleGame
{
    partial class GemPuzzleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GemPuzzleForm));
            this.tsGemPuzzle = new System.Windows.Forms.ToolStrip();
            this.tsbResolve = new System.Windows.Forms.ToolStripButton();
            this.tsbShuffle = new System.Windows.Forms.ToolStripButton();
            this.tsbStart = new System.Windows.Forms.ToolStripButton();
            this.tsbBackward = new System.Windows.Forms.ToolStripButton();
            this.tsbPlay = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tslMessage = new System.Windows.Forms.ToolStripLabel();
            this.tsbForward = new System.Windows.Forms.ToolStripButton();
            this.tsbEnd = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslNodes = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslMoves = new System.Windows.Forms.ToolStripStatusLabel();
            this.gemButton8 = new GemPuzzleGame.GemButton();
            this.gemButton7 = new GemPuzzleGame.GemButton();
            this.gemButton6 = new GemPuzzleGame.GemButton();
            this.gemButton5 = new GemPuzzleGame.GemButton();
            this.gemButton4 = new GemPuzzleGame.GemButton();
            this.gemButton3 = new GemPuzzleGame.GemButton();
            this.gemButton2 = new GemPuzzleGame.GemButton();
            this.gemButton1 = new GemPuzzleGame.GemButton();
            this.gemButton0 = new GemPuzzleGame.GemButton();
            this.tsGemPuzzle.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsGemPuzzle
            // 
            this.tsGemPuzzle.BackColor = System.Drawing.Color.Gainsboro;
            this.tsGemPuzzle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbResolve,
            this.tsbShuffle,
            this.tsbStart,
            this.tsbBackward,
            this.tsbPlay,
            this.tsbStop,
            this.tslMessage,
            this.tsbForward,
            this.tsbEnd});
            this.tsGemPuzzle.Location = new System.Drawing.Point(0, 0);
            this.tsGemPuzzle.Name = "tsGemPuzzle";
            this.tsGemPuzzle.Size = new System.Drawing.Size(275, 25);
            this.tsGemPuzzle.TabIndex = 1;
            this.tsGemPuzzle.Text = "toolStrip1";
            // 
            // tsbResolve
            // 
            this.tsbResolve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbResolve.Image = ((System.Drawing.Image)(resources.GetObject("tsbResolve.Image")));
            this.tsbResolve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbResolve.Name = "tsbResolve";
            this.tsbResolve.Size = new System.Drawing.Size(23, 22);
            this.tsbResolve.Text = "Resolve";
            this.tsbResolve.Click += new System.EventHandler(this.tsbResolve_Click);
            // 
            // tsbShuffle
            // 
            this.tsbShuffle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShuffle.Image = ((System.Drawing.Image)(resources.GetObject("tsbShuffle.Image")));
            this.tsbShuffle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShuffle.Name = "tsbShuffle";
            this.tsbShuffle.Size = new System.Drawing.Size(23, 22);
            this.tsbShuffle.Text = "Shuffle";
            this.tsbShuffle.Click += new System.EventHandler(this.tsbShuffle_Click);
            // 
            // tsbStart
            // 
            this.tsbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStart.Enabled = false;
            this.tsbStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbStart.Image")));
            this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStart.Name = "tsbStart";
            this.tsbStart.Size = new System.Drawing.Size(23, 22);
            this.tsbStart.Text = "Start";
            this.tsbStart.Click += new System.EventHandler(this.tsbStart_Click);
            // 
            // tsbBackward
            // 
            this.tsbBackward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBackward.Enabled = false;
            this.tsbBackward.Image = ((System.Drawing.Image)(resources.GetObject("tsbBackward.Image")));
            this.tsbBackward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBackward.Name = "tsbBackward";
            this.tsbBackward.Size = new System.Drawing.Size(23, 22);
            this.tsbBackward.Text = "Backward";
            this.tsbBackward.Click += new System.EventHandler(this.tsbBackward_Click);
            // 
            // tsbPlay
            // 
            this.tsbPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPlay.Enabled = false;
            this.tsbPlay.Image = ((System.Drawing.Image)(resources.GetObject("tsbPlay.Image")));
            this.tsbPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlay.Name = "tsbPlay";
            this.tsbPlay.Size = new System.Drawing.Size(23, 22);
            this.tsbPlay.Text = "Play";
            this.tsbPlay.Click += new System.EventHandler(this.tsbPlay_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStop.Enabled = false;
            this.tsbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStop.Image")));
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(23, 22);
            this.tsbStop.Text = "Stop";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tslMessage
            // 
            this.tslMessage.Name = "tslMessage";
            this.tslMessage.Size = new System.Drawing.Size(0, 22);
            // 
            // tsbForward
            // 
            this.tsbForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbForward.Enabled = false;
            this.tsbForward.Image = ((System.Drawing.Image)(resources.GetObject("tsbForward.Image")));
            this.tsbForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbForward.Name = "tsbForward";
            this.tsbForward.Size = new System.Drawing.Size(23, 22);
            this.tsbForward.Text = "Forward";
            this.tsbForward.Click += new System.EventHandler(this.tsbForward_Click);
            // 
            // tsbEnd
            // 
            this.tsbEnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEnd.Enabled = false;
            this.tsbEnd.Image = ((System.Drawing.Image)(resources.GetObject("tsbEnd.Image")));
            this.tsbEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEnd.Name = "tsbEnd";
            this.tsbEnd.Size = new System.Drawing.Size(23, 22);
            this.tsbEnd.Text = "End";
            this.tsbEnd.Click += new System.EventHandler(this.tsbEnd_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslNodes,
            this.sslMoves});
            this.statusStrip1.Location = new System.Drawing.Point(0, 292);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(275, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslNodes
            // 
            this.sslNodes.BackColor = System.Drawing.SystemColors.Control;
            this.sslNodes.Name = "sslNodes";
            this.sslNodes.Size = new System.Drawing.Size(0, 0);
            // 
            // sslMoves
            // 
            this.sslMoves.BackColor = System.Drawing.SystemColors.Control;
            this.sslMoves.Name = "sslMoves";
            this.sslMoves.Size = new System.Drawing.Size(0, 17);
            // 
            // gemButton8
            // 
            this.gemButton8.ArrayPosition = 0;
            this.gemButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gemButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gemButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gemButton8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gemButton8.Location = new System.Drawing.Point(184, 205);
            this.gemButton8.Name = "gemButton8";
            this.gemButton8.Size = new System.Drawing.Size(80, 80);
            this.gemButton8.TabIndex = 8;
            this.gemButton8.Text = "0";
            this.gemButton8.UseVisualStyleBackColor = false;
            this.gemButton8.Value = 0;
            // 
            // gemButton7
            // 
            this.gemButton7.ArrayPosition = 0;
            this.gemButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gemButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gemButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gemButton7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gemButton7.Location = new System.Drawing.Point(98, 205);
            this.gemButton7.Name = "gemButton7";
            this.gemButton7.Size = new System.Drawing.Size(80, 80);
            this.gemButton7.TabIndex = 7;
            this.gemButton7.Text = "0";
            this.gemButton7.UseVisualStyleBackColor = false;
            this.gemButton7.Value = 0;
            // 
            // gemButton6
            // 
            this.gemButton6.ArrayPosition = 0;
            this.gemButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gemButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gemButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gemButton6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gemButton6.Location = new System.Drawing.Point(12, 205);
            this.gemButton6.Name = "gemButton6";
            this.gemButton6.Size = new System.Drawing.Size(80, 80);
            this.gemButton6.TabIndex = 6;
            this.gemButton6.Text = "0";
            this.gemButton6.UseVisualStyleBackColor = false;
            this.gemButton6.Value = 0;
            // 
            // gemButton5
            // 
            this.gemButton5.ArrayPosition = 0;
            this.gemButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gemButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gemButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gemButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gemButton5.Location = new System.Drawing.Point(184, 119);
            this.gemButton5.Name = "gemButton5";
            this.gemButton5.Size = new System.Drawing.Size(80, 80);
            this.gemButton5.TabIndex = 5;
            this.gemButton5.Text = "0";
            this.gemButton5.UseVisualStyleBackColor = false;
            this.gemButton5.Value = 0;
            // 
            // gemButton4
            // 
            this.gemButton4.ArrayPosition = 0;
            this.gemButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gemButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gemButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gemButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gemButton4.Location = new System.Drawing.Point(98, 119);
            this.gemButton4.Name = "gemButton4";
            this.gemButton4.Size = new System.Drawing.Size(80, 80);
            this.gemButton4.TabIndex = 4;
            this.gemButton4.Text = "0";
            this.gemButton4.UseVisualStyleBackColor = false;
            this.gemButton4.Value = 0;
            // 
            // gemButton3
            // 
            this.gemButton3.ArrayPosition = 0;
            this.gemButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gemButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gemButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gemButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gemButton3.Location = new System.Drawing.Point(12, 119);
            this.gemButton3.Name = "gemButton3";
            this.gemButton3.Size = new System.Drawing.Size(80, 80);
            this.gemButton3.TabIndex = 3;
            this.gemButton3.Text = "0";
            this.gemButton3.UseVisualStyleBackColor = false;
            this.gemButton3.Value = 0;
            // 
            // gemButton2
            // 
            this.gemButton2.ArrayPosition = 0;
            this.gemButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gemButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gemButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gemButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gemButton2.Location = new System.Drawing.Point(184, 33);
            this.gemButton2.Name = "gemButton2";
            this.gemButton2.Size = new System.Drawing.Size(80, 80);
            this.gemButton2.TabIndex = 2;
            this.gemButton2.Text = "0";
            this.gemButton2.UseVisualStyleBackColor = false;
            this.gemButton2.Value = 0;
            // 
            // gemButton1
            // 
            this.gemButton1.ArrayPosition = 0;
            this.gemButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gemButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gemButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gemButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gemButton1.Location = new System.Drawing.Point(98, 33);
            this.gemButton1.Name = "gemButton1";
            this.gemButton1.Size = new System.Drawing.Size(80, 80);
            this.gemButton1.TabIndex = 1;
            this.gemButton1.Text = "0";
            this.gemButton1.UseVisualStyleBackColor = false;
            this.gemButton1.Value = 0;
            // 
            // gemButton0
            // 
            this.gemButton0.ArrayPosition = 0;
            this.gemButton0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gemButton0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gemButton0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gemButton0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gemButton0.Location = new System.Drawing.Point(12, 33);
            this.gemButton0.Name = "gemButton0";
            this.gemButton0.Size = new System.Drawing.Size(80, 80);
            this.gemButton0.TabIndex = 0;
            this.gemButton0.Text = "0";
            this.gemButton0.UseVisualStyleBackColor = false;
            this.gemButton0.Value = 0;
            // 
            // GemPuzzleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(275, 314);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsGemPuzzle);
            this.Controls.Add(this.gemButton8);
            this.Controls.Add(this.gemButton7);
            this.Controls.Add(this.gemButton6);
            this.Controls.Add(this.gemButton5);
            this.Controls.Add(this.gemButton4);
            this.Controls.Add(this.gemButton3);
            this.Controls.Add(this.gemButton2);
            this.Controls.Add(this.gemButton1);
            this.Controls.Add(this.gemButton0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GemPuzzleForm";
            this.Text = "Gem Puzzle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GemPuzzleForm_FormClosing);
            this.Load += new System.EventHandler(this.GemPuzzleForm_Load);
            this.tsGemPuzzle.ResumeLayout(false);
            this.tsGemPuzzle.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GemButton gemButton0;
        private GemButton gemButton1;
        private GemButton gemButton2;
        private GemButton gemButton3;
        private GemButton gemButton4;
        private GemButton gemButton5;
        private GemButton gemButton6;
        private GemButton gemButton7;
        private GemButton gemButton8;
        private System.Windows.Forms.ToolStrip tsGemPuzzle;
        private System.Windows.Forms.ToolStripButton tsbResolve;
        private System.Windows.Forms.ToolStripButton tsbShuffle;
        private System.Windows.Forms.ToolStripButton tsbStart;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.ToolStripLabel tslMessage;
        private System.Windows.Forms.ToolStripButton tsbBackward;
        private System.Windows.Forms.ToolStripButton tsbPlay;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslNodes;
        private System.Windows.Forms.ToolStripStatusLabel sslMoves;
        private System.Windows.Forms.ToolStripButton tsbForward;
        private System.Windows.Forms.ToolStripButton tsbEnd;        
    }

    public class GemButton : System.Windows.Forms.Button
    {
        private int _arrayPosition;
        private int _value;
        public int ArrayPosition { get { return this._arrayPosition; } set { this._arrayPosition = value; } }
        public int Value { get { return this._value; } set { this.Visible = (Constants.InvisibleValue == value) ? false : true; this._value = value; } }
        public override string Text { get { return this.Value.ToString(); } set { base.Text = value; } }
    }
}