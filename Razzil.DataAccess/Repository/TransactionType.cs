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
    
    public partial class TransactionType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TransactionType()
        {
            this.BankTransactions = new HashSet<BankTransaction>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> LastUpdatedTime { get; set; }
        public int CreatedByUserID { get; set; }
        public int LastUpdatedByUserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankTransaction> BankTransactions { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
