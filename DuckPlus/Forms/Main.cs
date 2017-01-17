using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DuckPlus.Core;
using DuckPlus.Enums;

namespace DuckPlus.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            Client = new WebClient();

            InitializeComponent();

            // Initialize Java
            Java.Initialize();

            // Add using System.Windows.Controls; - Drag'n Drop Functionality
            rt_CodeEditor.DragDrop += Rt_CodeEditor_DragDrop;
            rt_CodeEditor.AllowDrop = true;
        }

        #region Variables

        // WebClient
        public static WebClient Client;

        // Controls
        public static RichTextBox CtrlCodeEditor;
        public static ToolStripComboBox CtrlSearch;
        public static ToolStripComboBox CtrlReplace;

        #endregion

        #region Events

        private void Main_Load(object sender, EventArgs e)
        {
            // Update Encoder
            Encoder.Update(false);

            // Retrieve history
            PopulateRecentFilesHistory();

            // Open file that it was 'Opened With'
            if (Setting.FilesOpenedWith.Count > 0)
            {
                // check if file still exists
                if (File.Exists(Setting.FilesOpenedWith[0]))
                    OpenFile(Setting.FilesOpenedWith[0]);
            }

            // Update controls
            UpdateControlProperties();

            // Initialize payload manager
            InitializePayloadManager();

            // Load settings
            TopMost = Properties.Settings.Default.TopMost;
            rt_CodeEditor.WordWrap = Properties.Settings.Default.WordWrap;
            rt_CodeEditor.BackColor = Properties.Settings.Default.BackgroundColor;
            rt_CodeEditor.ForeColor = Properties.Settings.Default.ForegroundColor;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check for text content
            if (rt_CodeEditor.TextLength > 0)
                if (Editor.FileSaved == false)
                {
                    DialogResult dr = MessageBox.Show(
                        $@"Do you want to save changes to {Path.GetFileNameWithoutExtension(
                            Setting.WorkingFilePath)}?",
                        Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Cancel) // Cancel
                        e.Cancel = true;
                    else if (dr == DialogResult.Yes) // Save file
                        tsmi_Save.PerformClick();
                }
        }

        #endregion

        #region Controls

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            // Retrieve clicked menuitem
            ToolStripMenuItem clickedItem = (ToolStripMenuItem) sender;

            // Open the file
            OpenFile(clickedItem.Text);
        }

        private void Tsmi_CustomZoom_Click(object sender, EventArgs e)
        {
            // Set's the custom zoom level of the code editor. The ToolStripMenuItem Tag contains the zoom value.
            ToolStripMenuItem clickedItem = (ToolStripMenuItem) sender;
            rt_CodeEditor.ZoomFactor = ZoomControl.SetZoom(ZoomState.Custom, rt_CodeEditor.ZoomFactor,
                float.Parse(clickedItem.Tag.ToString()));
            Sddb_zoom.Text = ZoomControl.GetZoomString(rt_CodeEditor.ZoomFactor);
        }

        private void Bg_DownloadPayloads_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Begin Forced Update
                PayloadManager.Update(true);
            }
            catch (Exception ex)
            {
                PayloadManager.ShowErrorMessage("Unable to update payloads.", ex.Message);
            }
        }

        private void Bg_DownloadPayloads_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Payloads Updated
            tssl_Status.Text = Setting.PayloadStatus[2];
            pb_Payloads.Visible = false;

            // Refresh
            InitializePayloadManager();
        }

        #endregion

        #region Menu Items

        #region File Menu

        private void Tsmi_New_Click(object sender, EventArgs e)
        {
            // New Script
            Setting.WorkingFilePath = string.Empty;
            rt_CodeEditor.Text = string.Empty;

            // Update
            Editor.FileSaved = true;
            UpdateControlProperties();
            InitializePayloadManager();
        }

        private void Tsmi_Open_Click(object sender, EventArgs e)
        {
            // Construct OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = @"Open File";
                openFileDialog.Filter = Setting.SupportedFileTypes;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    OpenFile(openFileDialog.FileName);
            }
        }

        private void Tsmi_Cmd_Click(object sender, EventArgs e)
        {
            // Setup process information
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = Path.GetDirectoryName(Setting.WorkingFilePath),
                FileName = "cmd.exe"
            };

            // Custom additional properties     
            Process.Start(processStartInfo);
        }

        private void Tsmi_Explorer_Click(object sender, EventArgs e)
        {
            // Open folder in explorer
            Process.Start(Path.GetDirectoryName(Setting.WorkingFilePath));
        }

        private void Tsmi_Save_Click(object sender, EventArgs e)
        {
            // Check if text exists & is unsaved file
            if ((rt_CodeEditor.TextLength != 0) & (Editor.FileSaved == false))
                if (File.Exists(Setting.WorkingFilePath)) // File needs to exists to save to it
                {
                    // Save
                    rt_CodeEditor.SaveFile(Setting.WorkingFilePath, RichTextBoxStreamType.PlainText);

                    // Update recent files history
                    PopulateRecentFilesHistory();

                    // Update
                    Editor.FileSaved = true;
                    UpdateControlProperties();
                }
                else
                {
                    // call saveAs function
                    tsmi_Saveas.PerformClick();
                }
        }

        private void Tsmi_SaveAs_Click(object sender, EventArgs e)
        {
            // Construct SaveFileDialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Title = @"Save As...";
                saveFileDialog.Filter = @"Ducky Script|*.duck|Text Files|*.txt|All Files|*.*";
                saveFileDialog.FilterIndex = 1;

                // Show Dialog
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    try
                    {
                        // Save File
                        rt_CodeEditor.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);

                        // Get FileName
                        Setting.WorkingFilePath = saveFileDialog.FileName;

                        // Update
                        Editor.FileSaved = true;
                        UpdateControlProperties();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Couldn't save file to disk.\n\nError: " + ex.Message, Application.ProductName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void Tsmi_ImportPayload_Click(object sender, EventArgs e)
        {
            try
            {
                // Load supported filetypes
                var files =
                    Directory.GetFiles(PayloadManager.PayloadsDirectory)
                        .Where(file => Regex.IsMatch(file, @"^.+\.(duck|txt)$"));

                // Get script path
                foreach (string fileNames in files)
                    if (tscb_Payloads.SelectedItem.ToString() == Path.GetFileNameWithoutExtension(fileNames))
                    {
                        //Read payload code to code editor
                        OpenFile(fileNames);
                        tssl_Status.Text = Setting.PayloadStatus[5];
                    }
            }
            catch (Exception ex)
            {
                PayloadManager.ShowErrorMessage("Unable to import payload.", ex.Message);
            }
        }

        private void Tsmi_UpdatePayloads_Click(object sender, EventArgs e)
        {
            // Ask before Downloading Payloads here not in initialize
            DialogResult dr = MessageBox.Show(@"Replacements are made.   ", Application.ProductName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Call background worker to download
                tssl_Status.Text = Setting.PayloadStatus[1];
                pb_Payloads.Visible = true;
                BwPayloadDownloader.RunWorkerAsync();
            }
        }

        private void Tsmi_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Edit Menu

        private void UndoTsmi_Click(object sender, EventArgs e)
        {
            // Undo the last operation
            if (rt_CodeEditor.CanUndo)
                rt_CodeEditor.Undo();
        }

        private void RedoTsmi_Click(object sender, EventArgs e)
        {
            if (rt_CodeEditor.CanRedo)
                if (rt_CodeEditor.RedoActionName != "Delete")
                    rt_CodeEditor.Redo();
        }

        private void CutTsmi_Click(object sender, EventArgs e)
        {
            // Ensure that text is currently selected in the text box.   
            if (rt_CodeEditor.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                rt_CodeEditor.Cut();
        }

        private void CopyTsmi_Click(object sender, EventArgs e)
        {
            // Ensure that text is selected in the text box.   
            if (rt_CodeEditor.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                rt_CodeEditor.Copy();
        }

        private void PasteTsmi_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
                rt_CodeEditor.Paste();
        }

        private void DeleteTsmi_Click(object sender, EventArgs e)
        {
            rt_CodeEditor.SelectedText = "";
        }

        private void SelectAllTsmi_Click(object sender, EventArgs e)
        {
            rt_CodeEditor.SelectAll();
        }

        #endregion

        #region Build Menu

        private void EncodeTsmi_Click(object sender, EventArgs e)
        {
            // Save Script
            tsmi_Save.PerformClick();

            // Check for script file
            if (File.Exists(Setting.WorkingFilePath))
            {
                SaveFileDialog encoderDialog = new SaveFileDialog
                {
                    Title = @"Save To...",
                    RestoreDirectory = true,
                    FileName = "Inject",
                    Filter = @"Inject|*.bin"
                };

                if (encoderDialog.ShowDialog() == DialogResult.OK)
                    Encoder.Encode(encoderDialog.FileName);
            }
            else
            {
                DialogResult dr = MessageBox.Show(@"The has been replaced.", Application.ProductName,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes) // Cancel
                    tsmi_Open.PerformClick();
            }
        }

        #endregion

        #region View Menu

        // Find & Replace
        private void FindReplaceTsmi_Click(object sender, EventArgs e)
        {
            if (tsmi_Fnr.Checked)
            {
                TsFindReplace.Visible = false;
                tsmi_Fnr.CheckState = CheckState.Unchecked;
            }
            else
            {
                TsFindReplace.Visible = true;
                tsmi_Fnr.CheckState = CheckState.Checked;
            }
        }

        // View Status Strip
        private void StatusMenuTsmi_Click(object sender, EventArgs e)
        {
            if (tsmi_Status.Checked)
            {
                Ss_Status.Visible = false;
                tsmi_Status.CheckState = CheckState.Unchecked;
            }
            else
            {
                Ss_Status.Visible = true;
                tsmi_Status.CheckState = CheckState.Checked;
            }
        }

        // View Tools Menu
        private void ViewToolsTsmi_Click(object sender, EventArgs e)
        {
            if (tsmi_Tools.Checked)
            {
                TsToolsMenu.Visible = false;
                tsmi_Tools.CheckState = CheckState.Unchecked;
            }
            else
            {
                TsToolsMenu.Visible = true;
                tsmi_Tools.CheckState = CheckState.Checked;
            }
        }

        // Zoom control - Increase, Decrease, Reset
        private void Tsmi_ZoomControlManager_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem) sender;

            switch (clickedItem.Text)
            {
                case "Restore Default Zoom":
                {
                    rt_CodeEditor.ZoomFactor = ZoomControl.SetZoom(ZoomState.Default, rt_CodeEditor.ZoomFactor,
                        ZoomControl.ZoomStep);
                    break;
                }
                case "Zoom Increase":
                {
                    rt_CodeEditor.ZoomFactor = ZoomControl.SetZoom(ZoomState.Increase, rt_CodeEditor.ZoomFactor,
                        ZoomControl.ZoomStep);
                    break;
                }
                case "Zoom Decrease":
                {
                    rt_CodeEditor.ZoomFactor = ZoomControl.SetZoom(ZoomState.Decrease, rt_CodeEditor.ZoomFactor,
                        ZoomControl.ZoomStep);
                    break;
                }
            }

            Sddb_zoom.Text = ZoomControl.GetZoomString(rt_CodeEditor.ZoomFactor);
        }

        #endregion

        #region ? Menu

        private void SettingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Settings frmSettings = new Settings();
            frmSettings.ShowDialog(this);
        }

        private void Tsmi_About_Click(object sender, EventArgs e)
        {
            About frmAbout = new About();
            frmAbout.ShowDialog(this);
        }

        #endregion

        #endregion

        #region Code Editor

        private void Rt_CodeEditor_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateControlProperties();
        }

        private void Rt_CodeEditor_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateControlProperties();
        }

        private void Rt_CodeEditor_TextChanged(object sender, EventArgs e)
        {
            Editor.FileSaved = false;
            UpdateControlProperties();
        }

        // Drag'n Drop
        private void Rt_CodeEditor_DragDrop(object sender, DragEventArgs e)
        {
            // Get object
            object filename = e.Data.GetData("FileDrop");

            // Check file
            if (filename != null)
                if (filename is string[] list && !string.IsNullOrWhiteSpace(list[0]))
                    OpenFile(list[0]);
        }

        #endregion

        #region Find & Replace 

        private void Tsb_Find_Click(object sender, EventArgs e)
        {
            UpdateControlProperties();
            Editor.FindText();

            // Add to Search History
            cb_Search.Items.Add(cb_Search.Text);
        }

        private void Tsb_Replace_Click(object sender, EventArgs e)
        {
            UpdateControlProperties();
            Editor.Replace();

            // Add to Search History
            tscb_Replace.Items.Add(tscb_Replace.Text);
        }

        private void Tsb_replaceAll_Click(object sender, EventArgs e)
        {
            UpdateControlProperties();
            Editor.ReplaceAll();
        }

        private void Cb_Search_TextChanged(object sender, EventArgs e)
        {
            Editor.FirstSearch = true;
        }

        private void Cb_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                // Find
                rt_CodeEditor.Focus();
                tsb_Find.PerformClick();
            }
        }

        #region Settings

        // Toggle Match Case
        private void Tsb_MatchCase_Click(object sender, EventArgs e)
        {
            if (tsb_MatchCase.Checked)
            {
                tsb_MatchCase.CheckState = CheckState.Unchecked;
                Editor.MatchCase = false;
            }
            else
            {
                tsb_MatchCase.CheckState = CheckState.Checked;
                Editor.MatchCase = true;
            }
        }

        // Toggle Match Word
        private void Tsb_MatchWord_Click(object sender, EventArgs e)
        {
            if (tsb_MatchWord.Checked)
            {
                tsb_MatchWord.CheckState = CheckState.Unchecked;
                Editor.MatchWord = false;
            }
            else
            {
                tsb_MatchWord.CheckState = CheckState.Checked;
                Editor.MatchWord = true;
            }
        }

        // Toggle RegularExpressions
        private void Tsb_RegularExpressions_Click(object sender, EventArgs e)
        {
            if (tsb_RegularExpressions.Checked)
            {
                tsb_RegularExpressions.CheckState = CheckState.Unchecked;
                Editor.RegularExpressions = false;
            }
            else
            {
                tsb_RegularExpressions.CheckState = CheckState.Checked;
                Editor.RegularExpressions = true;
            }
        }

        // Toggle Wildcards
        private void Tsb_Wildcards_Click(object sender, EventArgs e)
        {
            if (tsb_Wildcards.Checked)
            {
                tsb_Wildcards.CheckState = CheckState.Unchecked;
                Editor.Wildcards = false;
            }
            else
            {
                tsb_Wildcards.CheckState = CheckState.Checked;
                Editor.Wildcards = true;
            }
        }

        #endregion

        #endregion

        #region Methods

        // Updates recent file history
        private void PopulateRecentFilesHistory()
        {
            // Check for recent file updates
            Setting.ManageHistoryLog();
            //Core.Settings.UpdateRecentFilesHistory();

            // Clears previous history items
            tsmi_OpenRecent.DropDownItems.Clear();

            // Modify
            for (var i = 0; i < Setting.FileHistory.Count; i++)
            {
                // Construct subitem
                ToolStripMenuItem items = new ToolStripMenuItem
                {
                    Name = @"Tsmi_History" + i,
                    Tag = Setting.FileHistory[i],
                    Text = Setting.FileHistory[i]
                };

                // Add event
                items.Click += MenuItemClickHandler;

                // Add to menu
                tsmi_OpenRecent.DropDownItems.Add(items);
            }
        }

        // Opens the file.
        private void OpenFile(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    // Read stream to end
                    string line = sr.ReadToEnd();
                    rt_CodeEditor.Text = line;

                    // Update
                    Editor.FileSaved = true;
                    Editor.ProcessFile(fileName, Editor.FileSaved);
                    Text = Editor.TitleText;

                    Setting.WorkingFilePath = fileName;
                    Setting.ManageHistoryLog(true);
                    PopulateRecentFilesHistory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Couldn't read file from disk." + Environment.NewLine + @"Error: " + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Initialize Payloads
        private void InitializePayloadManager()
        {
            // Initialize
            PayloadManager.Update(false);
            RefreshPayloads();
            try
            {
                // Check for local payloads
                if (PayloadManager.LocalPayloadCount > 0)
                {
                    // Check for online payloads
                    if (PayloadManager.IsUpdateAvailable)
                        tssl_Status.Text = Setting.PayloadStatus[0];
                    else
                        tssl_Status.Text = Setting.PayloadStatus[3];
                    tssl_Status.Text = Setting.PayloadStatus[3];
                }
            }
            catch (Exception ex)
            {
                PayloadManager.ShowErrorMessage("Unable to load payloads.", ex.Message);
            }
        }

        // Refresh payloads
        private void RefreshPayloads()
        {
            // Load supported filetypes
            var files =
                Directory.GetFiles(PayloadManager.PayloadsDirectory)
                    .Where(file => Regex.IsMatch(file, @"^.+\.(duck|txt)$"));

            // Check if local payloads count
            if (PayloadManager.LocalPayloadCount > 0)
            {
                //Get Files path
                foreach (string filePath in files)
                    if (!tscb_Payloads.Items.Contains(Path.GetFileNameWithoutExtension(filePath)))
                        tscb_Payloads.Items.Add(Path.GetFileNameWithoutExtension(filePath));

                // Refresh Properties
                tscb_Payloads.SelectedIndex = 0;
                tscb_Payloads.Enabled = true;
                tsmi_ImportPayload.Enabled = true;
                tssl_Status.Text = Setting.PayloadStatus[3];
            }
            else
            {
                tssl_Status.Text = Setting.PayloadStatus[4];
            }

            // Display Count
            tssl_LocalPayloadCount.Text = @"Local (" + PayloadManager.LocalPayloadCount + @")";
            tssl_OnlinePayloadCount.Text = @"Online (" + PayloadManager.OnlinePayloadCount + @")";
        }

        // Update Control Properties
        private void UpdateControlProperties()
        {
            CtrlCodeEditor = rt_CodeEditor;
            CtrlSearch = cb_Search;
            CtrlReplace = tscb_Replace;

            Editor.ProcessFile(Setting.WorkingFilePath, Editor.FileSaved);
            Text = Editor.TitleText;

            // Toggle Open Containing Folder Menu
            tsmiOpenFolder.Enabled = File.Exists(Setting.WorkingFilePath);

            // Update File Information
            Editor.GetEditorInformation();

            tssl_Length.Text = @"Length : " + rt_CodeEditor.TextLength;
            tssl_Lines.Text = @"Lines : " + rt_CodeEditor.Lines.Count();
            tssl_Line.Text = @"Line : " + Editor.Line;
            tssl_Column.Text = @"Column : " + Editor.Column;
        }

        #endregion
    }
}