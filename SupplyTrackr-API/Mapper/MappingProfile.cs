using AutoMapper;
using SupplyTrackr_API.Models;
using SupplyTrackr_API.Models.ViewModels;

namespace SupplyTrackr_API.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile() {

            // Mapping for Product
            CreateMap<Product, ProductViewModel>().ReverseMap();

            // Mapping for PurchaseOrder
            CreateMap<PurchaseOrder, PurchaseOrderViewModel>().ReverseMap();
            // Mapping for SalesOrder
            CreateMap<SalesOrder, SalesOrderViewModel>().ReverseMap();
            //Mapping for Supplier
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            //Mapping for User
            CreateMap<User, UserViewModel>().ReverseMap();
            //Mapping for Category
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
