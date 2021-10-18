using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParserApp.Parser
{
    public interface IHtmlParser<T>
    {
        T GetInformation(Task<IHtmlDocument> document);
    }
}
