using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Razzil.DataAccess;
using System.Net.Http;
using Razzil.DataAccess.Repository;

namespace Razzil.Workflow
{
    public class StepContext : DomainObject
    {
        public StepContext(string bankName)
        {
            using (var db = new Entities())
            {
                var bank = db.Banks.Where(x => x.Name == bankName).FirstOrDefault();
                if(bank != null)
                {
                    Client = new HttpClient() { Timeout = new TimeSpan(0, 0, bank.TimeOut.Value) };
                }
            }
        }
        public HttpClient Client { get; set; }
        public int BankId { get; set; }
        public string LastPage { get; set; }
        public StatusCode StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public BankTransactionModel TransferModel { get; set; }
        public Encoding Encoding { get; set; }
        public Dictionary<string, string> Params { get; set; }
    }
}
