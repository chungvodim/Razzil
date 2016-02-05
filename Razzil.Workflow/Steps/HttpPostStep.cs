using Razzil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    public class HttpPostStep : Step
    {
        public HttpPostStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override async Task<TransactionResult> Execute()
        {
            foreach (var key in this.Params.Keys)
            {
                if (!string.IsNullOrWhiteSpace(this.Context.Params[key]))
                {
                    Params[key] = this.Context.Params[key];
                }
            }
            using (var response = this.Context.Client.PostAsync(this.Url, new FormUrlEncodedContent(this.Params)).Result)
            {
                this.Context.LastPage = response.Content.ReadAsStringAsync().Result;
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
