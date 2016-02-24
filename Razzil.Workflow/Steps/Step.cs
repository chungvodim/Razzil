using Razzil.DataAccess.Repository;
using Razzil.Models;
using Razzil.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Workflow
{
    public abstract class Step : DomainObject
    {
        public StepContext Context { get; set; }
        public int? PreviousStepId { get; set; }
        public int CurrentStepId { get; set; }
        public int? NextStepId { get; set; }
        public int? SecondNextStepId { get; set; }
        public string InputType { get; set; }
        public string Url { get; set; }
        public string Key { get; set; }
        public string Pattern { get; set; }
        public string XPath { get; set; }
        public string XPathAttribute { get; set; }
        public string Sign { get; set; }
        public bool IsConditionType { get; set; }
        public Dictionary<string, string> QueryStrings { get; set; }
        public Dictionary<string, string> Params { get; set; }


        //public delegate void StepStartHandler();
        //public delegate void StepSuccessHandler();
        //public delegate void StepFailedHandler();

        //public StepStartHandler OnStartStep;
        //public StepSuccessHandler OnStepSuccess;
        //public StepFailedHandler OnStepFailed;
        private Step CreateNextStep()
        {
            using (var db = new Entities())
            {
                if (this.NextStepId != null)
                {
                    int? nextStepType = GetNextStepType(this.NextStepId);
                    if(nextStepType != null)
                    {
                        Step nextStep;
                        switch (nextStepType)
                        {
                            case 1: nextStep = new EnterPageStep(this.NextStepId.Value, this.Context); break;
                            case 2: nextStep = new EnterInputStep(this.NextStepId.Value, this.Context); break;
                            case 3: nextStep = new ClickStep(this.NextStepId.Value, this.Context); break;
                            case 4: nextStep = new MatchingStep(this.NextStepId.Value, this.Context); break;
                            case 5: nextStep = new GetCaptchaStep(this.NextStepId.Value, this.Context); break;
                            case 6: nextStep = new GetOTPStep(this.NextStepId.Value, this.Context); break;
                            default: nextStep = new EnterPageStep(this.NextStepId.Value, this.Context); break;
                        }
                        return nextStep;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        private int? GetNextStepType(int? nextStepId)
        {
            if(nextStepId != null)
            {
                using (var db = new Entities())
                {
                    var step = db.Steps.Where(x => x.Bank.Id == this.Context.BankId && x.CurrentStepId == nextStepId).FirstOrDefault();
                    if(step != null)
                    {
                        return step.StepTypeId;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public void Initialize(int currentStepId, StepContext context)
        {
            using (var db = new Entities())
            {
                var step = db.Steps.Where(x => x.Bank.Id == context.BankId && x.CurrentStepId == currentStepId).FirstOrDefault();
                if (step != null)
                {
                    this.Context = context;
                    this.CurrentStepId = currentStepId;
                    this.Name = step.Name;
                    this.Url = step.Url;
                    this.PreviousStepId = step.PreviousStepId;
                    this.Sign = step.Sign;
                    this.Pattern = step.Pattern;
                    this.XPath = step.XPath;
                    this.XPathAttribute = step.XPathAttribute;
                    this.NextStepId = step.NextStepId0;// default next step
                    this.SecondNextStepId = step.NextStepId1;// default next step
                    this.InputType = step.InputType.Name;
                    this.QueryStrings = step.QueyStrings.InitHttpRequestParams(';');
                    this.Params = step.Params.InitHttpRequestParams(';');
                }
            }
                
        }
        public virtual async Task<TransactionResultEnum> Execute()
        {
            Step nextStep = CreateNextStep();
            if (nextStep != null)
            {
                return await nextStep.Execute();
            }
            else
            {
                return TransactionResultEnum.Successful;
            }
        }

        public void Dispose()
        {
            this.Context.WebDriver.Quit();
        }
    }
}
