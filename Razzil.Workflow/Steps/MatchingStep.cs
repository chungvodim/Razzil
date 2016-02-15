
using Razzil.Models;
using Razzil.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    class MatchingStep : Step
    {
        public MatchingStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override async Task<TransactionResultEnum> Execute()
        {
            var content = string.IsNullOrWhiteSpace(this.XPath) ? this.Context.LastPage : HtmlHelper.GetNodeAttribute(this.Context.LastPage, this.XPath, this.XPathAttribute);
            var parseValue = ParseValue(content, this.Pattern);
            if (parseValue.IsSuccessful)
            {
                this.Context.Params.Add(this.Key, parseValue.Value);
                return await base.Execute();
            }
            else
            {
                if (this.IsConditionType)
                {
                    this.NextStepId = this.SecondNextStepId;
                    return await base.Execute();
                }
                else
                {
                    return TransactionResultEnum.Failed;
                }
            }
        }

        private ParseResult ParseValue(string pattern, string content)
        {
            if (string.IsNullOrWhiteSpace(pattern))
            {
                return new ParseResult() { IsSuccessful = true, Value = content };
            }
            else
            {
                var regex = new Regex(pattern);
                var match = regex.Match(content);

                if (match.Success)
                {
                    return new ParseResult() { IsSuccessful = true, Value = match.Groups[1].Value };
                }
                else
                {
                    return new ParseResult() { IsSuccessful = false };
                }
            }
        }
    }
}
