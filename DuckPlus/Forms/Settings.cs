using System;
using System.Reflection;
using System.Windows.Forms;
using DuckPlus.Core;

namespace DuckPlus.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        #region Events

        private void Settings_Load(object sender, EventArgs e)
        {
            // General
            Nud_MaxProjects.Value = Properties.Settings.Default.MaxRecentProjects;
            Cb_TopMost.Checked = Properties.Settings.Default.TopMost;

            // Code Editor
            Cb_WordWrap.Checked = Properties.Settings.Default.WordWrap;
            UpdateColor();

            // Encoder
            Nud_Update.Value = Properties.Settings.Default.EncoderAutoUpdateDays;
            Cb_Keyboard.SelectedIndex = Properties.Settings.Default.KeyboardSelection;
            Tb_KeyboardPropertiesPath.Text = Properties.Settings.Default.KeyboardPropertiesPath;
            if (Properties.Settings.Default.PresetKeyboard)
            {
                Rb_Preset.Checked = true;
                Btn_Browse.Enabled = false;
            }
            else
            {
                Rb_Custom.Checked = true;
                Btn_Browse.Enabled = true;
            }
        }

        #endregion

        #region Methods

        private void UpdateColor()
        {
            L_ColorExample.BackColor = Properties.Settings.Default.BackgroundColor;
            L_ColorExample.ForeColor = Properties.Settings.Default.ForegroundColor;
        }

        #endregion

        #region Controls

        private void Btn_UpdateEncoder_Click(object sender, EventArgs e)
        {
            Encoder.Update(true);
        }

        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Load Custom PresetKeyboardSelection Layout Properties File
                ofd.Title = @"Open Preset Keyboard Selection Layout Properties File";
                ofd.Filter = @"Preset Keyboard Selection Layout|*.properties|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Tb_KeyboardPropertiesPath.Text = ofd.FileName;
                    Properties.Settings.Default.KeyboardPropertiesPath = ofd.FileName;
                }
            }
        }

        private void Cb_Keyboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.KeyboardSelection = Cb_Keyboard.SelectedIndex;
        }

        private void Rb_Custom_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Preset.Checked)
            {
                Cb_Keyboard.Enabled = true;
                Btn_Browse.Enabled = false;
                Properties.Settings.Default.PresetKeyboard = true;
            }
            else
            {
                Cb_Keyboard.Enabled = false;
                Btn_Browse.Enabled = true;
                Properties.Settings.Default.PresetKeyboard = false;
            }
        }

        private void Nud_Update_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EncoderAutoUpdateDays = Nud_Update.Value;
            Properties.Settings.Default.Save();
        }

        private void Nud_MaxProjects_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MaxRecentProjects = Nud_MaxProjects.Value;
            Properties.Settings.Default.Save();
        }

        private void Btn_Register_Click(object sender, EventArgs e)
        {
            try
            {
                FileAssociation manageFileAssociation = new FileAssociation
                {
                    Extension = "duck",
                    ContentType = "text/plain",
                    FullName = "Ducky Script File",
                    ProperName = "Ducky Script",
                    IconPath = Assembly.GetExecutingAssembly().Location,
                    IconIndex = 0
                };
                manageFileAssociation.AddCommand("open", Assembly.GetExecutingAssembly().Location + " %1");
                manageFileAssociation.Create();
                MessageBox.Show(@"Registered file association to registry.", Application.ProductName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Application.ProductName);
            }
        }

        private void Btn_Unregister_Click(object sender, EventArgs e)
        {
            try
            {
                FileAssociation manageFileAssociation = new FileAssociation();
                // Remove the file type from the registry
                manageFileAssociation.Remove();
                MessageBox.Show(@"Removed registry entry.", Application.ProductName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Application.ProductName);
            }
        }

        private void Cb_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TopMost = Cb_TopMost.Checked;
            Properties.Settings.Default.Save();
        }

        private void Cb_WordWrap_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WordWrap = Cb_WordWrap.Checked;
            Properties.Settings.Default.Save();
        }

        private void Btn_Background_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Properties.Settings.Default.BackgroundColor = colorDialog.Color;
                Properties.Settings.Default.Save();
            }

            UpdateColor();
        }

        private void Btn_Foreground_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Properties.Settings.Default.ForegroundColor = colorDialog.Color;
                Properties.Settings.Default.Save();
            }

            UpdateColor();
        }

        #endregion
    }
}