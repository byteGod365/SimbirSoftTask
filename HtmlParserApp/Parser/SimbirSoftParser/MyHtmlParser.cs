using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Net;
using System.Net.Http;
using AngleSharp;
using System.Text.RegularExpressions;
using HtmlParserApp.Parser;
using AngleSharp.Dom;
using System.IO;
using HtmlParserApp.Data;
using HtmlParserApp.Tools;

namespace HtmlParserApp.Parser.SimbirSoftParser
{
    public class MyHtmlParser : IHtmlParser<Dictionary<string, int>>
    {
        public Dictionary<string, int> GetInformation(Task<IHtmlDocument> document)
        {
            var doc = document.Result;
            var content = doc.QuerySelector("html").TextContent;
            Dictionary<string, int> statistic = Tools.Tools.TextProcessing(content);

            List<string> keys = statistic.Keys.ToList();
            keys.Sort();
            var statisticByte = Tools.Tools.GetData(statistic);
            Statistic t = new Statistic
            {
                Url = doc.Url,
                DateOfParsing = "",
                Data = statisticByte
            };
            using(var ctx = new ParserDbContext())
            {
                Console.WriteLine(ctx.Statistics.Count());
            }
            using (var ctx = new ParserDbContext())
            {
                ctx.Add(t);
                ctx.SaveChanges();
            }
            return statistic;
        }

        public Dictionary<string, int> GetInformation(IDocument document)
        {
            var content = document.QuerySelector("html").TextContent;
            Dictionary<string, int> statistic = Tools.Tools.TextProcessing(content);

            List<string> keys = statistic.Keys.ToList();
            keys.Sort();
            var statisticByte = Tools.Tools.GetData(statistic);
            Statistic t = new Statistic
            {
                Url = document.Url,
                DateOfParsing = "",
                Data = statisticByte
            };
            using (var ctx = new ParserDbContext())
            {
                ctx.Add(t);
                ctx.SaveChanges();
            }
            return statistic;
        }
    }
}
