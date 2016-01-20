using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    public class GetRequestStep : Step
    {

        public GetRequestStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override async Task<TransactionResult> Execute()
        {
            var response = this.Client.GetAsync(this.Url).Result;
            this.Context.LastPage = response.Content.ReadAsStringAsync().Result;
            this.NextStepId = 7;
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
