using H3_Serverside___Webbrowseren.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Serverside___Webbrowseren.Manager
{
    internal class WebsiteManager
    {
        public IWebpageClient WebClient { get; }
        public WebsiteManager(IWebpageClient webpageClient)
        {
            WebClient = webpageClient;
        }

        /// <summary>
        /// Get the html from a website on the URL
        /// </summary>
        /// <param name="url">The website url</param>
        /// <returns>The website html contents</returns>
        public async Task<string> GetWebsite(string url)
        {
            return await WebClient.GetWebsite(url);
        }
    }
}
