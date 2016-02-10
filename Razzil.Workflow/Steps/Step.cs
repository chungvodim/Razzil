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
        protected int? PreviousStepId { get; set; }
        protected int CurrentStepId { get; set; }
        protected int? NextStepId { get; set; }
        protected int? SecondNextStepId { get; set; }
        protected string InputType { get; set; }
        protected string Url { get; set; }
        protected string Key { get; set; }
        protected string Pattern { get; set; }
        protected string XPath { get; set; }
        protected string XPathAttribute { get; set; }
        protected string Sign { get; set; }
        protected bool IsConditionType { get; set; }
        protected Dictionary<string, string> QueryStrings { get; set; }
        protected Dictionary<string, string> Params { get; set; }


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
                            case 1: nextStep = new HttpGetStep(this.NextStepId.Value, this.Context); break;
                            case 2: nextStep = new HttpPostStep(this.NextStepId.Value, this.Context); break;
                            case 3: nextStep = new MatchingStep(this.NextStepId.Value, this.Context); break;
                            default: nextStep = new HttpGetStep(this.NextStepId.Value, this.Context); break;
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
                    var step = db.Steps.Where(x => x.Bank.Name == this.Context.BankName && x.CurrentStepId == nextStepId).FirstOrDefault();
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

        protected void Initialize(int currentStepId, StepContext context)
        {
            using (var db = new Entities())
            {
                var step = db.Steps.Where(x => x.Bank.Name == this.Context.BankName && x.CurrentStepId == this.CurrentStepId).FirstOrDefault();
                this.CurrentStepId = currentStepId;
                this.Context = context;
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
        public virtual async Task<TransactionResult> Execute()
        {
            Step nextStep = CreateNextStep();
            if (nextStep != null)
            {
                return await nextStep.Execute();
            }
            else
            {
                return TransactionResult.Successful;
            }
        }

    }
}
