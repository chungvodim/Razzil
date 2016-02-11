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
    
    public partial class Account
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public Nullable<int> AccountGroupId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> LastUpdatedTime { get; set; }
        public int CreatedByUserID { get; set; }
        public int LastUpdatedByUserID { get; set; }
    
        public virtual AccountGroup AccountGroup { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual UserRole UserRole1 { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
