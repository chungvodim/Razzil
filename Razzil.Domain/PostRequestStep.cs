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
        public PostRequestStep(StepContext context)
        {
            this.Context = context;
            this.Client = new HttpClient() { Timeout = new TimeSpan(0, 3, 0) };
        }
        public override void GetRequest()
        {
            throw new NotImplementedException();
        }

        public override void PostRequest()
        {
            throw new NotImplementedException();
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
