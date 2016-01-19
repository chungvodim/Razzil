using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Domain
{
    public class StepContext : DomainObject
    {
        public string Token { get; set; }
        public string SelBase { get; set; }
        public string TxtParam { get; set; }
        
        public string OTP { get; set; }
        public string RefNo { get; set; }
        public string Fee { get; set; }
        public string Balance { get; set; }
        public string LastPage { get; set; }
        public StatusCode StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public TransactionModel TransferModel { get; set; } 
    }
}
