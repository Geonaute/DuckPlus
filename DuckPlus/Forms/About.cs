using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DuckPlus.Core;

namespace DuckPlus.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            // Application Version
            l_ApplicationVersion.Text = @"v" +
                                        FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)
                                            .ProductVersion + @" (ALPHA)";

            // Java Runtime Install Check
            if (Java.Installed)
            {
                l_JavaVersion.Text = @"Version: " + Java.Version;
                Gb_Java.Enabled = true;
            }
            else
            {
                l_JavaVersion.Text = @"Runtime is not installed.";
                Gb_Java.Enabled = false;
            }
        }

        #region Controls

        private void Btn_openFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        private void Ll_JavaControlPanel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Check before if Configuration Executable Exists
            if (File.Exists(Java.ConfigurationPath))
                Process.Start(Java.ConfigurationPath);
        }

        private void Ll_BtcAddress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(ll_BtcAddress.Text);
            MessageBox.Show(@"Copied address to Clipboard.", Application.ProductName);
        }

        private void Ll_GitHubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(ll_GitHubLink.Text);
        }

        #endregion
    }
}