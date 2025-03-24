using NewsAPI.Domain.AppEntity;
using NewsAPI.Domain.DTOS.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.AppHandler.Mapping
{
    public static class CategoryMapProfile
    {
        public static CategoryReadDto MapFromCategoryToReadDto(this Category category)
        {
            return new CategoryReadDto
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public static IEnumerable<CategoryReadDto> MapFromCategoryListToReadDto(this IEnumerable<Category> categories)
        {
            return categories.Select(category => category.MapFromCategoryToReadDto());
        }

        public static Category MapFromCategoryToCreateDto(this CategoryCreateDto category)
        {
            return new Category
            {
                Name = category.Name,
            };
        }
    }
}