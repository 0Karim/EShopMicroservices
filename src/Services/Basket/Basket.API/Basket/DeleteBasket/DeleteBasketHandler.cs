
namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string username) : ICommand<DeleteBasketResult>;

    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            // TODO: delete basket from database and cache       
            await repository.DeleteBasket(request.username, cancellationToken);
            return new DeleteBasketResult(true);
        }
    }
}
