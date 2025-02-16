using AutoMapper;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Repository.Interface;
using SupplyTrackr_API.Services.Interface;

namespace SupplyTrackr_API.Services.Implementation
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly IRepository<SalesOrder> _repository;
        private readonly IMapper _mapper;

        public SalesOrderService(IRepository<SalesOrder> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SalesOrderViewModel>> GetAllSalesOrdersAsync()
        {
            var salesOrders = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SalesOrderViewModel>>(salesOrders);
        }

        public async Task<SalesOrderViewModel?> GetSalesOrderByIdAsync(int id)
        {
            var salesOrder = await _repository.GetByIdAsync(id);
            return salesOrder == null ? null : _mapper.Map<SalesOrderViewModel>(salesOrder);
        }

        public async Task<bool> CreateSalesOrderAsync(SalesOrderViewModel salesOrderViewModel)
        {
            var salesOrder = _mapper.Map<SalesOrder>(salesOrderViewModel);
            return await _repository.AddAsync(salesOrder);
        }

        public async Task<bool> UpdateSalesOrderAsync(SalesOrderViewModel salesOrderViewModel)
        {
            var existingOrder = await _repository.GetByIdAsync(salesOrderViewModel.OrderId);
            if (existingOrder == null) return false;

            _mapper.Map(salesOrderViewModel, existingOrder); // Update existing product entity
            return await _repository.UpdateAsync(existingOrder);


        }

        public async Task<bool> DeleteSalesOrderAsync(int orderId)
        {
            return await _repository.DeleteAsync(orderId);
        }
    }
}
