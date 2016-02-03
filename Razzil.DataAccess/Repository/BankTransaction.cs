namespace Razzil.DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BankTransaction")]
    public partial class BankTransaction
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TransactionId { get; set; }

        public int? TypeId { get; set; }

        [StringLength(20)]
        public string FromAccountNumber { get; set; }

        public int? FromBankId { get; set; }

        [StringLength(20)]
        public string ToAccountNumber { get; set; }

        public int? ToBankId { get; set; }

        public decimal? Amount { get; set; }

        public decimal? BankCharge { get; set; }

        public decimal? CurrentBalance { get; set; }

        [StringLength(20)]
        public string Otp { get; set; }

        [StringLength(20)]
        public string OtpRef { get; set; }

        public string LastPage { get; set; }

        public DateTime? CreatedTime { get; set; }

        public DateTime? LastUpdatedTime { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual Bank Bank1 { get; set; }

        public virtual TransactionType TransactionType { get; set; }
    }
}
