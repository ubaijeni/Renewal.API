using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Renewal.DataHub.Models.Domain;

[Table("MS_Category")]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CATEGORYID")]
    public int CategoryId { get; set; }     // [CATEGORYID] [int] IDENTITY(1,1) NOT NULL
    
    [Column("CATEGORYNAME")]
    public string? CategoryName { get; set; }     // [CATEGORYNAME] [nvarchar](max) NULL,
    
    [Column("ISACTIVE")]
    public int? IsActive { get; set; }     // [ISACTIVE] [int] NULL,
    
    [Column("CREATEDBY")]
    public int? CreatedBy { get; set; }   // [CREATEDBY] [int] NULL,
    
    [Column("CREATEDDATE")] 
    public DateTime? CreatedDate { get; set; }  // [CREATEDDATE] [date] NULL,
    
    [Column("UPDATEDBY")]
    public int? UpdatedBy { get; set; }     // [UPDATEDBY] [int] NULL,
    
    [Column("UPDATEDDATE")]
    public DateTime? UpdatedDate { get; set; }   // [UPDATEDDATE] [date] NULL,
    
    [Column("Suspend")]
    public int? Suspend { get; set; }  // [Suspend] [int] NULL
}