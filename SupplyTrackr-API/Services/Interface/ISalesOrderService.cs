using SupplyTrackr_API.Models.ViewModels;

namespace SupplyTrackr_API.Services.Interface
{
    public interface ISalesOrderService
    {
        Task<IEnumerable<SalesOrderViewModel>> GetAllSalesOrdersAsync();
        Task<SalesOrderViewModel?> GetSalesOrderByIdAsync(int orderId);
        Task<bool> CreateSalesOrderAsync(SalesOrderViewModel salesOrder);
        Task<bool> UpdateSalesOrderAsync(SalesOrderViewModel salesOrder);
        Task<bool> DeleteSalesOrderAsync(int orderId);
    }
}
