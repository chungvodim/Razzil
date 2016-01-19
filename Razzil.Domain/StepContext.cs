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
        
        public string LastPage { get; set; }
        public StatusCode StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public TransactionModel TransferModel { get; set; }
        public Encoding Encoding { get; set; }
    }
}
