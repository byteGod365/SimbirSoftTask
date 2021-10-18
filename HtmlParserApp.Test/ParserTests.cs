using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Parser;
using HtmlParserApp.Parser.SimbirSoftParser;
using Xunit;

namespace HtmlParserApp.Test
{
    public class ParserTests
    {
        [Fact]
        public async Task ResultCheckAsync()
        {
            var html = @"<html>
                         <head>
                            <title></title>
                        </head>
                        <body>
                        <h1>Этот текст используется для теста парсера
                            Этот текст используется для теста парсера</h1>
                        <p>Простой пример для проверки
                            Простой пример для проверки
                             Простой пример для проверки</p>
                        <p>  Программа работает отлично
                                Программа работает отлично
                                 Программа работает отлично
                                    Программа работает отлично
                        </div></p>
                        </body>
                        </html>";
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var doc = await context.OpenAsync(req => req.Content(html));

            MyHtmlParser parser = new MyHtmlParser();
            Dictionary<string, int> result = parser.GetInformation(doc);
            Dictionary<string, int> trueResult = new Dictionary<string, int>() 
            { 
                { "ЭТОТ", 2 },
                { "ТЕКСТ", 2},
                { "ИСПОЛЬЗУЕТСЯ", 2},
                { "ДЛЯ", 5},
                { "ТЕСТА", 2},
                { "ПАРСЕРА", 2},
                { "ПРОСТОЙ", 3},
                { "ПРИМЕР", 3},
                { "ПРОВЕРКИ", 3},
                { "ПРОГРАММА", 4},
                { "РАБОТАЕТ", 4},
                { "ОТЛИЧНО", 4}
            };
            Assert.Equal(trueResult, result);
        }
    }
}
