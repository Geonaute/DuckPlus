using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace DuckPlus.Core
{
    internal class Setting
    {
        #region Methods

        /// <summary>
        /// Check if .duck file extension is associated with this application.
        /// </summary>
        public static bool IsAssociated()
        {
            return (Registry.CurrentUser.OpenSubKey(@"Software\Classes\" + Extension, false) == null);
        }

        /// <summary>
        ///     Updates the History Log file.
        /// </summary>
        /// <param name="write">Write new log history to file.</param>
        public static void ManageHistoryLog(bool write = false)
        {
            // Create a history log file if it don't exist
            if (!File.Exists(FileHistoryLocation))
            {
                File.Create(FileHistoryLocation).Close();
            }

            // Check for duplicates
            if (FileHistory.Count != 0)
                FileHistory = FileHistory.Distinct().ToList();

            // Write from memory to history file
            if (write)
            {
                // Hold a history max count to prevent memory leaks
                if (File.ReadAllLines(FileHistoryLocation).Length <= Properties.Settings.Default.MaxRecentProjects)
                {
                    // Add file path to memory
                    FileHistory.Add(WorkingFilePath);

                    // Overwrite the file
                    File.WriteAllLines(FileHistoryLocation, FileHistory);
                }
                else
                {
                    // Truncate first line when limit reached
                    while (FileHistory.Count > Properties.Settings.Default.MaxRecentProjects)
                        File.WriteAllLines(FileHistoryLocation, File.ReadAllLines(FileHistoryLocation).Skip(1).ToArray());


                    // Add file path to memory
                    FileHistory.Add(WorkingFilePath);

                    // Overwrite the file
                    File.WriteAllLines(FileHistoryLocation, FileHistory);
                }
            }
            else
            {
                // Read the settings only once from file, to prevent adding multiple items to list
                if (_readSettings)
                {
                    _readSettings = false;

                    var lines = File.ReadLines(FileHistoryLocation);
                    foreach (string line in lines)
                        FileHistory.Add(line);
                }
            }
        }

        #endregion

        #region Variables

        internal const string Extension = @".duck";

        private static bool _readSettings = true;

        internal static List<string> FilesOpenedWith = new List<string>();
        internal static List<string> FileHistory = new List<string>();
        internal static List<string> Payloads = new List<string>();

        private const string FileHistoryLocation = "History.log";
        internal const string SupportedFileTypes = @"Ducky Script|*.duck|Text Files|*.txt|All Files|*.*";

        internal static string WorkingFilePath;
        internal static string InstallDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\";

        internal static string EncoderFileName = @"encoder.jar";
        internal static string EncoderBatchFile = @"encoder.bat";
        internal static string SettingsFilePath = @"settings.xml";


        // Preset PresetKeyboardSelection Languages
        public static readonly string[] KeyboardStrings =
        {
            "be", "br", "ca", "ch", "de", "dk",
            "es", "fi", "fr", "gb", "hr", "it",
            "pt", "ru", "si", "sv", "tr", "us"
        };

        internal static readonly string[] PayloadStatus =
        {
            "Payloads update available!", // 0
            "Downloading payloads...", // 1
            "Payloads updated!", // 2
            "Local payload/s loaded.", // 3
            "No local payloads to load. Try updating.", // 4
            "Payload Imported." // 5
        };

        #endregion
    }
}