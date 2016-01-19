using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Domain
{
    public class PostRequestStep : Step
    {
        public PostRequestStep(int currentStepId, StepContext context)
        {
            Initialize(currentStepId, context);
        }
        public override void GetRequest()
        {
            throw new NotImplementedException();
        }

        public override void PostRequest()
        {
            var response = this.Client.PostAsync(this.Url, new FormUrlEncodedContent(this.Params)).Result;
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
    }
}
