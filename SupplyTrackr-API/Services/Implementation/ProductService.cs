using AutoMapper;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Repository.Interface;
using System.Linq.Expressions;


public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;

    public ProductService(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> AddProductAsync(ProductViewModel productViewModel)
    {
        var product = _mapper.Map<Product>(productViewModel);
        return await _repository.AddAsync(product);
    }
    public async Task<bool> UpdateProductAsync(ProductViewModel productViewModel)
    {
        var product = await _repository.GetByIdAsync(productViewModel.Id);
        if (product == null) return false;

        _mapper.Map(productViewModel, product); // Update existing product entity
        return await _repository.UpdateAsync(product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
    {
        var products = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductViewModel>>(products);
    }

    public async Task<ProductViewModel?> GetProductByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product == null ? null : _mapper.Map<ProductViewModel>(product);
    }

    public async Task<IEnumerable<ProductViewModel>> GetProductsByConditionAsync(Expression<Func<Product, bool>> expression)
    {
        var products = await _repository.GetByConditionAsync(expression);
        return _mapper.Map<IEnumerable<ProductViewModel>>(products);
    }

   
}
