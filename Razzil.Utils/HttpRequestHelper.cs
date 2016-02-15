using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Utils
{
    public static class HttpRequestHelper
    {
        public static Dictionary<string, string> InitHttpRequestParams(this string strings, char splitter)
        {
            var httpRequestParams = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(strings))
            {
                string[] queryStrings = strings.Split(splitter);
                for (int i = 0; i < queryStrings.Length; i++)
                {
                    httpRequestParams[queryStrings[i]] = "";
                }
            }
            return httpRequestParams;
        }
    }
}
