using System;
using System.Windows.Forms;
using DuckPlus.Forms;
using DuckPlus.Core;

namespace DuckPlus
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Bug Fix: Unable to pass spaces through arguments
            string joinedPath = string.Join(" ", args);

            // Add Opened With files to list.
            Setting.FilesOpenedWith.Add(joinedPath);

            // Run the application.
            Application.Run(new Main());
        }
    }
}