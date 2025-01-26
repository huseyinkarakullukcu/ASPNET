using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryDtoAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryDtoAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
