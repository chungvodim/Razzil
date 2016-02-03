using Razzil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    public class GetCaptchaStep : Step
    {
        public GetCaptchaStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override async Task<TransactionResult> Execute()
        {
            using (var response = this.Client.GetAsync(this.Url).Result)
            {
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
}
