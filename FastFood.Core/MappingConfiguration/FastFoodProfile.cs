namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Services.Models;
    using FastFood.Services.Models.Categories;
    using FastFood.Services.Models.Items;
    using FastFood.Services.Models.Orders;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Categories
            this.CreateMap<CreateCategoryDTO, Category>(); //properties with the same Name, doesn't need configuring
            this.CreateMap<CreateCategoryInputModel, CreateCategoryDTO>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.CategoryName));
            this.CreateMap<Category, ListCategoryDTO>(); // properties with the same Name, doesn't need configuring
            this.CreateMap<ListCategoryDTO, CategoryAllViewModel>();// properties with the same Name, doesn't need configuring

            //Items
            this.CreateMap<ListCategoryDTO, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.CategoryName, y => y.MapFrom(x => x.Name));
            this.CreateMap<CreateItemInputModel, CreateItemDTO>();// properties with the same Name, doesn't need configuring
            this.CreateMap<CreateItemDTO, Item>();
            this.CreateMap<Item, ListItemDTO>()
                .ForMember(x => x.Category, y => y.MapFrom(x => x.Category.Name));
            this.CreateMap<ListItemDTO, ItemsAllViewModels>();

            //Orders
            this.CreateMap<CreateOrderInputModel, CreateOrderDTO>();
            this.CreateMap<CreateOrderDTO,Order>();
            this.CreateMap<ListOrderDTO,CreateOrderViewModel>();
                
        }
    }
}
