
using Razzil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    class RegexMatcherStep : Step
    {
        public RegexMatcherStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override async Task<TransactionResult> Execute()
        {
            var parseValue = ParseValue(this.Context.LastPage, this.Pattern);
            if (parseValue.IsSuccessful)
            {
                this.Context.Params.Add(this.Key,parseValue.Value);
                this.NextStepId = 7;
                return await base.Execute();
            }
            else
            {
                return TransactionResult.Failed;
            }
        }

        private ParseResult ParseValue(string pattern, string content)
        {
            var regex = new Regex(pattern);
            var match = regex.Match(content);

            if (match.Success)
            {
                return new ParseResult() { IsSuccessful = true, Value = match.Groups[1].Value };
            }
            else
                return new ParseResult() { IsSuccessful = false };
        }
    }
}
