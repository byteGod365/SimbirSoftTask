using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserApp.Data
{
    public class Statistic
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string DateOfParsing { get; set; }
        public byte[] Data { get; set; }
    }
}
