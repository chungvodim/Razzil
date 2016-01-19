
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Razzil.Domain
{
    class MatchingStep : Step
    {
        public MatchingStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override void GetRequest()
        {
            throw new NotImplementedException();
        }

        public override void Log()
        {
            throw new NotImplementedException();
        }

        public override void Parse()
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
            throw new NotImplementedException();
        }

        public override void PostRequest()
        {
            throw new NotImplementedException();
        }
    }
}
