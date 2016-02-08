using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razzil.Models
{
    public class BankTransactionModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TransactionId { get; set; }
        public string FromAccountName { get; set; }
        public string FromAccountNumber { get; set; }
        public string ToAccountName { get; set; }
        public string ToAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string ToBankId { get; set; }
        public string Captcha { get; set; }
        public string OTP { get; set; }
        public string RefNo { get; set; }
        public string Fee { get; set; }
        public string Balance { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}
