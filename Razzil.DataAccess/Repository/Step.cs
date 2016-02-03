namespace Razzil.DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Step")]
    public partial class Step
    {
        public int Id { get; set; }

        public int? PreviousStepId { get; set; }

        public int CurrentStepId { get; set; }

        public int? NextStepId1 { get; set; }

        public int? NextStepId0 { get; set; }

        public int StepTypeId { get; set; }

        public int BankId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Url { get; set; }

        [StringLength(500)]
        public string Params { get; set; }

        [StringLength(50)]
        public string Encoding { get; set; }

        [StringLength(500)]
        public string Sign { get; set; }

        [StringLength(500)]
        public string Pattern { get; set; }

        [StringLength(500)]
        public string XPath { get; set; }

        public int? TimeOut { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual StepType StepType { get; set; }
    }
}
