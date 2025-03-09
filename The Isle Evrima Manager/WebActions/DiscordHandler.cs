using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.IO;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.WebActions
{
    public static class DiscordHandler
    {
        /// <summary>
        /// Sends a simple Discord webhook message to the server configured in Manager settings
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <param name="error">Indicate if this is an error message. Defaults to no (false)</param>
        /// <returns></returns>
        public static async Task SendWebhook(string message,LogType type)
        {
            const string colorBlue = "1F61E6";
            const string colorGreen = "80E61F";
            const string colorRed = "E7421F";
            const string colorPurple = "C61FE6";
            const string colorYellow = "E6C71F";

            string alertColor = colorBlue;
            if(type == LogType.Error) alertColor = colorRed;
            if(type == LogType.Warning) alertColor = colorYellow;
            if (message.Contains("Downloading") || message.Contains("starting")) alertColor = colorPurple;
            if (message.Contains("stopped") || message.Contains("started")) alertColor = colorGreen;
            if(message.Contains("force stopping")) alertColor = colorRed;

            var WebHook = new
            {
                username = "EVRIME Server Manager",
                content = "",
                avatar_url = "https://github.com/Crash0v3r1de/the-isle-evrima-manager/raw/refs/heads/main/The%20Isle%20Evrima%20Manager/manager_icon_all_sizes.ico",
                embeds = new List<object> {
                        new
                        {
                            title = "The Isle EVRIMA Server Manager Notification",
                            description = message,
                            color = int.Parse(alertColor, System.Globalization.NumberStyles.HexNumber)
                        },
                    }
                };
            if (!string.IsNullOrWhiteSpace(ManagerGlobalTracker.discordWebhookURL))
            {
                string EndPoint = string.Format(ManagerGlobalTracker.discordWebhookURL);
                var content = new StringContent(JsonConvert.SerializeObject(WebHook), Encoding.UTF8, "application/json");
                var task = Client.PostAsync(EndPoint, content);
                task.Wait();
                if (!task.Result.IsSuccessStatusCode) { Logger.Log("Invalid Discord URL in Manager Settings!", LogType.Debug); }
            }
            else {
                Logger.Log("Discord alert attempted, no Webhook URL configured but is enabled!",LogType.Debug);
            }
        }

        #region Private Methods
        private static HttpClient client;
        private static HttpClient Client
        {
            get
            {
                if (client == null)
                    client = new HttpClient();

                return client;
            }
        }
        #endregion
    }
}
