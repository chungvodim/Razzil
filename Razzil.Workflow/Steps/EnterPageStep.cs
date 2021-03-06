﻿using Razzil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    public class EnterPageStep : Step
    {

        public EnterPageStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override async Task<TransactionResultEnum> Execute()
        {
            this.Context.WebDriver.Navigate().GoToUrl(this.Url);
            this.Context.LastPage = this.Context.WebDriver.PageSource;
            if (this.Context.LastPage.Contains(this.Sign))
            {
                return await base.Execute();
            }
            else
            {
                return TransactionResultEnum.Failed;
            }
        }
    }
}
