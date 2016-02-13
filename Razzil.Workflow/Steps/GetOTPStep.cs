using Razzil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    public class GetOTPStep : Step
    {
        public GetOTPStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override async Task<TransactionResult> Execute()
        {
            using (var response = this.Context.httpClient.GetAsync(this.Url).Result)
            {
                this.Context.LastPage = await response.Content.ReadAsStringAsync();
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
}
