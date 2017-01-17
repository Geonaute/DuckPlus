using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DuckPlus.Enums;
using DuckPlus.Forms;

namespace DuckPlus.Core
{
    internal class Editor
    {
        #region Variables

        // Settings
        public static bool MatchCase = false;
        public static bool MatchWord = false;
        public static bool RegularExpressions = false;
        public static bool Wildcards = false;

        // Variables
        public static Regex Regex;
        public static Match Match;
        public static bool FirstSearch = true;

        //File Information
        public static string TitleText;
        public static bool FileSaved = true;

        // Editor Information
        public static string UnsavedChar;
        public static int Column, Line, Lines, SelectionStart, SelectionLength, TextLength;

        #endregion

        #region Properties

public static RichTextBox CodeEdit
        {
            get { return Main.CtrlCodeEditor; }
            set { Main.CtrlCodeEditor = value; }
        }

        public static ToolStripComboBox Search
        {
            get { return Main.CtrlSearch; }
            set { Main.CtrlSearch = value; }
        }

        public static ToolStripComboBox ReplaceControl
        {
            get { return Main.CtrlReplace; }
            set { Main.CtrlReplace = value; }
        }

        #endregion

        #region Methods

        // File Processor
        public static void ProcessFile(string filePath, bool saveState)
        {
            // Save State Check
            if (saveState == false)
                UnsavedChar = "*";
            else
                UnsavedChar = string.Empty;

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = "Untitled";
                UnsavedChar = string.Empty;
            }

            // Update title
            TitleText = $"{UnsavedChar}{filePath} - {Application.ProductName}";
        }

        // Update Editor
        public static void GetEditorInformation()
        {
            SelectionStart = CodeEdit.SelectionStart;
            SelectionLength = CodeEdit.SelectionLength;

            // Get the line.
            int index = CodeEdit.SelectionStart;
            int line = CodeEdit.GetLineFromCharIndex(index) + 1;

            // Get the column.
            int firstChar = CodeEdit.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;

            // Custom Code Editor stats
            TextLength = CodeEdit.TextLength;
            Lines = CodeEdit.Lines.Count();

            Line = line;
            Column = column;
        }

        // Replace
        public static void Replace()
        {
            // Make a local RegEx and Match instances
            Regex regexTemp = GetRegExpression();
            Match matchTemp = regexTemp.Match(CodeEdit.SelectedText);

            if (matchTemp.Success)
                if (matchTemp.Value == CodeEdit.SelectedText)
                    CodeEdit.SelectedText = ReplaceControl.Text;
            FindText();
        }

        // Replace All
        public static void ReplaceAll()
        {
            Regex replaceRegex = GetRegExpression();
            string replacedString;

            // get the current SelectionStart
            int selectedPos = CodeEdit.SelectionStart;

            // get the replaced string
            replacedString = replaceRegex.Replace
                (CodeEdit.Text, ReplaceControl.Text);

            // Is the text changed?
            if (CodeEdit.Text != replacedString)
            {
                // then replace it
                CodeEdit.Text = replacedString;
                MessageBox.Show(@"Replacements are made.   ", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // restore the SelectionStart
                CodeEdit.SelectionStart = selectedPos;
            }
            else // inform user if no replacements are made
            {
                MessageBox.Show($@"Cannot find '{Search.Text}'.   ",
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            CodeEdit.Focus();
        }

        // Find next text
        public static void FindText()
        {
            // First time calling?
            if (FirstSearch)
            {
                Regex = GetRegExpression();
                Match = Regex.Match(CodeEdit.Text);
                FirstSearch = false;
            }
            else
            {
                // Check match
                Match = Regex.Match(CodeEdit.Text, Match.Index + 1);
            }

            // Found
            if (Match.Success)
            {
                CodeEdit.SelectionStart = Match.Index;
                CodeEdit.SelectionLength = Match.Length;
            }
            else // not finding anymore?
            {
                MessageBox.Show($@"Cannot find '{Search.Text}'.   ",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                FirstSearch = true;
            }
        }

        // Returns RegEx Object
        public static Regex GetRegExpression()
        {
            Regex result;
            string regExString;

            // Get what the user entered
            regExString = Search.Text;

            if (RegularExpressions)
            {
                // If regular expressions checkbox is selected,
                // then do Nothing
            }
            // wild cards checkbox checked
            else if (Wildcards)
            {
                // multiple characters wildcard (*)
                regExString = regExString.Replace("*", @"\w*");

                // single character wildcard (?)
                regExString = regExString.Replace("?", @"\w");

                // if wild cards selected, find whole words only
                regExString = string.Format("{0}{1}{0}", @"\b", regExString);
            }
            else
            {
                // replace escape characters
                regExString = Regex.Escape(regExString);
            }

            // Is whole word check box checked?
            if (MatchWord)
                regExString = string.Format("{0}{1}{0}", @"\b", regExString);

            // Is match case checkbox checked or not?
            if (MatchCase)
                result = new Regex(regExString);
            else
                result = new Regex(regExString, RegexOptions.IgnoreCase);

            return result;
        }

        #endregion
    }

    internal class ZoomControl
    {
        // Declare Variables
        public static float DefaultZoomFactor = 1.0f;
        public static float MaxZoomFactor = 4.0f;
        public static float MinZoomFactor = 0.1f;
        public static float ZoomStep = 0.1f;

        // Custom Zoom
        public static float SetZoom(ZoomState state, float currentZoom, float zoomStep)
        {
            switch (state)
            {
                case ZoomState.Increase:
                {
                    if (currentZoom + zoomStep <= MaxZoomFactor)
                        currentZoom = currentZoom + zoomStep;
                }
                    break;
                case ZoomState.Decrease:
                {
                    if (currentZoom - zoomStep >= MinZoomFactor)
                        currentZoom = currentZoom - zoomStep;
                }
                    break;
                case ZoomState.Default:
                {
                    currentZoom = 1f;
                }
                    break;
                case ZoomState.Custom:
                {
                    currentZoom = zoomStep;
                }
                    break;
                default:
                    currentZoom = DefaultZoomFactor;
                    break;
            }
            return currentZoom;
        }

        // Get Zoom - '###%'
        public static string GetZoomString(float input)
        {
            return $"{(input * 100):00}%";
        }
    }
}