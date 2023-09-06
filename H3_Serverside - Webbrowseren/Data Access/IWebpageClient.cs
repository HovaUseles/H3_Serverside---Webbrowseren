using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Serverside___Webbrowseren.Data_Access
{
    internal interface IWebpageClient
    {
        /// <summary>
        /// Get website contents from URL
        /// </summary>
        /// <param name="url">Url for the website </param>
        /// <returns>Website html contents</returns>
        public Task<string> GetWebsite(string url);
    }
}
