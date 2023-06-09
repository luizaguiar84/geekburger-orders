﻿using AutoMapper;
using GeekBurger.Orders.Contract;
using GeekBurger.Orders.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GeekBurger.Orders
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //ForMember(x => x.Total, opt => opt.ResolveUsing(x => x.Products.Sum(h => h.Price)));
            CreateMap<OrderToUpsert, Order>()
                .ForMember(x=>x.Total,opt=>opt.MapFrom(y=>y.Products.Sum(z=>z.Price)));
            CreateMap<Product, ProductToUpsert>();
            CreateMap<ProductToUpsert, Product>().ForMember(x => x.OrderId, opt => opt.Ignore());
            CreateMap<Order, OrderToGet>();
            CreateMap<PaymentToUpsert, Payment>();
            CreateMap<EntityEntry<Order>, OrderChangedMessage>()
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Entity));

            CreateMap<EntityEntry<Order>, OrderChangedEvent>()
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Entity));


        }
    }
}
