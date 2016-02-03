namespace Razzil.DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Bank { get; set; }

        public int? AccountGroupId { get; set; }

        [StringLength(50)]
        public string AccountName { get; set; }

        [StringLength(50)]
        public string AccountNumber { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public decimal? Balance { get; set; }

        public bool Active { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }
    }
}
