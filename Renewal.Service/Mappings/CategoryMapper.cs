using Renewal.DataHub.Models.Domain;
using Renewal.Service.DTO;

namespace Renewal.Service.Mappings
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDto(Category category)
        {
            if (category == null)
                return null;

            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                IsActive = category.IsActive,
                CreatedBy = category.CreatedBy,
                CreatedDate = category.CreatedDate,
                UpdatedBy = category.UpdatedBy,
                UpdatedDate = category.UpdatedDate,
                Suspend = category.Suspend
            };
        }

        public static Category ToEntity(CreateCategoryDto dto)
        {
            return new Category
            {
                CategoryName = dto.CategoryName,
                CreatedBy = dto.CreatedBy
            };
        }

        public static void UpdateEntityFromDto(Category entity, UpdateCategoryDto dto)
        {
            entity.CategoryName = dto.CategoryName;
            entity.IsActive = dto.IsActive;
            entity.UpdatedBy = dto.UpdatedBy;
            entity.Suspend = dto.Suspend;
        }
    }
}