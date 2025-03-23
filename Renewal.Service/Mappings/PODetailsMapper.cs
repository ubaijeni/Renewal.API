using System;
using Renewal.DataHub.Models.Domain;
using Renewal.Service.DTO;

namespace Renewal.Service.Mappings
{
    public static class PODetailsMapper
    {
        // ✅ Convert Entity to DTO
        public static PODetailsDto ToDto(PODetail poDetail)
        {
            if (poDetail == null)
                return null;

            return new PODetailsDto
            {
                POId = poDetail.POId,
                Type = poDetail.POTypeId.HasValue ? (POType)poDetail.POTypeId.Value : (POType?)null, // ✅ Convert POTypeId to Enum
                PONumber = poDetail.PONumber,
                POValue = poDetail.POValue,
                POStatusId = poDetail.POStatusId,
                ClientNameId = poDetail.ClientNameId,
                ClientName = poDetail.Client?.ClientName, // ✅ Safe null handling
                EngagementModelId = poDetail.EngagementModelId,
                ResourceProjectName = poDetail.ResourceProjectName,
                LocationId = poDetail.LocationId,
                Accountable = poDetail.Accountable,
                CurrencyId = poDetail.CurrencyId,
                ContractPeriod = poDetail.ContractPeriod,
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

        // ✅ Convert Create DTO to Entity
        public static PODetail ToEntity(CreatePODetailsDto dto)
        {
            if (dto == null)
                return null;

            return new PODetail
            {
                POId = Guid.NewGuid(), // ✅ Ensure a new Guid is assigned
                POTypeId = dto.Type.HasValue ? (int)dto.Type.Value : (int?)null, // ✅ Convert Enum to int
                PONumber = dto.PONumber,
                POValue = dto.POValue,
                POStatusId = dto.POStatusId,
                ClientNameId = dto.ClientNameId,
                EngagementModelId = dto.EngagementModelId,
                ResourceProjectName = dto.ResourceProjectName,
                LocationId = dto.LocationId,
                Accountable = dto.Accountable,
                CurrencyId = dto.CurrencyId,
                ContractPeriod = dto.ContractPeriod,
                ReminderToAlert = dto.ReminderToAlert,
                Remarks = dto.Remarks,
                POFileName = dto.POFileName,
                DMPOC = dto.DMPOC,
                FMPOC = dto.FMPOC,
                ProposalPath = dto.ProposalPath,
                IsActive = 1, // ✅ Assuming new POs are active by default
                CreatedDateTime = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,
                UpdatedDateTime = DateTime.UtcNow,
                UpdatedBy = dto.CreatedBy
            };
        }

        // ✅ Update existing Entity from DTO
        public static void UpdateEntityFromDto(PODetail entity, UpdatePODetailsDto dto)
        {
            if (entity == null || dto == null)
                return;

entity.POTypeId = dto.Type.HasValue ? (int)dto.Type.Value : (int?)null; // ✅ Corrected
            entity.PONumber = dto.PONumber;
            entity.POValue = dto.POValue;
            entity.POStatusId = dto.POStatusId;
            entity.ClientNameId = dto.ClientNameId;
            entity.EngagementModelId = dto.EngagementModelId;
            entity.ResourceProjectName = dto.ResourceProjectName;
            entity.LocationId = dto.LocationId;
            entity.Accountable = dto.Accountable;
            entity.CurrencyId = dto.CurrencyId;
            entity.ContractPeriod = dto.ContractPeriod;
            entity.ReminderToAlert = dto.ReminderToAlert;
            entity.Remarks = dto.Remarks;
            entity.POFileName = dto.POFileName;
            entity.IsActive = dto.IsActive;
            entity.Suspend = dto.Suspend;
            entity.DMPOC = dto.DMPOC;
            entity.FMPOC = dto.FMPOC;
            entity.ProposalPath = dto.ProposalPath;
            entity.UpdatedBy = dto.UpdatedBy;
            entity.UpdatedDateTime = DateTime.UtcNow; // ✅ Ensure update timestamp is set
        }
    }
}
