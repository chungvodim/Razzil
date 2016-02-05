//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Razzil.DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bank
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bank()
        {
            this.Accounts = new HashSet<Account>();
            this.Bank1 = new HashSet<Bank>();
            this.BankTransactions = new HashSet<BankTransaction>();
            this.BankTransactions1 = new HashSet<BankTransaction>();
            this.Steps = new HashSet<Step>();
        }
    
        public int Id { get; set; }
        public string BankId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public Nullable<int> BankGroupId { get; set; }
        public Nullable<int> TimeOut { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bank> Bank1 { get; set; }
        public virtual Bank Bank2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankTransaction> BankTransactions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankTransaction> BankTransactions1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Step> Steps { get; set; }
    }
}
