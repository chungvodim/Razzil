using OpenQA.Selenium;
using Razzil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    public delegate void StartTransactionHandler(Step step);
    public delegate void TransactionSuccessHandler(Step step);
    public delegate void TransactionFailHandler(Step step);
    public delegate void TransactionInprogressHandler(Step step);
    public class Workflow
    {
        public StartTransactionHandler OnStart { get; set; }
        public TransactionSuccessHandler OnSuccess { get; set; }
        public TransactionFailHandler OnFail { get; set; }
        public TransactionInprogressHandler OnInprogress { get; set; }
        private Step Step { get; set; }

        public Workflow(Step step)
        {
            this.Step = step;
        }

        public async void Execute()
        {
            try
            {
                OnStart(this.Step);
                var result = await this.Step.Execute();
                switch (result)
                {
                    case TransactionResult.Failed: OnFail(this.Step); break;
                    case TransactionResult.Inprogress: OnInprogress(this.Step); break;
                    case TransactionResult.Successful: OnSuccess(this.Step); break;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.GetType() == typeof(WebDriverTimeoutException))
                {
                    this.Step.Context.StatusCode = StatusCode.TIMEOUT_ERROR;
                }
                else
                {
                    this.Step.Context.StatusCode = StatusCode.UNKNOWN;
                }
                OnFail(this.Step);
            }
        }
    }
}
