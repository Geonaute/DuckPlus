using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

//
// https://github.com/hak5darren/USB-Rubber-Ducky/tree/master/Encoder
//

namespace DuckPlus.Core
{
    internal class Encoder
    {
        #region Variables

        public static string EncoderPath = AppDomain.CurrentDomain.BaseDirectory + @"\encoder.jar";

        private const string EncoderUrl =
            "https://github.com/hak5darren/USB-Rubber-Ducky/blob/master/Encoder/encoder.jar?raw=true";

        private static readonly string UserAgent = Application.ProductName;

        #endregion

        #region Methods

        // Download Encoder
        private static void Download()
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    if (File.Exists(EncoderPath))
                    {
                        // Create backup
                        File.Copy(EncoderPath, EncoderPath + ".backup", true);

                        // Delete old
                        File.Delete(EncoderPath);
                    }

                    // Download new
                    using (WebClient client = new WebClient())
                    {
                        client.Headers.Add("user-agent", UserAgent);
                        client.DownloadFileAsync(new Uri(EncoderUrl), EncoderPath);

                        // Show Confirmation
                        MessageBox.Show(@"Replacements are made.   ", Application.ProductName, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(@"The download for the encoder update failed. Created backup!\n\nError: " + e.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Restore backup
                File.Copy(EncoderPath + ".backup", EncoderPath, true);
            }
        }

        /// <summary>
        ///     Check for encoder update. (Force Update)
        /// </summary>
        /// <param name="force"></param>
        public static void Update(bool force)
        {
            // Check if encoder exists
            if (!File.Exists(EncoderPath) || force)
            {
                Download();
            }
            else
            {
                // Create FileInfo from encoder
                FileInfo enc = new FileInfo(EncoderPath);

                // Check if old version and update then
                if (enc.LastAccessTime <
                    DateTime.Now.AddDays(Convert.ToDouble(-Properties.Settings.Default.EncoderAutoUpdateDays)))
                    // Check days since last download
                    Update(true);
            }
        }

        /// <summary>
        ///     Encode, Source File, Output File, PresetKeyboardSelection Selection
        /// </summary>
        /// <param name="outputPath">The output path of the encoded script.</param>
        public static void Encode(string outputPath = "inject.bin")
        {
            // Create Batch Commands
            var consoleCommands = "@echo off";
            consoleCommands += Environment.NewLine + @"Title " + Application.ProductName;

            // Keyboard Layout
            string keyboardArgs = Properties.Settings.Default.PresetKeyboard
                ? Setting.KeyboardStrings[Properties.Settings.Default.KeyboardSelection]
                : Properties.Settings.Default.KeyboardPropertiesPath;

            // Configure Batch Commands
            consoleCommands += Environment.NewLine + @"java.exe -jar " + Setting.EncoderFileName + @" -i """ +
                               Setting.WorkingFilePath + @""" -o """ + outputPath + @""" -l """ + keyboardArgs + @"""";

            // Create Encoder
            File.WriteAllText(Setting.InstallDirectory + Setting.EncoderBatchFile, consoleCommands);

            // Create encoder process
            Process p = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = Setting.EncoderBatchFile
                }
            };

            // Start process
            p.Start();

            // Display results
            string output = p.StandardOutput.ReadToEnd();
            MessageBox.Show(output, Application.ProductName);

            // Cleanup
            Thread.Sleep(1000);
            File.Delete(Setting.InstallDirectory + Setting.EncoderBatchFile);
        }

        #endregion
    }
}