using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Domain
{
    public class GetRequestStep : Step
    {

        public GetRequestStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override void GetRequest()
        {
            var response = this.Client.GetAsync(this.Url).Result;
            this.Context.LastPage = response.Content.ReadAsStringAsync().Result;
        }

        public override void Log()
        {
            throw new NotImplementedException();
        }

        public override void Parse()
        {
            throw new NotImplementedException();
        }

        public override void PostRequest()
        {
            throw new NotImplementedException();
        }
    }
}
