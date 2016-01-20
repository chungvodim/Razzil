
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
            //var regex = new Regex(this.Signs);
            //var match = regex.Match(content);

            //if (match.Success)
            //{
            //    return new ParseResult() { IsSuccessful = true, Value = match.Groups[1].Value };
            //}
            //else
            //{
            //    return new ParseResult() { IsSuccessful = false };
            //}
            if (this.Context.LastPage.Contains(this.Sign))
            {
                return await base.Execute();
            }
            else
            {
                return TransactionResult.Failed;
            }
        }
    }
}
