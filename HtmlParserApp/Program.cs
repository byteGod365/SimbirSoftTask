using System;
using HtmlParserApp.Parser;
using HtmlParserApp.Data;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using HtmlParserApp.Parser.SimbirSoftParser;
using AngleSharp;
using System.Threading.Tasks;

namespace HtmlParserApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> result = ParserWorker.Worker("https://www.simbirsoft.com");
            foreach (var pair in result)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }
            Console.ReadLine();
        }
    }
}
