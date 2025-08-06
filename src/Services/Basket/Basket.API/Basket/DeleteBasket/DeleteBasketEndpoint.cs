using System.Linq.Expressions;
using Basket.API.Basket.GetBasket;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketRequest(string UserName);

    public record DeleteBasketResponse(bool IsSuccess);

    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{username}", async (string username, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(username));
                //var response = result.IsSuccess == true ? new DeleteBasketResponse(true) : new DeleteBasketResponse(false);
                var response = result.Adapt<DeleteBasketResponse>();
                return Results.Ok(response);
            })
            .WithName("DeleteProduct")
            .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
        }
    }
}
