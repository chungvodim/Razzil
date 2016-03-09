using Razzil.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.IntegrationTest
{
    class Program
    {
        private static Workflow.Worker worker;
        static void Main(string[] args)
        {
            int bankId = 1;
            StepContext stepContext = new StepContext(bankId);
            stepContext.InitTransactionModel("123456789", 1, "987654321", 1, 10000, "transfer money");
            worker = new Worker(stepContext);
            worker.OnStart += OnTransactionStart;
            worker.OnSuccess += OnTransactionSuccess;
            worker.OnFail += OnTransactionFail;
            worker.OnInprogress += OnTransactionInprogress;
            worker.Execute();
        }

        private static void OnTransactionInprogress(Step step)
        {
            Console.WriteLine("Transaction is inprogress at step : {0}", step.Name);
        }

        private static void OnTransactionFail(Step step)
        {
            Console.WriteLine("Transaction is Failed at step : {0}", step.Name);
        }

        private static void OnTransactionStart(Step step)
        {
            Console.WriteLine("Start Transaction");
        }

        private static void OnTransactionSuccess(Step step)
        {
            Console.WriteLine("Transaction is successful");
        }
    }
}
