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
        protected StepContext Context { get; set; }
        protected int? PreviousStepId { get; set; }
        protected int CurrentStepId { get; set; }
        protected int? NextStepId { get; set; }
        protected string Url { get; set; }
        protected string Pattern { get; set; }
        protected string XPath { get; set; }
        protected string Sign { get; set; }
        protected IEnumerable<KeyValuePair<string, string>> Params { get; set; }

        protected HttpClient Client { get; set; }

        //public delegate void StepStartHandler();
        //public delegate void StepSuccessHandler();
        //public delegate void StepFailedHandler();

        //public StepStartHandler OnStartStep;
        //public StepSuccessHandler OnStepSuccess;
        //public StepFailedHandler OnStepFailed;
        private Step CreateNextStep()
        {
            if (this.NextStepId != null)
            {
                int nextStepType = GetNextStepType();
                Step nextStep;
                switch (nextStepType)
                {
                    case 1: nextStep = new GetRequestStep(this.NextStepId.Value, this.Context); break;
                    case 2: nextStep = new PostRequestStep(this.NextStepId.Value, this.Context); break;
                    case 3: nextStep = new RegexMatcherStep(this.NextStepId.Value, this.Context); break;
                    default: nextStep = new GetRequestStep(this.NextStepId.Value, this.Context); break;
                }
                return nextStep;
            }
            else
            {
                return null;
            }
        }

        private int GetNextStepType()
        {
            return 1;
        }

        protected void Initialize(int currentStepId, StepContext context)
        {
            this.CurrentStepId = currentStepId;
            this.Context = context;
            this.Name = "Test Step";
            this.Url = "";
            this.PreviousStepId = 1;
            this.Sign = "";
            this.Pattern = "";
            this.XPath = "";
            this.Params = new List<KeyValuePair<string, string>>();
            this.Client = new HttpClient() { Timeout = new TimeSpan(0, 3, 0) };
        }
        public virtual async Task<bool> Execute()
        {
            Step nextStep = CreateNextStep();
            if (nextStep != null)
            {
                return await nextStep.Execute();
            }
            else
            {
                return false;
            }
        }

    }
}
