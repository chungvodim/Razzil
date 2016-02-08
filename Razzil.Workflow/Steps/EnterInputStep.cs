using OpenQA.Selenium;
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
            var inputElement = this.Context.WebDriver.FindElement(By.XPath(this.XPath));
            switch (this.InputType)
            {
                case "UserName":
                    inputElement.SendKeys(this.Context.TransactionModel.UserName);
                    break;
                case "Password":
                    inputElement.SendKeys(this.Context.TransactionModel.Password);
                    break;
                case "Captcha": break;
                case "OTP": break;
                case "FromAccountName": break;
                case "FromAccountNumber": break;
                case "ToAccountName": break;
                case "ToAccountNumber": break;
                case "Amount": break;
            }
            inputElement.SendKeys(this.Name);
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
