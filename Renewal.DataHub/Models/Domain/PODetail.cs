using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renewal.DataHub.Models.Domain
{
    [Table("PODetails")]
    public class PODetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("POID")]
        public Guid POId { get; set; }

        [Column("POTypeID")]
        public int? POTypeId { get; set; }

        [NotMapped]
        public POType? Type
        {
            get => POTypeId.HasValue ? (POType)POTypeId.Value : null;
            set => POTypeId = value.HasValue ? (int)value.Value : null;
        }

        [Column("PONumber")]
        public string? PONumber { get; set; }

        [Column("POvalue", TypeName = "decimal(18,2)")]
        public decimal? POValue { get; set; }

        [Column("POStatusID")]
        public int? POStatusId { get; set; }

        [Column("ClientNameID")]
        public Guid? ClientNameId { get; set; }

        [Column("EngagementModelID")]
        public int? EngagementModelId { get; set; }

        [Column("ResourceprojectName")]
        public string? ResourceProjectName { get; set; }

        [Column("LocationID")]
        public int? LocationId { get; set; }

        [Column("Accountable")]
        public string? Accountable { get; set; }

        [Column("CurrencyID")]
        public int? CurrencyId { get; set; }

        [Column("JoiningDate")]
        public DateTime? JoiningDate { get; set; }

        [Column("StartDate")]
        public DateTime? StartDate { get; set; }

        [Column("EndDate")]
        public DateTime? EndDate { get; set; }

        [Column("ContractPeriod")]
        [MaxLength(200)]
        public string? ContractPeriod { get; set; }

        [Column("RenewalDate")]
        public DateTime? RenewalDate { get; set; }

        [Column("RemindertoAlert")]
        public string? ReminderToAlert { get; set; }

        [Column("Remarks")]
        public string? Remarks { get; set; }

        [Column("POFileName")]
        public string? POFileName { get; set; }

        [Column("Isactive")]
        public int? IsActive { get; set; }

        [Column("Suspend")]
        public int? Suspend { get; set; }

        [Column("Createddatetime")]
        public DateTime? CreatedDateTime { get; set; }

        [Column("CreatedBy")]
        public int? CreatedBy { get; set; }

        [Column("Updateddatetime")]
        public DateTime? UpdatedDateTime { get; set; }

        [Column("UpdatedBy")]
        public int? UpdatedBy { get; set; }

        [Column("DMPOC")]
        [MaxLength(255)]
        public string? DMPOC { get; set; }

        [Column("FMPOC")]
        [MaxLength(255)]
        public string? FMPOC { get; set; }

        [Column("ProposalPath")]
        [MaxLength(255)]
        public string? ProposalPath { get; set; }

        // Foreign Key Reference
        [ForeignKey("ClientNameId")]
        public virtual Client Client { get; set; }

        [NotMapped] // This is not stored in the database
        public string? ClientName { get; set; }
    }
}
