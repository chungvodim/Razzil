using Razzil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    public class EnterInputStep : Step
    {

        public EnterInputStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override async Task<TransactionResult> Execute()
        {
            this.Context.WebDriver.Navigate().GoToUrl(this.Url);
            this.Context.LastPage = this.Context.WebDriver.PageSource;
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
