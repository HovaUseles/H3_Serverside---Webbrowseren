using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace H3_Serverside___Webbrowseren.Data_Access
{
    internal  class WebPageClient : IWebpageClient
    {
        public async Task<string> GetWebsite(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (UriFormatException ex)
            {
                throw new Exception("The Uri was not valid format", ex);
            }
            catch (HttpRequestException ex)
            {
                switch(ex.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new Exception("The page was not found", ex);
                    default:
                        throw ex;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
