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
        private static Workflow.Worker workflow;
        static void Main(string[] args)
        {
            StepContext stepContext = new StepContext(1);
            stepContext.TransactionModel.UserName = "chungvodim1";
            stepContext.TransactionModel.Password = "Asdfgh123$%";
            workflow = new Workflow.Worker(stepContext);
            workflow.OnStart += OnTransactionStart;
            workflow.OnSuccess += OnTransactionSuccess;
            workflow.OnFail += OnTransactionFail;
            workflow.OnInprogress += OnTransactionInprogress;
            workflow.Execute();
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
