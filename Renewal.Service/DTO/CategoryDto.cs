using System;
using System.ComponentModel.DataAnnotations;

namespace Renewal.Service.DTO
{
    // DTO for returning category data
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Suspend { get; set; }
    }

    // DTO for creating a new category
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(100, ErrorMessage = "Category Name cannot exceed 100 characters")]
        public string CategoryName { get; set; }
        
        [Required(ErrorMessage = "CreatedBy is required")]
        public int CreatedBy { get; set; }
    }

    // DTO for updating an existing category
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(100, ErrorMessage = "Category Name cannot exceed 100 characters")]
        public string CategoryName { get; set; }
        
        [Required(ErrorMessage = "IsActive status is required")]
        [Range(0, 1, ErrorMessage = "IsActive must be either 0 or 1")]
        public int IsActive { get; set; }
        
        [Required(ErrorMessage = "UpdatedBy is required")]
        public int UpdatedBy { get; set; }
        
        [Range(0, 1, ErrorMessage = "Suspend must be either 0 or 1")]
        public int? Suspend { get; set; }
    }
}