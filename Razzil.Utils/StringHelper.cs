
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Razzil.Utils
{
    public static class StringHelper
    {
        private static Regex removeWhitespacesRegex = new Regex(@"\s+", RegexOptions.Compiled);
        public static string ReplaceAtIndex(string org, int index, char evaluator)
        {
            StringBuilder sb = new StringBuilder(org);
            sb[index] = evaluator;
            return sb.ToString();
        }
        public static string RemoveWhitespaces(string src, string replacement = "")
        {
            return removeWhitespacesRegex.Replace(src, replacement);
        }
    }
}
