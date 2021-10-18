using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;

namespace HtmlParserApp.Parser
{
    public class MyHtmlLoader
    {
        HttpClient client;
        string url;

        public MyHtmlLoader(string Url)
        {
            client = new HttpClient();
            url = Url;
        }

        public async Task<IHtmlDocument> GetSource()
        {
            var response = await client.GetAsync(url);
            string source = null;

            if(response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);
            return document;
        }
    }
}
