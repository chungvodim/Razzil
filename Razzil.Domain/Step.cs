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
        public StepContext Context { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
        public string[] Params { get; set; }
        public string[] Signs { get; set; }

        protected HttpClient Client { get; set; }

        public delegate void StepStartHandler();
        public delegate void StepSuccessHandler();
        public delegate void StepFailedHandler();

        public StepStartHandler OnStartStep;
        public StepSuccessHandler OnStepSuccess;
        public StepFailedHandler OnStepFailed;

        //public Step(StepContext context)
        //{
        //    this.Context = context;
        //    this.Client = new HttpClient() { Timeout = new TimeSpan(0, 3, 0) };
        //}
        public abstract void GetRequest();
        public abstract void PostRequest();
        public abstract void Log();
        public abstract void Parse();

    }
}
