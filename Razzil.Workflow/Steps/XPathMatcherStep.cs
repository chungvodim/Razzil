using Razzil.Models;
using Razzil.Utils;
using Razzil.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    class XPathMatcherStep : Step
    {
        public XPathMatcherStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override async Task<TransactionResult> Execute()
        {
            var result = Html.GetNodeAttribute(this.Context.LastPage, this.XPath, this.Attribute);
            if (!string.IsNullOrWhiteSpace(result))
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
