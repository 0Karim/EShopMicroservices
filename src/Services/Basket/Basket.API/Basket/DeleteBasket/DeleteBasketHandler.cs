
namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string username) : ICommand<DeleteBasketResult>;

    public record DeleteBasketResult(bool isSuccess);

    public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public DeleteBasketHandler()
        {
            
        }

        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            // TODO: delete basket from database and cache       
            return new DeleteBasketResult(true);
        }
    }
}
