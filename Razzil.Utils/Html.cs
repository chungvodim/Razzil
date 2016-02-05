using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Utils
{
    public static class Html
    {
        public static string GetNodeAttribute(string page, string xPath, string attribute = "")
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);
            var node = doc.DocumentNode.SelectSingleNode(xPath);
            if (node != null)
            {
                return string.IsNullOrWhiteSpace(attribute) ? node.InnerText : node.Attributes[attribute].Value;
            }
            else
            {
                return "";
            }
        }
        public static Dictionary<string, string> InitHttpRequestParams(this string strings, char splitter)
        {
            var httpRequestParams = new Dictionary<string, string>();
            string[] queryStrings = strings.Split(splitter);
            for (int i = 0; i < queryStrings.Length; i++)
            {
                httpRequestParams[queryStrings[i]] = "";
            }
            return httpRequestParams;
        }
    }
}
