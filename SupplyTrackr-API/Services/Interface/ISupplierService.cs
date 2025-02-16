using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Models;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Services.Interface
{
    public interface ISupplierService
    {


        Task<bool> AddSupplierAsync(SupplierViewModel supplierViewModel);
        Task<bool> UpdateSupplierAsync(SupplierViewModel supplierViewModel);
        Task<bool> DeleteSupplierAsync(int id);
        Task<SupplierViewModel?> GetSupplierByIdAsync(int id);
        Task<IEnumerable<SupplierViewModel>> GetAllSuppliersAsync();
        Task<IEnumerable<SupplierViewModel>> GetSuppliersByConditionAsync(Expression<Func<Supplier, bool>> expression);
    }
}
