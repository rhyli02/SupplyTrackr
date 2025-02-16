using AutoMapper;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Repository.Interface;
using SupplyTrackr_API.Services.Interface;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Services.Implementation
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IRepository<PurchaseOrder> _purchaseOrderRepository;
        private readonly IMapper _mapper;

        public PurchaseOrderService(IRepository<PurchaseOrder> purchaseOrderRepository, IMapper mapper)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddPurchaseOrderAsync(PurchaseOrderViewModel purchaseOrderVm)
        {
            var purchaseOrder = _mapper.Map<PurchaseOrder>(purchaseOrderVm);
            return await _purchaseOrderRepository.AddAsync(purchaseOrder);
        }

        public async Task<bool> UpdatePurchaseOrderAsync(PurchaseOrderViewModel purchaseOrderVm)
        {
            var purchaseOrder = _mapper.Map<PurchaseOrder>(purchaseOrderVm);
            return await _purchaseOrderRepository.UpdateAsync(purchaseOrder);
        }

        public async Task<bool> DeletePurchaseOrderAsync(int id)
        {
            return await _purchaseOrderRepository.DeleteAsync(id);
        }

        public async Task<PurchaseOrderViewModel?> GetPurchaseOrderByIdAsync(int id)
        {
            var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);
            return purchaseOrder != null ? _mapper.Map<PurchaseOrderViewModel>(purchaseOrder) : null;
        }

        public async Task<IEnumerable<PurchaseOrderViewModel>> GetAllPurchaseOrdersAsync()
        {
            var purchaseOrders = await _purchaseOrderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PurchaseOrderViewModel>>(purchaseOrders);
        }

        public async Task<IEnumerable<PurchaseOrderViewModel>> GetPurchaseOrdersByConditionAsync(Expression<Func<PurchaseOrderViewModel, bool>> expression)
        {
            var conditionEntityExpression = _mapper.Map<Expression<Func<PurchaseOrder, bool>>>(expression);
            var purchaseOrders = await _purchaseOrderRepository.GetByConditionAsync(conditionEntityExpression);
            return _mapper.Map<IEnumerable<PurchaseOrderViewModel>>(purchaseOrders);
        }
    }
}
