using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Domain
{
    public abstract class Step : DomainObject
    {
        protected StepContext Context { get; set; }
        protected int PreviousStepId { get; set; }
        protected int CurrentStepId { get; set; }
        protected int NextStepId { get; set; }
        protected string Url { get; set; }
        protected string[] Patterns { get; set; }
        protected string[] Signs { get; set; }
        protected IEnumerable<KeyValuePair<string, string>> Params { get; set; }

        protected HttpClient Client { get; set; }

        public delegate void StepStartHandler();
        public delegate void StepSuccessHandler();
        public delegate void StepFailedHandler();

        public StepStartHandler OnStartStep;
        public StepSuccessHandler OnStepSuccess;
        public StepFailedHandler OnStepFailed;

        public abstract void GetRequest();
        public abstract void PostRequest();
        public abstract void Log();
        public abstract void Parse();
        private Step CreateNextStep()
        {
            int nextStepType = GetNextStepType();
            Step nextStep;
            switch (nextStepType)
            {
                case 1: nextStep = new GetRequestStep(this.NextStepId, this.Context); break;
                case 2: nextStep = new PostRequestStep(this.NextStepId, this.Context); break;
                case 3:  nextStep = new MatchingStep(this.NextStepId, this.Context); break;
                default: nextStep = new GetRequestStep(this.NextStepId, this.Context); break;
            }
            return nextStep;
        }

        private int GetNextStepType()
        {
            return 1;
        }

        protected void Initialize(int currentStepId, StepContext context)
        {
            this.CurrentStepId = currentStepId;
            this.Context = context;
            this.Url = "";
            this.PreviousStepId = 1;
            this.NextStepId = 3;
            this.Signs = new string[] { };
            this.Patterns = new string[] { };
            this.Params = new List<KeyValuePair<string, string>>();
            this.Client = new HttpClient() { Timeout = new TimeSpan(0, 3, 0) };
        }
        public void Execute()
        {
            Step nextStep = CreateNextStep();
            nextStep.Execute();
        }

    }
}
