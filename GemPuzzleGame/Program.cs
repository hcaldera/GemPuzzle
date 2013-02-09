using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GemPuzzleGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GemPuzzle.getInstance());
        }
    }

    public static class Constants
    {
        public const int InvisibleValue = 9;
        public const int InvalidValue = -1;
        public const int MinimumValue = 0;
    }
}