using Razzil.Models;
using Razzil.Workflow;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Razzil.WCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BankService : IBankService
    {
        public HttpClient CallBackHttpClient { get; set; }
        public string CallBackURL { get; set; }
        public string tnxId { get; set; }
        public BankService()
        {
            CallBackHttpClient = new HttpClient() { Timeout = new TimeSpan(0, 0, 180) }; ;
        }
        public string Transfer(string tnxId, string fromAccountNumber, int fromBankId, string toAccountNumber, int toBankId, 
            decimal amount, string content, string callBackUrl)
        {
            try
            {
                this.CallBackURL = callBackUrl;
                this.tnxId = tnxId;
                StepContext stepContext = new StepContext(fromBankId);
                stepContext.InitTransactionModel(fromAccountNumber, fromBankId, toAccountNumber, toBankId, amount, content);
                Worker worker = new Worker(stepContext);
                worker.OnStart += OnTransactionStart;
                worker.OnSuccess += OnTransactionSuccess;
                worker.OnFail += OnTransactionFail;
                worker.OnInprogress += OnTransactionInprogress;
                worker.Execute();
                return string.Join("-", tnxId, fromAccountNumber, fromBankId, toAccountNumber, toBankId, amount, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new WebFaultException(HttpStatusCode.BadRequest);// Use it for REST
            }
            //catch (Exception ex)
            //{
            //    //throw new FaultException<ProductFault>(new ProductFault(ex.Message), "unknown reason");
            //    throw new FaultException(ex.Message, new FaultCode("internal error"));// Use it for SOAP
            //}
        }

        public string GetBalance(string tnxId, string accountNumber, string bankId, string callBackUrl)
        {
            try
            {
                return string.Join("-", tnxId, accountNumber, bankId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new WebFaultException(HttpStatusCode.BadRequest);// Use it for REST
            }
            //catch (Exception ex)
            //{
            //    throw new FaultException(ex.Message, new FaultCode("internal error"));// Use it for SOAP
            //}
        }

        private HttpContent CreateHttpContent(Step step, TransactionResultEnum transactionResult)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("tnxId", this.tnxId));
            postData.Add(new KeyValuePair<string, string>("step", step.CurrentStepId.ToString()));
            postData.Add(new KeyValuePair<string, string>("status", transactionResult.ToString()));
            HttpContent content = new FormUrlEncodedContent(postData);
            return content;
        }

        private void OnTransactionInprogress(Step step)
        {
            CallBackHttpClient.PostAsync(this.CallBackURL, CreateHttpContent(step, TransactionResultEnum.Inprogress));
        }

        private void OnTransactionFail(Step step)
        {
            CallBackHttpClient.PostAsync(this.CallBackURL, CreateHttpContent(step, TransactionResultEnum.Failed));
        }

        private void OnTransactionStart(Step step)
        {
            CallBackHttpClient.PostAsync(this.CallBackURL, CreateHttpContent(step, TransactionResultEnum.Started));
        }

        private void OnTransactionSuccess(Step step)
        {
            CallBackHttpClient.PostAsync(this.CallBackURL, CreateHttpContent(step, TransactionResultEnum.Inprogress));
        }
    }
}
