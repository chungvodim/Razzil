using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razzil.DataAccess
{
    public class BankTransactionModel
    {
        public string TransactionId { get; set; }
        public string FromAccountId { get; set; }
        public string ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public string ToBankId { get; set; }
        public string OTP { get; set; }
        public string RefNo { get; set; }
        public string Fee { get; set; }
        public string Balance { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}
