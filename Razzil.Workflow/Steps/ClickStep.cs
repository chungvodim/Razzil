using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Razzil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    public class ClickStep : Step
    {

        public ClickStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override async Task<TransactionResultEnum> Execute()
        {
            var ButtonElement = this.Context.WaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.XPath(this.XPath)));
            ButtonElement.Click();
            var signElement = this.Context.WaitDriver.Until(ExpectedConditions.ElementIsVisible(By.XPath(this.Sign)));
            if (signElement != null)
            {
                return await base.Execute();
            }
            else
            {
                this.Context.StatusCode = StatusCode.BANK_PAGE_CHANGED;
                return TransactionResultEnum.Failed;
            }
        }
    }
}
