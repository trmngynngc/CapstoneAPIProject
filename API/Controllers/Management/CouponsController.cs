using Application.Core;
using Application.Coupons;
using Application.Coupons.UserCoupons;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Create = Application.Coupons.Create;
using CreateUserCoupon = Application.Coupons.UserCoupons.Create;
using Delete = Application.Coupons.Delete;
using DeleteUserCoupon = Application.Coupons.UserCoupons.Delete;
using List = Application.Coupons.List;
using ListUserCoupon = Application.Coupons.UserCoupons.List;

namespace API.Controllers.Management;

public class CouponsController : ManagementApiController
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a Coupon")]
    public async Task<IActionResult> CreateCoupon(CreateCouponRequestDTO coupon)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Coupon = coupon }));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Edit a Coupon")]
    public async Task<IActionResult> EditCoupon(Guid id, EditCouponRequestDTO coupon)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { Id = id, Coupon = coupon }));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Coupon")]
    public async Task<IActionResult> DeleteCoupon(Guid id)
    {
        return HandleResult(await Mediator.Send((new Delete.Command { Id = id })));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "List Coupons")]
    public async Task<ActionResult<ListCouponResponseDTO>> GetCoupons([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query { QueryParams = pagingParams }));
    }

    [HttpPost("Users")]
    [SwaggerOperation(Summary = "Add an eligible User to a Coupon")]
    public async Task<IActionResult> CreateUserCoupon(CreateUserCouponRequestDTO userCoupon)
    {
        return HandleResult(await Mediator.Send(new CreateUserCoupon.Command { UserCoupon = userCoupon }));
    }

    [HttpDelete("Users")]
    [SwaggerOperation(Summary = "Remove a User from a Coupon")]
    public async Task<IActionResult> DeleteUserCoupon(Guid couponId, string userId)
    {
        return HandleResult(await Mediator.Send((new DeleteUserCoupon.Command { CouponId = couponId, UserId = userId})));
    }

    [HttpGet("{id}/Users")]
    [SwaggerOperation(Summary = "List Users eligible to use a Coupon")]
    public async Task<ActionResult<ListUserCouponResponseDTO>> GetUserCoupons(Guid id, [FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new ListUserCoupon.Query { Id = id, QueryParams = pagingParams }));
    }
}
