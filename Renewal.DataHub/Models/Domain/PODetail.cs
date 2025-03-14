using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renewal.DataHub.Models.Domain;

[Table("PODetails")]
public class PODetail
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("POID")]
    public int POId { get; set; } // [POID] [int] IDENTITY(1,1) NOT NULL,

    [Column("POTypeID")] 
    public int? POTypeId { get; set; } // [POTypeID] [int] NULL,

    [Column("PONumber")] 
    public string? PONumber { get; set; } // [PONumber] [nvarchar](max) NULL,

    [Column("POvalue", TypeName = "decimal(18,2)")] 
    public decimal? POValue { get; set; } // [POvalue] [decimal](18, 2) NULL,

    [Column("POStatusID")] 
    public int? POStatusId { get; set; } // [POStatusID] [int] NULL,

    [Column("ClientNameID")] 
    public int? ClientNameId { get; set; } // [ClientNameID] [int] NULL,

    [Column("EngagementModelID")] 
    public int? EngagementModelId { get; set; } // [EngagementModelID] [int] NULL,

    [Column("ResourceprojectName")]
    public string? ResourceProjectName { get; set; } // [ResourceprojectName] [nvarchar](max) NULL,

    [Column("LocationID")] 
    public int? LocationId { get; set; } // [LocationID] [int] NULL,

    [Column("Accountable")] 
    public string? Accountable { get; set; } // [Accountable] [nvarchar](max) NULL,

    [Column("CurrencyID")] 
    public int? CurrencyId { get; set; } // [CurrencyID] [int] NULL,

    [Column("JoiningDate")] 
    public string? JoiningDate { get; set; } // [JoiningDate] [nvarchar](max) NULL,

    [Column("StartDate")] 
    public string? StartDate { get; set; } // [StartDate] [nvarchar](max) NULL,

    [Column("EndDate")]
    public string? EndDate { get; set; } // [EndDate] [nvarchar](max) NULL,

    [Column("ContractPeriod")] 
    [MaxLength(200)]
    public string? ContractPeriod { get; set; } // [ContractPeriod] [nvarchar](200) NULL,

    [Column("RenewalDate")] 
    public string? RenewalDate { get; set; } // [RenewalDate] [nvarchar](max) NULL,

    [Column("RemindertoAlert")] 
    public string? ReminderToAlert { get; set; } // [RemindertoAlert] [nvarchar](max) NULL,

    [Column("Remarks")] 
    public string? Remarks { get; set; } // [Remarks] [nvarchar](max) NULL,

    [Column("POFileName")] 
    public string? POFileName { get; set; } // [POFileName] [nvarchar](max) NULL,

    [Column("Isactive")] 
    public int? IsActive { get; set; } // [Isactive] [int] NULL,

    [Column("Suspend")] 
    public int? Suspend { get; set; } // [Suspend] [int] NULL,

    [Column("Createddatetime")] 
    public DateTime? CreatedDateTime { get; set; } // [Createddatetime] [datetime] NULL,

    [Column("CreatedBy")] 
    public int? CreatedBy { get; set; } // [CreatedBy] [int] NULL,

    [Column("Updateddatetime")] 
    public DateTime? UpdatedDateTime { get; set; } // [Updateddatetime] [datetime] NULL,

    [Column("UpdatedBy")] 
    public int? UpdatedBy { get; set; } // [UpdatedBy] [int] NULL,

    [Column("DMPOC")] 
    [MaxLength(255)]
    public string? DMPOC { get; set; } // [DMPOC] [nvarchar](255) NULL,

    [Column("FMPOC")]
    [MaxLength(255)]
    public string? FMPOC { get; set; } // [FMPOC] [nvarchar](255) NULL,

    [Column("ProposalPath")] 
    [MaxLength(255)]
    public string? ProposalPath { get; set; } // [ProposalPath] [nvarchar](255) NULL,
}