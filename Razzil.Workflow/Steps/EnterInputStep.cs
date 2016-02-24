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
    public class EnterInputStep : Step
    {

        public EnterInputStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override async Task<TransactionResultEnum> Execute()
        {

            var inputElement = this.Context.WaitDriver.Until(ExpectedConditions.ElementIsVisible(By.XPath(this.XPath)));
            switch (this.InputType)
            {
                case "UserName":
                    inputElement.SendKeys(this.Context.TransactionModel.UserName);
                    break;
                case "Password":
                    inputElement.SendKeys(this.Context.TransactionModel.Password);
                    break;
                case "Captcha":
                    inputElement.SendKeys(this.Context.TransactionModel.Captcha);
                    break;
                case "OTP":
                    inputElement.SendKeys(this.Context.TransactionModel.OTP);
                    break;
                case "FromAccountName":
                    inputElement.SendKeys(this.Context.TransactionModel.FromAccountName);
                    break;
                case "FromAccountNumber":
                    inputElement.SendKeys(this.Context.TransactionModel.FromAccountNumber);
                    break;
                case "ToAccountName":
                    inputElement.SendKeys(this.Context.TransactionModel.ToAccountName);
                    break;
                case "ToAccountNumber":
                    inputElement.SendKeys(this.Context.TransactionModel.ToAccountNumber);
                    break;
                case "Content":
                    inputElement.SendKeys(this.Context.TransactionModel.Content);
                    break;
                case "Amount":
                    inputElement.SendKeys(this.Context.TransactionModel.Amount.ToString());
                    break;
            }

            return await base.Execute();
        }
    }
}
