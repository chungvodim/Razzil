using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Razzil.DataAccess;

namespace Razzil.Workflow
{
    public class StepContext : DomainObject
    {
        public string LastPage { get; set; }
        public StatusCode StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public BankTransactionModel TransferModel { get; set; }
        public Encoding Encoding { get; set; }
        public Dictionary<int, IEnumerable<KeyValuePair<string, string>>> Params { get; set; }
    }
}
