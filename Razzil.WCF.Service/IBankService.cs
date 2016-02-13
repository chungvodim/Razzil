using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Razzil.WCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBankService
    {
        HttpClient CallBackHttpClient { get; set; }
        string CallBackURL { get; set; }
        string tnxId { get; set; }
        //[OperationContract(IsOneWay = true)]
        [OperationContract]
        [FaultContract(typeof(ProductFault))]
        //[WebGet(UriTemplate = "/Transfer?id={id}&accountname={accountname}")]
        [WebInvoke(UriTemplate = "/Transfer?tnxId={tnxId}&fromAccountNumber={fromAccountNumber}&fromBankId={fromBankId}&toAccountNumber={toAccountNumber}&toBankId={toBankId}&amount={amount}&content={content}&callBackUrl={callBackUrl}",
            Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        string Transfer(string tnxId, string fromAccountNumber, int fromBankId, string toAccountNumber, int toBankId,
            decimal amount, string content, string callBackUrl);

        [OperationContract]
        [FaultContract(typeof(ProductFault))]
        [WebInvoke(UriTemplate = "/GetBalance?tnxId={tnxId}&accountNumber={accountNumber}&bankId={bankId}&callBackUrl={callBackUrl}",
            Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        string GetBalance(string tnxId, string accountNumber, string bankId, string callBackUrl);

        //[OperationContract(AsyncPattern = true)]
        //IAsyncResult BeginCalculateTotalValueOfStock(string id, AsyncCallback cb,
        //object s);
        //int EndCalculateTotalValueOfStock(IAsyncResult r);
    }

    [DataContract]
    public class ProductFault
    {
        public ProductFault(string msg)
        {
            FaultMessage = msg;
        }

        [DataMember]
        public string FaultMessage;
    }

}
