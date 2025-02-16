using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Models;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Services.Interface
{
    public interface ICategoryService
    {
        Task<bool> AddCategoryAsync(CategoryViewModel categoryViewModel);
        Task<bool> UpdateCategoryAsync(CategoryViewModel categoryViewModel);
        Task<bool> DeleteCategoryAsync(int id);
        Task<CategoryViewModel?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryViewModel>> GetAllCategorysAsync();
        Task<IEnumerable<CategoryViewModel>> GetCategorysByConditionAsync(Expression<Func<Category, bool>> expression);
    }
}
