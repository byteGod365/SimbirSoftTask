using System;
using System.Collections.Generic;
using System.Text;
using HtmlParserApp.Parser.SimbirSoftParser;

namespace HtmlParserApp.Parser.SimbirSoftParser
{
    public class ParserWorker
    {
        public static Dictionary<string, int> Worker(string url)
        {
            var htmlLoader = new MyHtmlLoader(url);
            MyHtmlParser myHtmlParser = new MyHtmlParser(); 
            return myHtmlParser.GetInformation(htmlLoader.GetSource());
        }
    }
}
