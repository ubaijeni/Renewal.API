using System;
using System.ComponentModel.DataAnnotations;
using Renewal.DataHub.Models.Domain;

namespace Renewal.Service.DTO
{
    // Custom validation attribute for date comparison
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            
            if (property == null)
            {
                return new ValidationResult($"Unknown property: {_comparisonProperty}");
            }

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

            if (currentValue < comparisonValue)
            {
                return new ValidationResult(ErrorMessage ?? "End date must be after start date");
            }

            return ValidationResult.Success;
        }
    }

    // DTO for returning PO Details data
    public class PODetailsDto
    {
        public Guid POId { get; set; }

        public POType? Type { get; set; } // Change from POTypeId to Enum

        public string? PONumber { get; set; }
        public decimal? POValue { get; set; }
        public int? POStatusId { get; set; }
        public Guid? ClientNameId { get; set; }
        public int? EngagementModelId { get; set; }
        public string? ResourceProjectName { get; set; }
        public int? LocationId { get; set; }
        public string? Accountable { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ContractPeriod { get; set; }
        public DateTime? RenewalDate { get; set; }
        public string? ReminderToAlert { get; set; }
        public string? Remarks { get; set; }
        public string? POFileName { get; set; }
        public int? IsActive { get; set; }
        public int? Suspend { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? UpdatedBy { get; set; }
        public string? DMPOC { get; set; }
        public string? FMPOC { get; set; }
        public string? ProposalPath { get; set; }
        public string? ClientName { get; set; }
        public ClientDTO Client { get; set; }
    }

    // DTO for creating a new PO Detail
    public class CreatePODetailsDto
    {
        [Required(ErrorMessage = "PO Number is required")]
        [StringLength(100, ErrorMessage = "PO Number cannot exceed 100 characters")]
        public string PONumber { get; set; }

        [Required(ErrorMessage = "CreatedBy is required")]
        public int CreatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DateGreaterThan(nameof(StartDate), ErrorMessage = "End Date must be after Start Date")]
        public DateTime? EndDate { get; set; }

        public POType? Type { get; set; } // Change from POTypeId to Enum

        public decimal? POValue { get; set; }
        public int? POStatusId { get; set; }
        public Guid? ClientNameId { get; set; }
        public int? EngagementModelId { get; set; }
        public string? ResourceProjectName { get; set; }
        public int? LocationId { get; set; }
        public string? Accountable { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? ContractPeriod { get; set; }
        public DateTime? RenewalDate { get; set; }
        public string? ReminderToAlert { get; set; }
        public string? Remarks { get; set; }
        public string? POFileName { get; set; }
        public string? DMPOC { get; set; }
        public string? FMPOC { get; set; }
        public string? ProposalPath { get; set; }
        public string? ClientName { get; set; }
        public Client Client { get; set; }

    }

    // DTO for updating an existing PO Detail
    public class UpdatePODetailsDto
    {
        [Required(ErrorMessage = "PO Number is required")]
        [StringLength(100, ErrorMessage = "PO Number cannot exceed 100 characters")]
        public string PONumber { get; set; }

        [Required(ErrorMessage = "UpdatedBy is required")]
        public int UpdatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DateGreaterThan(nameof(StartDate), ErrorMessage = "End Date must be after Start Date")]
        public DateTime EndDate { get; set; }

        public POType? Type { get; set; } // Change from POTypeId to Enum

        public decimal? POValue { get; set; }
        public int? POStatusId { get; set; }
        public Guid? ClientNameId { get; set; }
        public int? EngagementModelId { get; set; }
        public string? ResourceProjectName { get; set; }
        public int? LocationId { get; set; }
        public string? Accountable { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? ContractPeriod { get; set; }
        public DateTime? RenewalDate { get; set; }
        public string? ReminderToAlert { get; set; }
        public string? Remarks { get; set; }
        public string? POFileName { get; set; }

        [Range(0, 1, ErrorMessage = "IsActive must be either 0 or 1")]
        public int? IsActive { get; set; }

        [Range(0, 1, ErrorMessage = "Suspend must be either 0 or 1")]
        public int? Suspend { get; set; }

        public string? DMPOC { get; set; }
        public string? FMPOC { get; set; }
        public string? ProposalPath { get; set; }
        public string? ClientName { get; set; }
        public Client Client { get; set; }

    }
}