using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Services.Interface
{
    public interface IPurchaseOrderService
    {
        Task<bool> AddPurchaseOrderAsync(PurchaseOrderViewModel purchaseOrder);
        Task<bool> UpdatePurchaseOrderAsync(PurchaseOrderViewModel purchaseOrder);
        Task<bool> DeletePurchaseOrderAsync(int id);
        Task<PurchaseOrderViewModel?> GetPurchaseOrderByIdAsync(int id);
        Task<IEnumerable<PurchaseOrderViewModel>> GetAllPurchaseOrdersAsync();
        Task<IEnumerable<PurchaseOrderViewModel>> GetPurchaseOrdersByConditionAsync(Expression<Func<PurchaseOrderViewModel, bool>> expression);

    }
}
