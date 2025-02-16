using AutoMapper;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Repository.Interface;
using SupplyTrackr_API.Services.Interface;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Services.Implementation
{
    public class CategoryService:ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AddCategoryAsync(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            return await _repository.AddAsync(category);
        }
        public async Task<bool> UpdateCategoryAsync(CategoryViewModel categoryViewModel)
        {
            var category = await _repository.GetByIdAsync(categoryViewModel.CategoryId);
            if (category == null) return false;

            _mapper.Map(categoryViewModel, category); // Update existing product entity
            return await _repository.UpdateAsync(category);
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategorysAsync()
        {
            var category = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryViewModel>>(category);
        }

        public async Task<CategoryViewModel?> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            return category == null ? null : _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategorysByConditionAsync(Expression<Func<Category, bool>> expression)
        {
            var category = await _repository.GetByConditionAsync(expression);
            return _mapper.Map<IEnumerable<CategoryViewModel>>(category);
        }

        
    }
}
