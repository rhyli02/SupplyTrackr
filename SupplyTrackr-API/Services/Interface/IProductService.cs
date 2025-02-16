using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;
using System.Linq.Expressions;


public interface IProductService
{
   

    Task<bool> AddProductAsync(ProductViewModel productViewModel);
    Task<bool> UpdateProductAsync(ProductViewModel productViewModel);
    Task<bool> DeleteProductAsync(int id);
    Task<ProductViewModel?> GetProductByIdAsync(int id);
    Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
    Task<IEnumerable<ProductViewModel>> GetProductsByConditionAsync(Expression<Func<Product, bool>> expression);
}
