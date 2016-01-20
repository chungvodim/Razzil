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
    public class Workflow
    {
        public StartTransactionHandler OnStart { get; set; }
        public TransactionSuccessHandler OnSuccess { get; set; }
        public TransactionFailHandler OnFail { get; set; }
        private Step Step { get; set; }

        public Workflow(Step step)
        {
            this.Step = step;
        }

        public async void Execute()
        {
            OnStart(this.Step);
            var result = await this.Step.Execute();
            if (!result)
            {
                OnFail(this.Step);
            }
        }
    }
}
