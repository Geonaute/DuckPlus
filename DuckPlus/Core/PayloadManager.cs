using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using DuckPlus.Forms;
using DuckPlus.Core;

namespace DuckPlus.Core
{
    public class PayloadManager
    {
        #region Variables

        public static int LocalPayloadCount { get; set; }
        public static int OnlinePayloadCount { get; set; }
        public static bool IsUpdateAvailable { get; set; }

        // Local
        public static string PayloadsDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                                                 @"\Payloads\";

        public static string PayloadExtension = ".duck";

        // Remote
        private const string PayloadsUrl = "https://github.com/hak5darren/USB-Rubber-Ducky/wiki/Payloads";

        #endregion

        #region Methods

        /// <summary>
        ///     Shows error message. Message. Exception Message(ex.Message)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void ShowErrorMessage(string message, string ex)
        {
            MessageBox.Show($@"{message}

Error: {ex}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        ///     Payloads Update. Downloads Payload Updates.
        /// </summary>
        public static void Update(bool force)
        {
            try
            {
                Initialize();

                // Check if update required
                if (LocalPayloadCount < OnlinePayloadCount)
                {
                    // Packages are available to download
                    IsUpdateAvailable = true;

                    // Check if Forced = True; Then Download
                    if (force)
                        Download();
                }
                else
                {
                    // Updated
                    IsUpdateAvailable = false;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Failed to check for updates.", ex.Message);
            }
        }

        public static List<Payload> Parse(string source)
        {
            // Declare variable
            var payloads = new List<Payload>();

            // Find all matches in file.
            MatchCollection payloadMatches = Regex.Matches(source, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);

            // Loop over each match.
            foreach (Match payloadMatch in payloadMatches)
            {
                string payloadMatchValue = payloadMatch.Groups[1].Value;

                // Declare new object to contain parsed link name title.
                Payload payload = new Payload();

                // Get href attribute.
                Match linkMatch = Regex.Match(payloadMatchValue, @"href=\""(.*?)\""", RegexOptions.Singleline);
                if (!linkMatch.Success)
                    continue;

                string path = HttpUtility.HtmlDecode(linkMatch.Groups[1].Value);
                payload.Link = "https://github.com" + path;

                // Remove inner tags from text.
                string name = Regex.Replace(payloadMatchValue, @"\s*<.*?>\s*", "", RegexOptions.Singleline);
                payload.Name = name;
                payloads.Add(payload);
            }

            return payloads;
        }

        // Check & Create Directory
        public static void CheckDirectory()
        {
            if (!Directory.Exists(PayloadsDirectory))
                Directory.CreateDirectory(PayloadsDirectory);
        }

        // Download Payloads
        private static void Download()
        {
            //Load Wiki-Payload Page
            string pageSource = Main.Client.DownloadString(PayloadsUrl);
            var payloads = new List<Payload>();
            var list = new List<string>();

            // Each link on Wiki-Payload Page
            foreach (Payload payload in Parse(pageSource))
            {
                Payload tempPayload = payload;

                // Only save /wiki/Payload--- links
                if (!payload.Link.Contains("hak5darren/USB-Rubber-Ducky/wiki/Payload---"))
                    continue;

                //Clean up payload name
                var sanitizedName = "";
                if (sanitizedName.Contains("Payload - ")) // Remove Payload - from title
                {
                    string replace = sanitizedName.Replace("Payload - ", "");
                }
                sanitizedName = payload.Name.Replace("/", " ").Replace("-", " ");
                sanitizedName = sanitizedName.SanitizeForFile().Replace("Payload   ", "");
                if (sanitizedName.Contains("&#39;")) // Fix ' in title
                    sanitizedName = sanitizedName.Replace("&#39;", "'");
                sanitizedName = Regex.Replace(sanitizedName, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
                // Capitalize each word in title
                if (sanitizedName.StartsWith(" ")) // Remove first char if string starts with a space
                    sanitizedName = sanitizedName.Remove(0, 1);

                try
                {
                    // Assign path
                    string path = PayloadsDirectory + sanitizedName + PayloadExtension;
                    if (File.Exists(path))
                    {
                        tempPayload.Code = File.ReadAllText(path); // Read payload file
                    }
                    else
                    {
                        // Cleanup payload code
                        tempPayload.Code = WebsiteScraper.ExtractPayloadCode(payload);
                        tempPayload.Code = tempPayload.Code.Replace("\n", "\r\n");

                        // Check if payload has empty code
                        if (tempPayload.Code.Length != 0)
                            File.WriteAllText(path, tempPayload.Code);
                    }

                    // Download Completed!
                    IsUpdateAvailable = false;
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Unable to download file/s.", ex.Message);
                }
            }
        }

        // Loads Local & Online Payloads
        public static void Initialize()
        {
            try
            {
                // Check & Create Directory
                CheckDirectory();

                // Get local payloads
                GetLocalPayloads();

                // Get Online Payloads
                GetOnlinePayloads();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Unable to load file/s.", ex.Message);
            }
        }

        // Get local payloads
        private static void GetLocalPayloads()
        {
            // Load supported filetypes
            var files = Directory.GetFiles(PayloadsDirectory).Where(file => Regex.IsMatch(file, @"^.+\.(duck|txt)$"));

            // Get script path
            foreach (
                string filePath in
                files.Where(filePath => !Setting.Payloads.Contains(Path.GetFileNameWithoutExtension(filePath))))
            {
                //Add payload name to payloads list
                Setting.Payloads.Add(Path.GetFileNameWithoutExtension(filePath));
                LocalPayloadCount = Setting.Payloads.Count;
            }
        }

        // Get online payloads
        private static void GetOnlinePayloads()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                // Retrieve website page source
                string pageSource = Main.Client.DownloadString(PayloadsUrl);

                // Break Payloads Page into list
                string tempPageSource = WebsiteScraper.GetBetween(pageSource, "<ul>", "</ul>");

                // Count number of items in list
                OnlinePayloadCount = Regex.Matches(tempPageSource, "<li>").Cast<Match>().Count();
            }
        }

        #endregion
    }

    internal static class WebsiteScraper
    {
        public static string ExtractPayloadCode(Payload payload)
        {
            if (Main.Client.DownloadString(payload.Link).Contains("<code>"))
                return GetBetween(Main.Client.DownloadString(payload.Link), "<code>", "</code>");

            return Main.Client.DownloadString(payload.Link).Contains("<pre>")
                ? GetBetween(Main.Client.DownloadString(payload.Link), "<pre>", "</pre>")
                : string.Empty;
        }

        public static string GetBetween(string source, string begin, string end)
            =>
                source.Substring(source.IndexOf(begin, StringComparison.Ordinal) + begin.Length,
                    source.IndexOf(end, source.IndexOf(begin, StringComparison.Ordinal) + begin.Length,
                        StringComparison.Ordinal) - (source.IndexOf(begin, StringComparison.Ordinal) + begin.Length));

        public static string SanitizeForFile(this string value)
            => string.Concat(value.Split(Path.GetInvalidFileNameChars()));
    }

    public struct Payload
    {
        public string Link { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}