using Application.Cart.CartDetails;
using Application.Categories;
using Application.Coupons;
using Application.Coupons.UserCoupons;
using Application.Order.OrderDetails;
using Application.Orders;
using Application.Products;
using Application.Users.DTOs;
using AutoMapper;
using Domain;
using Domain.Cart;
using Domain.Coupon;
using Domain.Order;
using Domain.Product;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateProductMaps();
        CreateCategoryMaps();
        CreateCartMaps();
        CreateOrderMaps();
        CreateCouponMaps();
        CreateUserMaps();
    }

    private void CreateProductMaps()
    {
        CreateMap<CreateProductRequestDTO, Product>();
        CreateMap<EditProductRequestDTO, Product>();
    }

    private void CreateCategoryMaps()
    {
        CreateMap<CreateCategoryRequestDTO, Category>();
        CreateMap<EditCategoryRequestDTO, Category>();
    }

    private void CreateCartMaps()
    {
        CreateMap<CreateCartDetailRequestDTO, CartDetail>();
    }

    private void CreateCouponMaps()
    {
        CreateMap<CreateCouponRequestDTO, Coupon>();
        CreateMap<EditCouponRequestDTO, Coupon>();
        CreateMap<CreateUserCouponRequestDTO, UserCoupon>();
    }

    private void CreateOrderMaps()
    {
        CreateMap<CreateOrderRequestDTO.OrderDto, Domain.Order.Order>();
        CreateMap<EditOrderRequestDTO, Domain.Order.Order>();
        CreateMap<CreateOrderDetailRequestDTO, OrderDetail>();
    }

    private void CreateUserMaps()
    {
        CreateMap<User, GetUserResponseDTO>();
    }

}
