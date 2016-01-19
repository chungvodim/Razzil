using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Domain
{
    public abstract class Step : DomainObject
    {
        public StepContext Context { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
        public string Params { get; set; }
        public Step(StepContext context)
        {
            this.Context = context;
        }
        public abstract void Request();
        public abstract void Log();
        public abstract void Parse();

    }
}
