using AutoMapper;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;
using SupplyTrackr_API.Repository.Interface;
using SupplyTrackr_API.Services.Interface;
using System.Linq.Expressions;

namespace SupplyTrackr_API.Services.Implementation
{
    public class SupplierService: ISupplierService
    {
        private readonly IRepository<Supplier> _repository;
        private readonly IMapper _mapper;

        public SupplierService(IRepository<Supplier> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AddSupplierAsync(SupplierViewModel supplierViewModel)
        {
            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            return await _repository.AddAsync(supplier);
        }
        public async Task<bool> UpdateSupplierAsync(SupplierViewModel supplierViewModel)
        {
            var supplier = await _repository.GetByIdAsync(supplierViewModel.Id);
            if (supplier == null) return false;

            _mapper.Map(supplierViewModel, supplier); // Update existing product entity
            return await _repository.UpdateAsync(supplier);
        }
        public async Task<bool> DeleteSupplierAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSuppliersAsync()
        {
            var supplier = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SupplierViewModel>>(supplier);
        }

        public async Task<SupplierViewModel?> GetSupplierByIdAsync(int id)
        {
            var supplier = await _repository.GetByIdAsync(id);
            return supplier == null ? null : _mapper.Map<SupplierViewModel>(supplier);
        }

        public async Task<IEnumerable<SupplierViewModel>> GetSuppliersByConditionAsync(Expression<Func<Supplier, bool>> expression)
        {
            var supplier = await _repository.GetByConditionAsync(expression);
            return _mapper.Map<IEnumerable<SupplierViewModel>>(supplier);
        }

       
    }
}
