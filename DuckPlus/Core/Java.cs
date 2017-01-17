using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DuckPlus.Core
{
    internal class Java
    {
        #region Variables
        public static bool Installed { get; set; }
        public static string InstallPath { get; set; }
        public static string ConfigurationPath { get; set; }
        public static string ExecutablePath { get; set; }

        // Registry
        private const string RegistryPath = @"SOFTWARE\JavaSoft\Java Runtime Environment\";
        public static string Version { get; set; }

        // Files
        private const string BinaryExe = @"\bin\Java.exe";
        public static string BinaryConfig = @"\bin\javacpl.exe";

        // Download
        private const string Url = "https://java.com/en/download/";

        #endregion

        // Initialize Java Runtime
        public static void Initialize()
        {
            try
            {
                string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
                if (!string.IsNullOrEmpty(environmentPath))
                {
                    // Return install path
                    InstallPath = environmentPath;
                }

                // Get registry value
                using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegistryPath))
                {
                    // Get version
                    Version = registryKey.GetValue("CurrentVersion").ToString();

                    using (RegistryKey key = registryKey.OpenSubKey(Version))
                    {
                        // Get install path
                        if (key != null) InstallPath = key.GetValue("JavaHome").ToString();

                        // Collect Information
                        ConfigurationPath = InstallPath + BinaryConfig;
                        ExecutablePath = InstallPath + BinaryExe;
                    }
                }
                
                // Check if Java exists
                if(File.Exists(ExecutablePath))
                {
                    Installed = true;
                }
            }
            catch (Exception ex) // Java not correctly installed
            {
                Installed = false;

                DialogResult dr = MessageBox.Show(
                    $@"{"This application requires Java Runtime to be installed to run properly."}\n{"Would you like to download the latest version?"}\n{"Visit: https://java.com/en/download/"}\n\nException: {ex.Message}", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dr == DialogResult.Yes)
                {
                    // Open download URL
                    Process.Start(Url);
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
