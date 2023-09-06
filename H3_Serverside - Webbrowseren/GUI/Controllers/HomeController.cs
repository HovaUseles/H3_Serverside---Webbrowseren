using H3_Serverside___Webbrowseren.GUI.Utilities;
using H3_Serverside___Webbrowseren.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H3_Serverside___Webbrowseren.GUI.Controllers
{
    internal class HomeController
    {
        public WebsiteManager WebManager { get; }
        public HomeController(WebsiteManager websiteManager)
        {
            WebManager = websiteManager;
        }

        /// <summary>
        /// First page, gets the html from a URL and displays its contents without HTML tags.
        /// </summary>
        public async Task Index()
        {
            bool looper = true;
            do
            {
                ViewComponents.DisplayViewHeader("Webbrowser");
                Console.WriteLine();
                string validUrlRegex = @"https:\/\/([A-Za-z])+\.([A-Za-z])+";
                string url = ViewComponents.GetUserInput("Enter URL:", regexValidator: validUrlRegex, preWrittenText: "https://");
                try
                {
                    string pageContents = await WebManager.GetWebsite(url);
                    string cleanedContents = RemoveHtmlTags(pageContents);
                    Console.WriteLine(cleanedContents);
                    looper = false;
                }
                catch (Exception ex)
                {
                    ErrorView(ex);
                }
            } while (looper);
        }

        /// <summary>
        /// Removes html tags from the pagecontents
        /// </summary>
        /// <param name="htmlContent"></param>
        /// <returns></returns>
        private string RemoveHtmlTags(string htmlContent)
        {
            return Regex.Replace(htmlContent, @"<[^>]*>", string.Empty);
        }

        /// <summary>
        /// Display for generic error
        /// </summary>
        /// <param name="ex">The exception the view should display</param>
        private void ErrorView(Exception ex)
        {
            Console.Clear();
            ViewComponents.DisplayViewHeader($"An error occured");
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
