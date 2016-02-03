namespace Razzil.DataAccess.Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MainModel : DbContext
    {
        public MainModel()
            : base("name=MainModel")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountGroup> AccountGroups { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankTransaction> BankTransactions { get; set; }
        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<StepType> StepTypes { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Bank)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.AccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Balance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AccountGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AccountGroup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Bank>()
                .Property(e => e.BankId)
                .IsUnicode(false);

            modelBuilder.Entity<Bank>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Bank>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Bank>()
                .HasMany(e => e.BankTransactions)
                .WithOptional(e => e.Bank)
                .HasForeignKey(e => e.FromBankId);

            modelBuilder.Entity<Bank>()
                .HasMany(e => e.BankTransactions1)
                .WithOptional(e => e.Bank1)
                .HasForeignKey(e => e.ToBankId);

            modelBuilder.Entity<Bank>()
                .HasMany(e => e.Steps)
                .WithRequired(e => e.Bank)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.TransactionId)
                .IsUnicode(false);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.FromAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.ToAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.BankCharge)
                .HasPrecision(8, 0);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.CurrentBalance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.Otp)
                .IsUnicode(false);

            modelBuilder.Entity<BankTransaction>()
                .Property(e => e.OtpRef)
                .IsUnicode(false);

            modelBuilder.Entity<Step>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Step>()
                .Property(e => e.Encoding)
                .IsUnicode(false);

            modelBuilder.Entity<Step>()
                .Property(e => e.Sign)
                .IsUnicode(false);

            modelBuilder.Entity<Step>()
                .Property(e => e.Pattern)
                .IsUnicode(false);

            modelBuilder.Entity<Step>()
                .Property(e => e.XPath)
                .IsUnicode(false);

            modelBuilder.Entity<StepType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<StepType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<StepType>()
                .HasMany(e => e.Steps)
                .WithRequired(e => e.StepType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransactionType>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionType>()
                .HasMany(e => e.BankTransactions)
                .WithOptional(e => e.TransactionType)
                .HasForeignKey(e => e.TypeId);
        }
    }
}
