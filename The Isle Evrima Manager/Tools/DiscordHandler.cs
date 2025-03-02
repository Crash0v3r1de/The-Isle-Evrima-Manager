using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.Tools
{
    public static class DiscordHandler
    {        
        public static async Task SendWebhook(string message,bool error)
        {
            const string colorBlue = "1F61E6";
            const string colorGreen = "80E61F";
            const string colorRed = "E7421F";
            const string colorPurple = "C61FE6";
            const string colorYellow = "E6C71F";

            var SuccessWebHook = new
            {
                username = "Text of the message",
                content = "This is the main content section",
                avatar_url = "https://github.com/Crash0v3r1de/the-isle-evrima-manager/raw/refs/heads/main/The%20Isle%20Evrima%20Manager/manager_icon_all_sizes.ico",
                // Embedding example - I'm lazy, copy pasta from https://gist.github.com/lot224/e6e0398c2c62a334168a63f09ffff2bc
                //    embeds = new List<object>
                //    {
                //        new
                //        {
                //            title = "Embed",
                //            url="https://www.google.com/search?q=something",
                //            description="This is the description section of the Embed, the embed has a color bar to the left side",
                //            color= int.Parse(colorGreen, System.Globalization.NumberStyles.HexNumber)
                //        },

                //        new
                //        {
                //            title = "Another Embed",
                //            url="https://www.google.com/search?q=somethingElse",
                //            description="This is the description section of the Embed, the embed has a color bar to the left side",
                //            color= int.Parse(colorPurple, System.Globalization.NumberStyles.HexNumber)
                //        }
                //    }
                //};
                embeds = new List<object> {
                        new
                        {
                            title = "The Isle EVRIMA Server Manager Notification",
                            url = "https://github.com/Crash0v3r1de/the-isle-evrima-manager/tree/main/The%20Isle%20Evrima%20Manager",
                            description = message,
                            color = int.Parse(colorRed, System.Globalization.NumberStyles.HexNumber)
                        },
                    }
                };

            string EndPoint = string.Format(ManagerGlobalTracker.discordWebhookURL);
            var content = new StringContent(JsonConvert.SerializeObject(SuccessWebHook), Encoding.UTF8, "application/json");
            Client.PostAsync(EndPoint, content).Wait();
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
