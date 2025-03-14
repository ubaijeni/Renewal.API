using Renewal.DataHub.Models.Domain;
using Renewal.Service.DTO;
using System;

namespace Renewal.Service.Mappings
{
    public static class PODetailsMapper
    {
        public static PODetailsDto ToDto(PODetail poDetail)
        {
            if (poDetail == null)
                return null;
                
            return new PODetailsDto
            {
                POId = poDetail.POId,
                POTypeId = poDetail.POTypeId,
                PONumber = poDetail.PONumber,
                POValue = poDetail.POValue,
                POStatusId = poDetail.POStatusId,
                ClientNameId = poDetail.ClientNameId,
                EngagementModelId = poDetail.EngagementModelId,
                ResourceProjectName = poDetail.ResourceProjectName,
                LocationId = poDetail.LocationId,
                Accountable = poDetail.Accountable,
                CurrencyId = poDetail.CurrencyId,
                JoiningDate = poDetail.JoiningDate != null ? DateTime.Parse(poDetail.JoiningDate) : null,
                StartDate = DateTime.Parse(poDetail.StartDate),
                EndDate = DateTime.Parse(poDetail.EndDate),
                ContractPeriod = poDetail.ContractPeriod,
                RenewalDate = poDetail.RenewalDate != null ? DateTime.Parse(poDetail.RenewalDate) : null,
                ReminderToAlert = poDetail.ReminderToAlert,
                Remarks = poDetail.Remarks,
                POFileName = poDetail.POFileName,
                IsActive = poDetail.IsActive,
                Suspend = poDetail.Suspend,
                CreatedDateTime = poDetail.CreatedDateTime,
                CreatedBy = poDetail.CreatedBy,
                UpdatedDateTime = poDetail.UpdatedDateTime,
                UpdatedBy = poDetail.UpdatedBy,
                DMPOC = poDetail.DMPOC,
                FMPOC = poDetail.FMPOC,
                ProposalPath = poDetail.ProposalPath
            };
        }

        public static PODetail ToEntity(CreatePODetailsDto dto)
        {
            return new PODetail
            {
                PONumber = dto.PONumber,
                CreatedBy = dto.CreatedBy,
                POTypeId = dto.POTypeId,
                POValue = dto.POValue,
                POStatusId = dto.POStatusId,
                ClientNameId = dto.ClientNameId,
                EngagementModelId = dto.EngagementModelId,
                ResourceProjectName = dto.ResourceProjectName,
                LocationId = dto.LocationId,
                Accountable = dto.Accountable,
                CurrencyId = dto.CurrencyId,
                JoiningDate = dto.JoiningDate?.ToString("yyyy-MM-dd"),
                StartDate = dto.StartDate.ToString("yyyy-MM-dd"),
                EndDate = dto.EndDate.ToString("yyyy-MM-dd"),
                ContractPeriod = dto.ContractPeriod,
                RenewalDate = dto.RenewalDate?.ToString("yyyy-MM-dd"),
                ReminderToAlert = dto.ReminderToAlert,
                Remarks = dto.Remarks,
                POFileName = dto.POFileName,
                DMPOC = dto.DMPOC,
                FMPOC = dto.FMPOC,
                ProposalPath = dto.ProposalPath
            };
        }

        public static void UpdateEntityFromDto(PODetail entity, UpdatePODetailsDto dto)
        {
            entity.PONumber = dto.PONumber;
            entity.UpdatedBy = dto.UpdatedBy;
            entity.POTypeId = dto.POTypeId;
            entity.POValue = dto.POValue;
            entity.POStatusId = dto.POStatusId;
            entity.ClientNameId = dto.ClientNameId;
            entity.EngagementModelId = dto.EngagementModelId;
            entity.ResourceProjectName = dto.ResourceProjectName;
            entity.LocationId = dto.LocationId;
            entity.Accountable = dto.Accountable;
            entity.CurrencyId = dto.CurrencyId;
            entity.JoiningDate = dto.JoiningDate?.ToString("yyyy-MM-dd");
            entity.StartDate = dto.StartDate.ToString("yyyy-MM-dd");
            entity.EndDate = dto.EndDate.ToString("yyyy-MM-dd");
            entity.ContractPeriod = dto.ContractPeriod;
            entity.RenewalDate = dto.RenewalDate?.ToString("yyyy-MM-dd");
            entity.ReminderToAlert = dto.ReminderToAlert;
            entity.Remarks = dto.Remarks;
            entity.POFileName = dto.POFileName;
            entity.IsActive = dto.IsActive;
            entity.Suspend = dto.Suspend;
            entity.DMPOC = dto.DMPOC;
            entity.FMPOC = dto.FMPOC;
            entity.ProposalPath = dto.ProposalPath;
        }
    }
}